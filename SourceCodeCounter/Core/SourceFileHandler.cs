using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using SourceCodeCounter.Interfaces;
using SourceCodeCounter.Common;

namespace SourceCodeCounter.Core
{
    public class SourceFileHandler : ISourceHandler
    {
        #region - Static Declarations -
        readonly Projects _projects;
        readonly List<string> _excludePatterns = new List<string>();
        SourceResult _report;
        #endregion

        #region - Constructor -
        public SourceFileHandler()
        {
            _projects = new Projects();
            Report = new SourceResult();
        }
        #endregion

        #region - Private Declarations -
        private static string GetRegexPattern(string wildcardPattern)
        {
            var builder = new StringBuilder(wildcardPattern);

            builder.Replace(@"\", @"\\");
            builder.Replace(".", "\\.");
            builder.Replace("^", "\\^");
            builder.Replace("$", "\\$");
            builder.Replace("{", "\\{");
            builder.Replace("[", "\\[");
            builder.Replace("(", "\\(");
            builder.Replace(")", "\\)");
            builder.Replace("|", "\\|");
            builder.Replace("+", "\\+");
            builder.Replace("*", ".*");
            builder.Replace("?", ".");

            builder.Insert(0, "^");
            builder.Append("$");

            return builder.ToString();
        }
        private static IEnumerable<FileInfo> GetFiles(string pathPattern, bool recursive)
        {
            try
            {
                string dir = Path.GetDirectoryName(pathPattern);
                string filePattern = Path.GetFileName(pathPattern);

                if (dir == null) dir = Path.GetPathRoot(pathPattern);
                if (dir == "") dir = ".";

                if (string.IsNullOrWhiteSpace(filePattern))
                    throw new ArgumentException("FileName / Mask does not exists.");

                if (string.IsNullOrWhiteSpace(dir))
                    throw new ArgumentException("Directory is empty");

                var directory = new DirectoryInfo(dir);
                if (recursive)
                    return directory.GetFiles(filePattern, SearchOption.AllDirectories);

                return directory.GetFiles(filePattern, SearchOption.TopDirectoryOnly);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new ArgumentException("Access Denied: Unable to access the path specified", ex);
            }
            catch (IOException ex)
            {
                throw new ArgumentException("Invalid file path", ex);
            }
        }
        #endregion

        #region - Dot.Net Specific -
        private void AddProjectFile(string projectFile)
        {
            // do not process if there is no file mentioned
            if (string.IsNullOrWhiteSpace(projectFile)) return;

            // do not process if there is no file exists
            if (!File.Exists(projectFile)) return;

            string extension = Path.GetExtension(projectFile);
            // Delphi Project File
            if (HelperClass.IsDelphiProjectFile(extension))
            {
                TryLoadDelphiProject(projectFile);
                return;
            }

            // Delphi Project Group
            if (HelperClass.IsDelphiProjectGroupFile(extension))
            {
                TryLoadDelphiProjectGroup(projectFile);
                return;
            }

            var document = new XmlDocument();

            try
            {
                document.Load(projectFile);
            }
            catch (XmlException ex)
            {
                throw new ArgumentException("Project file '" + projectFile + "' is invalid and cannot be loaded.", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new ArgumentException("Project file '" + projectFile + "' cannot be accessed.", ex);
            }
            catch (IOException ex)
            {
                throw new ArgumentException("Project file '" + projectFile + "' is invalid or could not be found.", ex);
            }

            string dirPath = Path.GetDirectoryName(projectFile);

            try
            {
                // Delphi Studio Project
                if (HelperClass.IsDelphiStudioProjectFile(extension))
                {
                    TryLoadDelphiStudioProject(dirPath, document);
                    return;
                }
                if (TryLoadVs2005AndLaterProject(dirPath, document)) return;
                if (TryLoadVs2003Project(dirPath, document)) return;
                if (TryLoadVisualCppProject(dirPath, document)) return;
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Project file '" + projectFile + "' is in unsupported format.", ex);
            }

            throw new ArgumentException("Project file '" + projectFile + "' is in unsupported format.");
        }

        private void AddProjectFiles(string projectPath)
        {
            bool hasWildcard = (projectPath.Contains("*") || projectPath.Contains("?"));
            IEnumerable<FileInfo> files = GetFiles(projectPath, hasWildcard);

            foreach (FileInfo t in files)
            {
                AddProjectFile(t.FullName);
            }
        }
        
        private void AddSolutionFile(string solutionFile)
        {
            // Regex pattern to the project specifications
            const string regexPattern = @"Project\(""\{\w{8}-\w{4}-\w{4}-\w{4}-\w{12}\}""\)" +
                                        @" = ""[^""]+"", ""(?<file>[^""]+)"", ""\{\w{8}-\w{4}-\w{4}-\w{4}-\w{12}\}""";

            var regex = new Regex(regexPattern, RegexOptions.ExplicitCapture);
            string dirPath = Path.GetDirectoryName(solutionFile);
            if (string.IsNullOrWhiteSpace(dirPath)) dirPath = "";
            try
            {
                using (var reader = new StreamReader(solutionFile))
                {
                    while (!reader.EndOfStream)
                    {
                        // Read all lines through the file
                        string line = reader.ReadLine();
                        if (!line.IsNullOrEmptySpaces())
                        {
                            Match match = regex.Match(line);

                            if (match.Success)
                            {
                                // Read the project informations
                                Group fileGroup = match.Groups["file"];
                                string relPath = fileGroup.Value;

                                string projectPath = Path.Combine(dirPath, relPath);
                                string extension = Path.GetExtension(projectPath);

                                if (extension.In(".csproj", ".vbproj", ".vcproj", ".vjsproj"))
                                {
                                    AddProjectFile(projectPath);
                                }
                            }
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new ArgumentException("Solution file '" + solutionFile + "' cannot be accessed.", ex);
            }
            catch (IOException ex)
            {
                throw new ArgumentException("Solution file '" + solutionFile + "' is invalid or could not be found.", ex);
            }
        }

        private void AddSolutionFiles(string solutionPath)
        {
            bool hasWildcard = (solutionPath.Contains("*") || solutionPath.Contains("?"));
            IEnumerable<FileInfo> files = GetFiles(solutionPath, hasWildcard);

            foreach (FileInfo t in files)
            {
                AddSolutionFile(t.FullName);
            }
        }
        #endregion

        #region - Visual Studio Specific -
        private bool TryLoadVs2005AndLaterProject(string dirPath, XmlDocument document)
        {
            var manager = new XmlNamespaceManager(document.NameTable);
            manager.AddNamespace("p", "http://schemas.microsoft.com/developer/msbuild/2003");

            // Get the project name node
            XmlNode nameNode = document.SelectSingleNode("/p:Project/p:PropertyGroup/p:AssemblyName", manager);
            if (nameNode == null) return false;

            // Read the project name
            string projectName = nameNode.InnerText;
            if (string.IsNullOrWhiteSpace(projectName)) return false;

            Project project = _projects.AddProject(projectName);

            // Get the source files
            XmlNodeList nodes = document.SelectNodes("/p:Project/p:ItemGroup/p:Compile[@Include]", manager);
            if (nodes != null)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    string relPath = ((XmlElement)nodes[i]).GetAttribute("Include");
                    string filePath = Path.Combine(dirPath, relPath);

                    var file = new SourceFile(filePath);
                    _projects.AddFile(file, project);
                }
            }
            return true;
        }
        private bool TryLoadVs2003Project(string dirPath, XmlDocument document)
        {
            // Get the project name node
            XmlNode nameNode = document.SelectSingleNode("/VisualStudioProject/*/Build/Settings/@AssemblyName");
            if (nameNode == null) return false;

            // Read the project name
            string projectName = nameNode.InnerText;
            if (string.IsNullOrWhiteSpace(projectName)) return false;

            
            // Get the source files
            XmlNodeList nodes = document.SelectNodes("/VisualStudioProject/*/Files/Include/File[@RelPath][@BuildAction='Compile']");
            if (nodes != null)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    string relPath = ((XmlElement)nodes[i]).GetAttribute("RelPath");
                    string filePath = Path.Combine(dirPath, relPath);

                    var file = new SourceFile(filePath);
                    _projects.AddFile(file, projectName);
                }
            }
            return true;
        }
        private bool TryLoadVisualCppProject(string dirPath, XmlDocument document)
        {
            // Get the project name node
            XmlNode nameNode = document.SelectSingleNode("/VisualStudioProject/@Name");
            if (nameNode == null) return false;

            // Read the project name
            string projectName = nameNode.InnerText;
            if (string.IsNullOrWhiteSpace(projectName)) return false;
            

            // Get the source files
            XmlNodeList nodes = document.SelectNodes("/VisualStudioProject/Files//File/@RelativePath");
            if (nodes != null)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    string relPath = nodes[i].InnerText;
                    string filePath = Path.Combine(dirPath, relPath);
                    string extension = Path.GetExtension(filePath);

                    if (HelperClass.IsValidExtension(extension))
                    {
                        var file = new SourceFile(filePath);
                        _projects.AddFile(file, projectName);
                    }
                }
            }
            return true;
        }
        #endregion

        #region - Delphi Specific -
        private void TryLoadDelphiProject(string projectPath)
        {
            #region - Help Steps -
            // Load projects from ".dpr"
            // Steps involved in populating units from project file
            // 1. Look for line starts with "program" next word is project name
            // 2. Skip any line that starts with "{$", its of no use
            // 3. Seek for line starts with "uses", next word (if any) then its fileNames
            // 4. Try to read line that has ".pas'" and seek front for matching "\'"
            // 5. if line starts with begin / end. then we are done. - No need to process further

            #endregion

            #region -: Initial Validations :-
            string fileName = Path.GetFileName(projectPath);
            if (string.IsNullOrWhiteSpace(fileName)) return;

            string fileExt = Path.GetExtension(fileName);
            if (string.IsNullOrWhiteSpace(fileExt) || fileExt != ".dpr") return;

            string dirPath = Path.GetDirectoryName(projectPath);
            if (string.IsNullOrWhiteSpace(dirPath)) return;

            #endregion

            var unitFiles = new List<string>();
            try
            {
                string projectName = fileName;

                #region -: Using StreamReader :-
                using (var reader = new StreamReader(projectPath))
                {
                    while (!reader.EndOfStream)
                    {
                        // Read all lines through the file
                        string line = reader.ReadLine();

                        #region -: Valid Line :-
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            line = line.Trim();

                            if (line.StartsWith("begin") || line.StartsWith("end.") ||
                                line.StartsWith("{") || line.StartsWith("//") || line.StartsWith("("))
                            {
                                continue;
                            }

                            if (line.StartsWith("program"))
                            {
                                projectName = line.Substring(7, line.Length - 8).Trim();
                            }
                            #region -: Read Unit Locations :-
                            if (line.Contains(".pas"))
                            {
                                line = line.Replace('\'', ' ').Trim();
                                // Read the unit informations
                                string[] units = line.Split(' ');
                                unitFiles.AddRange(units.Where(unit => unit.EndsWith(".pas")));
                            }
                            #endregion// end of read units
                        }
                        #endregion // end of if line not empty
                    } // end of while readstream
                }
                #endregion // end of using readerstream

                foreach (var unitFile in unitFiles)
                {
                    fileName = Path.Combine(dirPath, unitFile);
                    AddFile(fileName, projectName);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new ArgumentException("Delphi Project file '" + projectPath + "' cannot be accessed.", ex);
            }
            catch (IOException ex)
            {
                throw new ArgumentException("Delphi Project file '" + projectPath + "' is invalid or could not be found.", ex);
            }
        }
        private void TryLoadDelphiProjectGroup(string projectPath)
        {
            #region - Help Steps -
            // Load projects from ".bpg"
            // Steps involved in populating projects from project group
            // 1. Look for line starts with "PROJECTS =" 
            // 2. Create a project for each word after the first step until we find the line starts with "#----"
            // 3. Make sure to check "\" at the end of the string, if found delete before loading into projects
            // 4. Once all the project names loaded, call TryLoadDelphiProject for each item
            #endregion

            #region -: Initial Validations :-
            string fileName = Path.GetFileName(projectPath);
            if (string.IsNullOrWhiteSpace(fileName)) return;

            string fileExt = Path.GetExtension(fileName);
            if (string.IsNullOrWhiteSpace(fileExt) || fileExt != ".bpg") return;

            string dirPath = Path.GetDirectoryName(projectPath);
            if (string.IsNullOrWhiteSpace(dirPath)) return;

            #endregion

            var projectNames = new List<string>();
            try
            {
                bool projectsFound = false;
                bool readProjects = false;

                #region -: Using StreamReader :-
                using (var reader = new StreamReader(projectPath))
                {
                    while (!reader.EndOfStream)
                    {
                        // Read all lines through the file
                        string line = reader.ReadLine();

                        #region -: Valid Line :-
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            line = line.Trim();

                            if (line.StartsWith("#"))
                            {
                                if (projectsFound)
                                {
                                    projectsFound = false;
                                    readProjects = true;
                                }
                                continue;
                            }

                            if (line.StartsWith("PROJECTS ="))
                            {
                                projectsFound = true;
                                // delete projects= from line
                                line = line.Substring(10).Trim();
                            }

                            if (line.EndsWith("\\")) line = line.Replace('\\', ' ').Trim();

                            if (projectsFound)
                            {
                                // Read the project informations
                                string[] proj = line.Split(' ');
                                projectNames.AddRange(proj);
                                projectNames.Sort();
                            }

                            #region -: Read Project Locations :-
                            if (readProjects)
                            {
                                if (line.StartsWith("$")) continue;
                                foreach (var project in projectNames)
                                {
                                    if (line.StartsWith(project))
                                    {
                                        // Sample line format will be "ProjectName.dpr: \src\ProjectName\ProjectName.dpr"
                                        fileName = line.Substring(project.Length + 1).Trim(); // +1 for ":" after filename

                                        fileName = Path.Combine(dirPath, fileName);
                                        fileExt = Path.GetExtension(fileName);

                                        if (fileExt == ".dpr")
                                        {
                                            TryLoadDelphiProject(fileName);
                                        }
                                    }
                                } // end foreach project
                            }
                            #endregion// end of read projects
                        }
                        #endregion // end of if line not empty
                    } // end of while readstream
                }
                #endregion // end of using readerstream
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new ArgumentException("Delphi ProjectGroup file '" + projectPath + "' cannot be accessed.", ex);
            }
            catch (IOException ex)
            {
                throw new ArgumentException("Delphi ProjectGroup file '" + projectPath + "' is invalid or could not be found.", ex);
            }
        }
        private void TryLoadDelphiStudioProject(string dirPath, XmlDocument document)
        {
            var manager = new XmlNamespaceManager(document.NameTable);
            manager.AddNamespace("p", "http://schemas.microsoft.com/developer/msbuild/2003");

            // Get the project name node
            XmlNode nameNode = document.SelectSingleNode("/p:Project/p:PropertyGroup/p:MainSource", manager);
            if (nameNode == null) return;

            // Read the project name
            string projectName = nameNode.InnerText;
            if (string.IsNullOrWhiteSpace(projectName)) return;

            Project project = _projects.AddProject(projectName);

            // Get the source files
            XmlNodeList nodes = document.SelectNodes("/p:Project/p:ItemGroup/p:DCCReference[@Include]", manager);
            if (nodes != null)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    string relPath = ((XmlElement)nodes[i]).GetAttribute("Include");
                    string filePath = Path.Combine(dirPath, relPath);

                    var file = new SourceFile(filePath);
                    _projects.AddFile(file, project);
                }
            }
        }

        #endregion

        #region - Public Declarations -
        public IProjects Projects
        {
            get { return _projects; }
        }

        public int FileCount
        {
            get { return _projects.FilesCount; }
        }

        public SourceResult Report
        {
            get { return _report; }
            set { _report = value; }
        }

        public void Clear()
        {
            _projects.Clear();
            _excludePatterns.Clear();
            _report = null;
        }
        /*
        public void AddFile(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException("filePath");

            AddFile(filePath, DefaultProject);
        }*/
        public void AddFile(string filePath, string projectName)
        {
            if (filePath == null) return;

            Project targetProject = _projects.AddProject(projectName);
            AddFile(filePath, targetProject);
        }

        public void AddFile(string filePath, Project targetProject)
        {
            bool hasWildcard = (filePath.Contains("*") || filePath.Contains("?"));

            if (hasWildcard)
            {
                AddFiles(filePath, true, targetProject);
            }
            else
            {
                string extension = Path.GetExtension(filePath);
                if (string.IsNullOrWhiteSpace(extension)) return;

                if (HelperClass.IsValidExtension(extension) && File.Exists(filePath))
                {
                    var file = new SourceFile(filePath);
                    _projects.AddFile(file, targetProject);
                }
            }
        }

        private void AddFiles(string path, bool recursive, Project targetProject)
        {
            IEnumerable<FileInfo> files = GetFiles(path, recursive);

            foreach (FileInfo t in files)
            {
                if (!HelperClass.IsValidExtension(t.Extension)) continue;
                var file = new SourceFile(t.FullName);
                _projects.AddFile(file, targetProject);
            }
        }

        public void AddFilesRecursively(string path)
        {
            if (path == null) return;
            AddFiles(path, true, _projects.AddProject(string.Empty));
        }

        public void AddFilesRecursively(string path, string projectName)
        {
            if (path == null) return;

            Project targetProject = _projects.AddProject(projectName);
            AddFiles(path, true, targetProject);
        }
        public void AddSolution(string solutionPath)
        {
            bool hasWildcard = (solutionPath.Contains("*") || solutionPath.Contains("?"));

            if (hasWildcard)
                AddSolutionFiles(solutionPath);
            else
                AddSolutionFile(solutionPath);
        }
        public void AddExludePattern(string pattern)
        {
            if (!string.IsNullOrEmpty(pattern) && !_excludePatterns.Contains(pattern))
                _excludePatterns.Add(pattern);
        }
        public void AddProject(string projectPath)
        {
            bool hasWildcard = (projectPath.Contains("*") || projectPath.Contains("?"));

            if (hasWildcard)
                AddProjectFiles(projectPath);
            else
                AddProjectFile(projectPath);
        }
        public void ValidateExcludePatterns()
        {
            foreach (string t in _excludePatterns)
            {
                string regexPattern = GetRegexPattern(t);

                // On Windows the file names are incase-sensitive
                Regex pattern = SourceFile.IgnoreCase ? new Regex(regexPattern, RegexOptions.IgnoreCase) : new Regex(regexPattern);

                // Remove files from every project that are matching the pattern
                foreach (Project project in _projects.Items)
                {
                    project.ExcludeFiles(pattern);
                }
            }
        }

        public string GetAsXml()
        {
            return _projects.ToXml();
        }
        
        #endregion

        #region - Public Overrides -
        public override string ToString()
        {
            if (_report != null)
                return FileCount + " file(s); " + _report;

            return FileCount + " file(s)";
        }
        #endregion
    }
}
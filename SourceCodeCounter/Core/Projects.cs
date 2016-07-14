using System;
using System.Collections.Generic;
using System.Linq;
using SourceCodeCounter.Interfaces;

namespace SourceCodeCounter.Core
{
    public class Projects : IProjects
    {
        #region - Private Declarations -
        static readonly Project DefaultProject = new Project("Instance Project");
        private List<Project> _projects;
        #endregion

        #region - Constuctor -
        public Projects()
        {
            _projects = new List<Project>();
        }
        #endregion

        #region - Published Properties -
        public IList<Project> Items { get { return _projects; } }
        public int Count { get { return _projects.Count; } }
        public int FilesCount { get { return _projects.Sum(x => x.FileCount); } }
        public int TotalLines
        {
            get { return _projects.Sum(x => x.TotalLines); }
        }

        public int Comments
        {
            get { return _projects.Sum(x => x.Comments); }
        }

        public int CodeLines
        {
            get { return _projects.Sum(x => x.CodeLines); }
        }

        public int BlankLines
        {
            get { return _projects.Sum(x => x.BlankLines); }
        }

        public void Sort()
        {
            _projects.Sort(delegate(Project x, Project y)
            {
                if (x.Name == null && y.Name == null) return 0;
                if (x.Name == null) return -1;
                if (y.Name == null) return 1;
                return String.Compare(x.Name, y.Name, StringComparison.Ordinal);
            });
            
        }
        #endregion

        #region - File Specific Methods -
        
        public void AddFile(SourceFile file, Project targetProject)
        {
            // Check whether file is already assigned to a named project
            if (targetProject == null) targetProject = AddProject(string.Empty);
            foreach (Project project in _projects)
            {
                SourceFile newFile = project.Find(file);

                // If file has been added before
                if (newFile == null) continue;

                // Check whether file is in defaultProject
                if ((Equals(project, DefaultProject)) && (!Equals(targetProject, DefaultProject)))
                {
                    DefaultProject.Remove(file);
                    targetProject.AddFile(file);
                }
                return;
            }

            if (DefaultProject.Contains(file))
            {
                // file already in list
                return;
            }
            // this file is new, so lets add
            targetProject.AddFile(file);
        }

        public void AddFile(SourceFile file, string projectName)
        {
            Project project = AddProject(projectName);
            AddFile(file, project);
        }

        #endregion

        #region - Project Specific Methods -
        public Project FindProject(string projectName)
        {
            return _projects.FirstOrDefault(project => project.Name == projectName);
        }

        public Project AddProject(string projectName)
        {
            if (String.IsNullOrWhiteSpace(projectName)) projectName = "Instance Project";

            Project project = FindProject(projectName);
            if (project == null)
            {
                project = new Project(projectName);
                _projects.Add(project);
            }

            return project;
        }

        public void RemoveProject(string projectName)
        {
            if (String.IsNullOrWhiteSpace(projectName)) projectName = "Instance Project";
            Project project = FindProject(projectName);
            if (project != null)
            {
                _projects.Remove(project);
            }
        }

        public void Clear()
        {
            _projects.Clear();
        }
        #endregion
    }
}
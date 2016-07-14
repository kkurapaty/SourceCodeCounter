using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SourceCodeCounter.GUI;
using SourceCodeCounter.Interfaces;
using SourceCodeCounter.Parsers;
using SourceCodeCounter.Properties;

namespace SourceCodeCounter.Common
{
    public static class HelperClass
    {
        #region - Static Declarations -

        private static readonly string[] ValidSourceExtensions =
        {
            ".p", ".pp", // Pascal
            ".pas", // Delphi
            ".c", ".cpp", ".h", ".hpp", ".cc", ".hh", ".cxx", ".hxx", // C, C++
            ".cs", // C#    
            ".java", // Java
            ".vb", ".bas", ".cls", ".frm", // VB, .Net
            ".sql" // SQL
        };

        private static readonly string[] ValidProjectFileExtensions =
        {
            ".dpr", ".bpg", ".dproj", // Delphi
            ".csproj", // C#.Net
            ".vbproj", // Visual Basic
            ".vcproj", // Visual C++
            ".vjsproj" // Visual Java
        };

        #endregion

        public static bool IsValidExtension(string extension)
        {
            return !string.IsNullOrEmpty(extension) && extension.In(ValidSourceExtensions);
        }

        public static bool IsSqlSourceFile(string extension)
        {
            return !extension.IsNullOrEmptySpaces() && extension.In(".sql");
        }

        public static bool IsDotNetSolutionFile(string extension)
        {
            if (extension == null) return false;
            return extension.In(".sln");
        }

        public static bool IsValidProjectFile(string fileExtension)
        {
            if (fileExtension == null) return false;
            return fileExtension.In(ValidProjectFileExtensions);
        }

        public static bool IsDelphiProjectFile(string extension)
        {
            return extension != null && extension.In(".dpr");
        }

        public static bool IsDelphiProjectGroupFile(string extension)
        {
            if (extension == null) return false;
            return extension.In(".bpg");
        }

        public static bool IsDelphiStudioProjectFile(string extension)
        {
            return extension != null && extension.In(".dproj");
        }

        public static bool IsValidFileType(string extension)
        {
            return ((IsValidExtension(extension)) ||
                    (IsValidProjectFile(extension)) ||
                    (IsDotNetSolutionFile(extension))
                );
        }

        public static bool IsWildcardExtension(string extension)
        {
            return (extension.Contains("*") || extension.Contains("?"));
        }

        public static bool ShowProjectSelection(string caption, ref string name, ref string filePath, ref bool include)
        {
            var dlg = new ProjectSelectionDialog(caption, name, filePath, include);
            DialogResult dialogResult = dlg.ShowDialog();
            bool retVal = false;
            if (dialogResult == DialogResult.OK)
            {
                name = dlg.Title;
                filePath = dlg.FilePath;
                include = dlg.IncludeSubDir;
                retVal = true;
            }
            dlg.Dispose();
            return retVal;
        }

        #region - Dialog Handlers -

        public static void ShowAboutDialog()
        {
            var dlg = new AboutDlg();
            dlg.ShowDialog();
            dlg.Dispose();
        }

        public static void ShowScanDialog(ITaskArguments taskArguments)
        {
            var infoDlg = new SourceInfoDlg(taskArguments);
            infoDlg.ShowDialog();
            infoDlg.Dispose();
        }

        #endregion

        #region - Chart Methods -

        public static void SaveChart(Chart chart)
        {
            // Create a new save file dialog
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = Resources.Resource_ChartFileSaveFormat,
                FilterIndex = 2,
                RestoreDirectory = true
            };

            // Sets the current file name filter string, which determines the choices that appear in 
            // the "Save as file type" or "Files of type" box in the dialog box.
            try
            {
                // Set image file format
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var format = ChartImageFormat.Bmp;

                    if (saveFileDialog1.FileName.EndsWith("bmp"))
                    {
                        format = ChartImageFormat.Bmp;
                    }
                    else if (saveFileDialog1.FileName.EndsWith("jpg"))
                    {
                        format = ChartImageFormat.Jpeg;
                    }
                    else if (saveFileDialog1.FileName.EndsWith("emf") && saveFileDialog1.FilterIndex == 3)
                    {
                        format = ChartImageFormat.EmfDual;
                    }
                    else if (saveFileDialog1.FileName.EndsWith("emf") && saveFileDialog1.FilterIndex == 4)
                    {
                        format = ChartImageFormat.EmfPlus;
                    }
                    else if (saveFileDialog1.FileName.EndsWith("emf"))
                    {
                        format = ChartImageFormat.Emf;
                    }
                    else if (saveFileDialog1.FileName.EndsWith("gif"))
                    {
                        format = ChartImageFormat.Gif;
                    }
                    else if (saveFileDialog1.FileName.EndsWith("png"))
                    {
                        format = ChartImageFormat.Png;
                    }
                    else if (saveFileDialog1.FileName.EndsWith("tif"))
                    {
                        format = ChartImageFormat.Tiff;
                    }

                    // Save image
                    chart.SaveImage(saveFileDialog1.FileName, format);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CopyChartToClipboard(Chart chart)
        {
            try
            {
                var stream = new MemoryStream();
                chart.SaveImage(stream, ChartImageFormat.Bmp);
                var bmp = new Bitmap(stream);
                Clipboard.SetDataObject(bmp);
                MessageBox.Show(Resources.Resource_ChartCopiedToClipboard, Resources.Resource_Clipboard,
                    MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
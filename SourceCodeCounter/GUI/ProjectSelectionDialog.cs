using System;
using System.IO;
using System.Windows.Forms;
using SourceCodeCounter.Common;

namespace SourceCodeCounter.GUI
{
    public partial class ProjectSelectionDialog : Form
    {
        #region - Constructor -
        public ProjectSelectionDialog()
        {
            InitializeComponent();
        }

        public ProjectSelectionDialog(string caption, string name, string filePath, bool include):this()
        {
            Text = string.Format("{0} Project Selection", caption);
            tbProjectPath.Text = filePath;
            tbProjectTitle.Text = name;
            chkIncludeSubDir.CheckState = include ? CheckState.Checked : CheckState.Unchecked;
            SetProjectType();
        }
        #endregion

        #region - Public Properties -
        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        public string Title { get { return tbProjectTitle.Text; } set { tbProjectTitle.Text = value; } }
        public string FilePath { get { return tbProjectPath.Text; } set { tbProjectPath.Text = value; } }
        public bool IncludeSubDir { get { return chkIncludeSubDir.CheckState == CheckState.Checked; } set { chkIncludeSubDir.CheckState = value ? CheckState.Checked : CheckState.Unchecked; } }

        public string ProjectType
        {
            get { return cbProjectType.Text; }
            set { cbProjectType.Text = value; }
        }
        #endregion

        #region - Form Event Handlers -

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!IsValid()) return; 
            DialogResult = DialogResult.OK;
        }
        
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (!tbProjectPath.Text.IsNullOrEmptySpaces())
            {
                openFileDlg.InitialDirectory = Path.GetDirectoryName(tbProjectPath.Text);
                openFileDlg.FileName = Path.GetFileName(tbProjectPath.Text);
            }
            else
            {
                openFileDlg.InitialDirectory = @"C:\";
            }

            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                tbProjectPath.Text = openFileDlg.FileName;
            }
        }
        #endregion

        #region - Private Methods -

        private void tbProjectPath_Leave(object sender, EventArgs e)
        {
            SetProjectType();
        }

        private void SetProjectType()
        {
            int itemIndex = 0; //: <User defined>
            string fileExt = Path.GetExtension(tbProjectPath.Text.Trim());
            if (!string.IsNullOrEmpty(fileExt))
            {
                if (HelperClass.IsValidProjectFile(fileExt)) itemIndex = 1; // Project File
                if (HelperClass.IsDotNetSolutionFile(fileExt)) itemIndex = 2; // Solution File
                if (HelperClass.IsValidExtension(fileExt)) itemIndex = 3; // Source File
                if (HelperClass.IsSqlSourceFile(fileExt)) itemIndex = 4;    // SQL File
                if (HelperClass.IsWildcardExtension(fileExt)) itemIndex = 5; // Wildcard File
            }
            cbProjectType.SelectedIndex = itemIndex;
        }

        private bool IsValid()
        {
            bool bAllOk = true;
            String mesg = String.Empty;
            errorProvider.Clear();
            if (string.IsNullOrWhiteSpace(tbProjectTitle.Text))
            {
                errorProvider.SetError(tbProjectTitle, "Please enter valid project name");
                bAllOk = false;
            }

            if (string.IsNullOrWhiteSpace(tbProjectPath.Text))
            {
                mesg = "Please enter valid project or file path";
                bAllOk = false;
            }
            else
            {
                string filePath = tbProjectPath.Text.Trim();
                string fileExt = Path.GetExtension(filePath);

                if (string.IsNullOrWhiteSpace(fileExt))
                {
                    mesg = "Please provide valid file extension.";
                    bAllOk = false;
                }

                bool hasWildcard = (filePath.Contains("*") || filePath.Contains("?"));
                if ((!HelperClass.IsValidFileType(fileExt)) && (!hasWildcard))
                {
                   mesg = "Please provide valid file type or wildcard at the end of project location.";
                   bAllOk = false;
                }

                filePath = Path.GetDirectoryName(filePath);
                if ((string.IsNullOrEmpty(filePath)) || (!Directory.Exists(filePath)))
                {
                    mesg = "Invalid directory or file location. Please make sure it exits.";
                    bAllOk = false;
                }
            }
            errorProvider.SetError(tbProjectPath, mesg);
            return bAllOk;
        }

        #endregion
    }
}

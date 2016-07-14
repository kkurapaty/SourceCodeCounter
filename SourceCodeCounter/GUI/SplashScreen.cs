using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using SourceCodeCounter.Properties;

namespace SourceCodeCounter.GUI
{
    public partial class SplashScreen : Form
    {
        public bool IsMinimized = false;

        public SplashScreen()
        {
            InitializeComponent();

            // Start Tasks here...
            tasksLabel.Text = Resources.Resource_PleaseWaitStarting;
            Thread.Sleep(1000);

            // start timer
            splashTimer.Start();
        }

        // Close Application
        private void closeLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Minimize Application 
        private void minimizeLabel_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            IsMinimized = true;
        }

        //Mouse hover and leave effects 
        private void closeLabel_MouseHover(object sender, EventArgs e)
        {
            closeLabel.ForeColor = Color.Silver;
        }

        private void closeLabel_MouseLeave(object sender, EventArgs e)
        {
            closeLabel.ForeColor = Color.White;
        }

        private void minimizeLabel_MouseHover(object sender, EventArgs e)
        {
            minimizeLabel.ForeColor = Color.Silver;
        }

        private void minimizeLabel_MouseLeave(object sender, EventArgs e)
        {
            minimizeLabel.ForeColor = Color.White;
        }

        //Show MainForm(MainForm) 
        public void ShowMainFormProc()
        {
            Application.Run(new MainForm
            {
                WindowState = IsMinimized ? FormWindowState.Minimized : FormWindowState.Normal
            });
        }

        private void splashTimer_Tick(object sender, EventArgs e)
        {
            splashTimer.Stop();

            var newThread = new Thread(ShowMainFormProc);

            newThread.SetApartmentState(ApartmentState.STA);
            newThread.Start();
            Thread.Sleep(500);
            Close();
        }

        private void SplashScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
        }


        private void SplashScreen_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void SplashScreen_MouseDown(object sender, MouseEventArgs e)
        {
        }
    }
}

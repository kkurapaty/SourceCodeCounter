namespace SourceCodeCounter.GUI
{
    partial class SplashScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.appMiniLabel = new System.Windows.Forms.Label();
            this.bigAppLabel = new System.Windows.Forms.Label();
            this.tasksLabel = new System.Windows.Forms.Label();
            this.closeLabel = new System.Windows.Forms.Label();
            this.minimizeLabel = new System.Windows.Forms.Label();
            this.splashTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // appMiniLabel
            // 
            this.appMiniLabel.AutoSize = true;
            this.appMiniLabel.BackColor = System.Drawing.Color.Transparent;
            this.appMiniLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appMiniLabel.ForeColor = System.Drawing.Color.White;
            this.appMiniLabel.Location = new System.Drawing.Point(30, 5);
            this.appMiniLabel.Name = "appMiniLabel";
            this.appMiniLabel.Size = new System.Drawing.Size(100, 17);
            this.appMiniLabel.TabIndex = 0;
            this.appMiniLabel.Text = "Morgan Stanley";
            // 
            // bigAppLabel
            // 
            this.bigAppLabel.AutoSize = true;
            this.bigAppLabel.BackColor = System.Drawing.Color.Transparent;
            this.bigAppLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bigAppLabel.ForeColor = System.Drawing.Color.LavenderBlush;
            this.bigAppLabel.Location = new System.Drawing.Point(26, 85);
            this.bigAppLabel.Name = "bigAppLabel";
            this.bigAppLabel.Size = new System.Drawing.Size(378, 50);
            this.bigAppLabel.TabIndex = 1;
            this.bigAppLabel.Text = "Source Code Scanner";
            // 
            // tasksLabel
            // 
            this.tasksLabel.AutoSize = true;
            this.tasksLabel.BackColor = System.Drawing.Color.Transparent;
            this.tasksLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tasksLabel.ForeColor = System.Drawing.Color.White;
            this.tasksLabel.Location = new System.Drawing.Point(12, 208);
            this.tasksLabel.Name = "tasksLabel";
            this.tasksLabel.Size = new System.Drawing.Size(163, 21);
            this.tasksLabel.TabIndex = 2;
            this.tasksLabel.Text = "Starting, Please wait ...";
            // 
            // closeLabel
            // 
            this.closeLabel.AutoSize = true;
            this.closeLabel.BackColor = System.Drawing.Color.Transparent;
            this.closeLabel.Font = new System.Drawing.Font("Webdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.closeLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.closeLabel.Location = new System.Drawing.Point(408, 4);
            this.closeLabel.Name = "closeLabel";
            this.closeLabel.Size = new System.Drawing.Size(25, 19);
            this.closeLabel.TabIndex = 3;
            this.closeLabel.Text = "r";
            this.closeLabel.Click += new System.EventHandler(this.closeLabel_Click);
            this.closeLabel.MouseLeave += new System.EventHandler(this.closeLabel_MouseLeave);
            this.closeLabel.MouseHover += new System.EventHandler(this.closeLabel_MouseHover);
            // 
            // minimizeLabel
            // 
            this.minimizeLabel.AutoSize = true;
            this.minimizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.minimizeLabel.Font = new System.Drawing.Font("Webdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.minimizeLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.minimizeLabel.Location = new System.Drawing.Point(373, 2);
            this.minimizeLabel.Name = "minimizeLabel";
            this.minimizeLabel.Size = new System.Drawing.Size(25, 19);
            this.minimizeLabel.TabIndex = 4;
            this.minimizeLabel.Text = "0";
            this.minimizeLabel.Click += new System.EventHandler(this.minimizeLabel_Click);
            this.minimizeLabel.MouseLeave += new System.EventHandler(this.minimizeLabel_MouseLeave);
            this.minimizeLabel.MouseHover += new System.EventHandler(this.minimizeLabel_MouseHover);
            // 
            // splashTimer
            // 
            this.splashTimer.Interval = 1600;
            this.splashTimer.Tick += new System.EventHandler(this.splashTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "T";
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(439, 248);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.minimizeLabel);
            this.Controls.Add(this.closeLabel);
            this.Controls.Add(this.tasksLabel);
            this.Controls.Add(this.bigAppLabel);
            this.Controls.Add(this.appMiniLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(439, 248);
            this.MinimumSize = new System.Drawing.Size(439, 248);
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash Screen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SplashScreen_FormClosed);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SplashScreen_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SplashScreen_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label appMiniLabel;
        private System.Windows.Forms.Label bigAppLabel;
        private System.Windows.Forms.Label tasksLabel;
        private System.Windows.Forms.Label closeLabel;
        private System.Windows.Forms.Label minimizeLabel;
        private System.Windows.Forms.Timer splashTimer;
        private System.Windows.Forms.Label label1; 
    }
}
namespace SourceCodeCounter.GUI.Contols
{
    partial class ProjectControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.pnlProjectChartOptions = new System.Windows.Forms.Panel();
            this.checkBoxShowMargin = new System.Windows.Forms.CheckBox();
            this.btnRefreshProjectChart = new System.Windows.Forms.Button();
            this.btnCopyProjectChart = new System.Windows.Forms.Button();
            this.btnSaveProjectChart = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbProjectPieDrawingStyle = new System.Windows.Forms.ComboBox();
            this.checkProjectRotate = new System.Windows.Forms.CheckBox();
            this.checkProject3D = new System.Windows.Forms.CheckBox();
            this.cbProjectRadius = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkProjectShowLegend = new System.Windows.Forms.CheckBox();
            this.cbProjectExploded = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbProjectLabelStyle = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbProjectChartType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.projectChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gbOptions.SuspendLayout();
            this.pnlProjectChartOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectChart)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gbOptions);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.projectChart);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Size = new System.Drawing.Size(656, 345);
            this.splitContainer2.SplitterDistance = 281;
            this.splitContainer2.TabIndex = 1;
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.pnlProjectChartOptions);
            this.gbOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOptions.Location = new System.Drawing.Point(0, 0);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(281, 345);
            this.gbOptions.TabIndex = 0;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Options";
            // 
            // pnlProjectChartOptions
            // 
            this.pnlProjectChartOptions.Controls.Add(this.checkBoxShowMargin);
            this.pnlProjectChartOptions.Controls.Add(this.btnRefreshProjectChart);
            this.pnlProjectChartOptions.Controls.Add(this.btnCopyProjectChart);
            this.pnlProjectChartOptions.Controls.Add(this.btnSaveProjectChart);
            this.pnlProjectChartOptions.Controls.Add(this.label6);
            this.pnlProjectChartOptions.Controls.Add(this.cbProjectPieDrawingStyle);
            this.pnlProjectChartOptions.Controls.Add(this.checkProjectRotate);
            this.pnlProjectChartOptions.Controls.Add(this.checkProject3D);
            this.pnlProjectChartOptions.Controls.Add(this.cbProjectRadius);
            this.pnlProjectChartOptions.Controls.Add(this.label4);
            this.pnlProjectChartOptions.Controls.Add(this.checkProjectShowLegend);
            this.pnlProjectChartOptions.Controls.Add(this.cbProjectExploded);
            this.pnlProjectChartOptions.Controls.Add(this.label5);
            this.pnlProjectChartOptions.Controls.Add(this.cbProjectLabelStyle);
            this.pnlProjectChartOptions.Controls.Add(this.label7);
            this.pnlProjectChartOptions.Controls.Add(this.cbProjectChartType);
            this.pnlProjectChartOptions.Controls.Add(this.label8);
            this.pnlProjectChartOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProjectChartOptions.Location = new System.Drawing.Point(3, 18);
            this.pnlProjectChartOptions.Name = "pnlProjectChartOptions";
            this.pnlProjectChartOptions.Size = new System.Drawing.Size(275, 324);
            this.pnlProjectChartOptions.TabIndex = 5;
            // 
            // checkBoxShowMargin
            // 
            this.checkBoxShowMargin.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxShowMargin.Checked = true;
            this.checkBoxShowMargin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowMargin.Location = new System.Drawing.Point(18, 227);
            this.checkBoxShowMargin.Name = "checkBoxShowMargin";
            this.checkBoxShowMargin.Size = new System.Drawing.Size(134, 24);
            this.checkBoxShowMargin.TabIndex = 21;
            this.checkBoxShowMargin.Text = "Show X Axis &Margin:";
            this.checkBoxShowMargin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxShowMargin.CheckedChanged += new System.EventHandler(this.ProjectChartTypeChanged_Click);
            // 
            // btnRefreshProjectChart
            // 
            this.btnRefreshProjectChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefreshProjectChart.Location = new System.Drawing.Point(15, 285);
            this.btnRefreshProjectChart.Name = "btnRefreshProjectChart";
            this.btnRefreshProjectChart.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshProjectChart.TabIndex = 20;
            this.btnRefreshProjectChart.Text = "Refresh";
            this.btnRefreshProjectChart.UseVisualStyleBackColor = true;
            this.btnRefreshProjectChart.Click += new System.EventHandler(this.btnRefreshProjectChart_Click);
            // 
            // btnCopyProjectChart
            // 
            this.btnCopyProjectChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopyProjectChart.Location = new System.Drawing.Point(171, 285);
            this.btnCopyProjectChart.Name = "btnCopyProjectChart";
            this.btnCopyProjectChart.Size = new System.Drawing.Size(75, 23);
            this.btnCopyProjectChart.TabIndex = 16;
            this.btnCopyProjectChart.Text = "Copy";
            this.btnCopyProjectChart.UseVisualStyleBackColor = true;
            this.btnCopyProjectChart.Click += new System.EventHandler(this.btnCopyProjectChart_Click);
            // 
            // btnSaveProjectChart
            // 
            this.btnSaveProjectChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveProjectChart.Location = new System.Drawing.Point(93, 285);
            this.btnSaveProjectChart.Name = "btnSaveProjectChart";
            this.btnSaveProjectChart.Size = new System.Drawing.Size(75, 23);
            this.btnSaveProjectChart.TabIndex = 15;
            this.btnSaveProjectChart.Text = "Save As";
            this.btnSaveProjectChart.UseVisualStyleBackColor = true;
            this.btnSaveProjectChart.Click += new System.EventHandler(this.btnSaveProjectChart_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(50, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "&Drawing Style:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbProjectPieDrawingStyle
            // 
            this.cbProjectPieDrawingStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProjectPieDrawingStyle.Items.AddRange(new object[] {
            "Default",
            "SoftEdge",
            "Concave"});
            this.cbProjectPieDrawingStyle.Location = new System.Drawing.Point(140, 116);
            this.cbProjectPieDrawingStyle.Name = "cbProjectPieDrawingStyle";
            this.cbProjectPieDrawingStyle.Size = new System.Drawing.Size(112, 21);
            this.cbProjectPieDrawingStyle.TabIndex = 13;
            this.cbProjectPieDrawingStyle.SelectedIndexChanged += new System.EventHandler(this.ProjectChartTypeChanged_Click);
            // 
            // checkProjectRotate
            // 
            this.checkProjectRotate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkProjectRotate.Location = new System.Drawing.Point(13, 168);
            this.checkProjectRotate.Name = "checkProjectRotate";
            this.checkProjectRotate.Size = new System.Drawing.Size(138, 24);
            this.checkProjectRotate.TabIndex = 12;
            this.checkProjectRotate.Text = "Rotate C&hart:";
            this.checkProjectRotate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkProjectRotate.CheckedChanged += new System.EventHandler(this.ProjectChartTypeChanged_Click);
            // 
            // checkProject3D
            // 
            this.checkProject3D.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkProject3D.Location = new System.Drawing.Point(13, 197);
            this.checkProject3D.Name = "checkProject3D";
            this.checkProject3D.Size = new System.Drawing.Size(138, 24);
            this.checkProject3D.TabIndex = 11;
            this.checkProject3D.Text = "Display &chart as 3D:";
            this.checkProject3D.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkProject3D.CheckedChanged += new System.EventHandler(this.ProjectChartTypeChanged_Click);
            // 
            // cbProjectRadius
            // 
            this.cbProjectRadius.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProjectRadius.Items.AddRange(new object[] {
            "20",
            "30",
            "40",
            "50",
            "60",
            "70"});
            this.cbProjectRadius.Location = new System.Drawing.Point(140, 89);
            this.cbProjectRadius.Name = "cbProjectRadius";
            this.cbProjectRadius.Size = new System.Drawing.Size(112, 21);
            this.cbProjectRadius.TabIndex = 3;
            this.cbProjectRadius.SelectedIndexChanged += new System.EventHandler(this.ProjectChartTypeChanged_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(11, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Doughnut &Radius (%):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkProjectShowLegend
            // 
            this.checkProjectShowLegend.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkProjectShowLegend.Checked = true;
            this.checkProjectShowLegend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkProjectShowLegend.Location = new System.Drawing.Point(22, 143);
            this.checkProjectShowLegend.Name = "checkProjectShowLegend";
            this.checkProjectShowLegend.Size = new System.Drawing.Size(130, 24);
            this.checkProjectShowLegend.TabIndex = 4;
            this.checkProjectShowLegend.Text = "Show &Legend:";
            this.checkProjectShowLegend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkProjectShowLegend.CheckedChanged += new System.EventHandler(this.ProjectChartTypeChanged_Click);
            // 
            // cbProjectExploded
            // 
            this.cbProjectExploded.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProjectExploded.Items.AddRange(new object[] {
            "None",
            "France",
            "Canada",
            "UK",
            "USA",
            "Italy"});
            this.cbProjectExploded.Location = new System.Drawing.Point(140, 62);
            this.cbProjectExploded.Name = "cbProjectExploded";
            this.cbProjectExploded.Size = new System.Drawing.Size(112, 21);
            this.cbProjectExploded.TabIndex = 2;
            this.cbProjectExploded.SelectedIndexChanged += new System.EventHandler(this.ProjectChartTypeChanged_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(11, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "&Exploded Point:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbProjectLabelStyle
            // 
            this.cbProjectLabelStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProjectLabelStyle.Items.AddRange(new object[] {
            "Inside",
            "Outside",
            "Disabled"});
            this.cbProjectLabelStyle.Location = new System.Drawing.Point(140, 35);
            this.cbProjectLabelStyle.Name = "cbProjectLabelStyle";
            this.cbProjectLabelStyle.Size = new System.Drawing.Size(112, 21);
            this.cbProjectLabelStyle.TabIndex = 1;
            this.cbProjectLabelStyle.SelectedIndexChanged += new System.EventHandler(this.ProjectChartTypeChanged_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(11, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "Label &Style:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbProjectChartType
            // 
            this.cbProjectChartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProjectChartType.Items.AddRange(new object[] {
            "Bar",
            "Column",
            "Doughnut",
            "Pie"});
            this.cbProjectChartType.Location = new System.Drawing.Point(140, 8);
            this.cbProjectChartType.Name = "cbProjectChartType";
            this.cbProjectChartType.Size = new System.Drawing.Size(112, 21);
            this.cbProjectChartType.TabIndex = 0;
            this.cbProjectChartType.SelectedIndexChanged += new System.EventHandler(this.ProjectChartTypeChanged_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(11, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 23);
            this.label8.TabIndex = 5;
            this.label8.Text = "Chart &Type:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // projectChart
            // 
            this.projectChart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.projectChart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.projectChart.BackSecondaryColor = System.Drawing.Color.White;
            this.projectChart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.projectChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.projectChart.BorderlineWidth = 2;
            this.projectChart.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.Area3DStyle.IsClustered = true;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.Perspective = 10;
            chartArea1.Area3DStyle.PointGapDepth = 0;
            chartArea1.Area3DStyle.Rotation = 0;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.ScrollBar.BackColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.ScrollBar.ButtonColor = System.Drawing.Color.Gray;
            chartArea1.AxisX.ScrollBar.LineColor = System.Drawing.Color.Black;
            chartArea1.AxisX.ScrollBar.Size = 10D;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.LabelStyle.Format = "#,###";
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderWidth = 0;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.Name = "Default";
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.projectChart.ChartAreas.Add(chartArea1);
            this.projectChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Default";
            legend1.Title = "Projects";
            legend1.TitleFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectChart.Legends.Add(legend1);
            this.projectChart.Location = new System.Drawing.Point(0, 0);
            this.projectChart.Name = "projectChart";
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.ChartArea = "Default";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
            series1.CustomProperties = "PieDrawingStyle=SoftEdge, DoughnutRadius=60";
            series1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Default";
            series1.LegendText = "Project";
            series1.LegendToolTip = "represents total number of files in a project";
            series1.Name = "Default";
            series1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            this.projectChart.Series.Add(series1);
            this.projectChart.Size = new System.Drawing.Size(371, 316);
            this.projectChart.TabIndex = 6;
            title1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold);
            title1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            title1.Name = "Title1";
            title1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            title1.ShadowOffset = 3;
            title1.Text = "Projects Chart";
            this.projectChart.Titles.Add(title1);
            this.projectChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProjectChartMouseDown);
            this.projectChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ProjectChartMouseMove);
            this.projectChart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ProjectChartMouseUp);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Click on the chart and drag the mouse to rotate the chart.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ProjectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ProjectControl";
            this.Size = new System.Drawing.Size(656, 345);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.gbOptions.ResumeLayout(false);
            this.pnlProjectChartOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.projectChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.Panel pnlProjectChartOptions;
        private System.Windows.Forms.Button btnRefreshProjectChart;
        private System.Windows.Forms.Button btnCopyProjectChart;
        private System.Windows.Forms.Button btnSaveProjectChart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbProjectPieDrawingStyle;
        private System.Windows.Forms.CheckBox checkProjectRotate;
        private System.Windows.Forms.CheckBox checkProject3D;
        private System.Windows.Forms.ComboBox cbProjectRadius;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkProjectShowLegend;
        private System.Windows.Forms.ComboBox cbProjectExploded;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbProjectLabelStyle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbProjectChartType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataVisualization.Charting.Chart projectChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBoxShowMargin;
    }
}

namespace SourceCodeCounter.GUI.Contols
{
    partial class SourceControl
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.checkBoxGrouped = new System.Windows.Forms.CheckBox();
            this.checkBoxShow3D = new System.Windows.Forms.CheckBox();
            this.checkBoxShowMargin = new System.Windows.Forms.CheckBox();
            this.checkBoxShowLabels = new System.Windows.Forms.CheckBox();
            this.checkBoxHundredPercent = new System.Windows.Forms.CheckBox();
            this.comboBoxChartType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.stackedChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.gbOptions.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stackedChart)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.gbOptions);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.stackedChart);
            this.splitContainer.Size = new System.Drawing.Size(607, 314);
            this.splitContainer.SplitterDistance = 254;
            this.splitContainer.TabIndex = 1;
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.panel1);
            this.gbOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOptions.Location = new System.Drawing.Point(0, 0);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(254, 314);
            this.gbOptions.TabIndex = 4;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Options";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnCopy);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.checkBoxGrouped);
            this.panel1.Controls.Add(this.checkBoxShow3D);
            this.panel1.Controls.Add(this.checkBoxShowMargin);
            this.panel1.Controls.Add(this.checkBoxShowLabels);
            this.panel1.Controls.Add(this.checkBoxHundredPercent);
            this.panel1.Controls.Add(this.comboBoxChartType);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(248, 293);
            this.panel1.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Location = new System.Drawing.Point(8, 256);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefreshSourceChart_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopy.Location = new System.Drawing.Point(163, 256);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 18;
            this.btnCopy.Text = "&Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopySourceChart_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(86, 256);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save &As";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSaveSourceChart_Click);
            // 
            // checkBoxGrouped
            // 
            this.checkBoxGrouped.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxGrouped.Location = new System.Drawing.Point(65, 171);
            this.checkBoxGrouped.Name = "checkBoxGrouped";
            this.checkBoxGrouped.Size = new System.Drawing.Size(74, 24);
            this.checkBoxGrouped.TabIndex = 6;
            this.checkBoxGrouped.Text = "&Grouped:";
            this.checkBoxGrouped.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxGrouped.CheckedChanged += new System.EventHandler(this.StackedChart_CheckedChanged);
            // 
            // checkBoxShow3D
            // 
            this.checkBoxShow3D.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxShow3D.Location = new System.Drawing.Point(3, 141);
            this.checkBoxShow3D.Name = "checkBoxShow3D";
            this.checkBoxShow3D.Size = new System.Drawing.Size(136, 24);
            this.checkBoxShow3D.TabIndex = 5;
            this.checkBoxShow3D.Text = "Display chart as 3&D:";
            this.checkBoxShow3D.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxShow3D.CheckedChanged += new System.EventHandler(this.StackedChart_CheckedChanged);
            // 
            // checkBoxShowMargin
            // 
            this.checkBoxShowMargin.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxShowMargin.Checked = true;
            this.checkBoxShowMargin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowMargin.Location = new System.Drawing.Point(5, 110);
            this.checkBoxShowMargin.Name = "checkBoxShowMargin";
            this.checkBoxShowMargin.Size = new System.Drawing.Size(134, 24);
            this.checkBoxShowMargin.TabIndex = 4;
            this.checkBoxShowMargin.Text = "Show X Axis &Margin:";
            this.checkBoxShowMargin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxShowMargin.CheckedChanged += new System.EventHandler(this.StackedChart_CheckedChanged);
            // 
            // checkBoxShowLabels
            // 
            this.checkBoxShowLabels.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxShowLabels.Checked = true;
            this.checkBoxShowLabels.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowLabels.Location = new System.Drawing.Point(3, 80);
            this.checkBoxShowLabels.Name = "checkBoxShowLabels";
            this.checkBoxShowLabels.Size = new System.Drawing.Size(136, 24);
            this.checkBoxShowLabels.TabIndex = 3;
            this.checkBoxShowLabels.Text = "Show Point &Labels:";
            this.checkBoxShowLabels.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxShowLabels.CheckedChanged += new System.EventHandler(this.StackedChart_CheckedChanged);
            // 
            // checkBoxHundredPercent
            // 
            this.checkBoxHundredPercent.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxHundredPercent.Location = new System.Drawing.Point(30, 49);
            this.checkBoxHundredPercent.Name = "checkBoxHundredPercent";
            this.checkBoxHundredPercent.Size = new System.Drawing.Size(109, 24);
            this.checkBoxHundredPercent.TabIndex = 2;
            this.checkBoxHundredPercent.Text = "100% &Stacked:";
            this.checkBoxHundredPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxHundredPercent.CheckedChanged += new System.EventHandler(this.StackedChart_CheckedChanged);
            // 
            // comboBoxChartType
            // 
            this.comboBoxChartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChartType.Items.AddRange(new object[] {
            "StackedArea",
            "StackedBar",
            "StackedColumn"});
            this.comboBoxChartType.Location = new System.Drawing.Point(109, 16);
            this.comboBoxChartType.Name = "comboBoxChartType";
            this.comboBoxChartType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxChartType.TabIndex = 1;
            this.comboBoxChartType.SelectedIndexChanged += new System.EventHandler(this.StackedChartType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(26, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chart Type:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stackedChart
            // 
            this.stackedChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            this.stackedChart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.stackedChart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.stackedChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.stackedChart.BorderlineWidth = 2;
            this.stackedChart.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.Inclination = 15;
            chartArea1.Area3DStyle.IsClustered = true;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.Rotation = 10;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.ScrollBar.BackColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.ScrollBar.ButtonColor = System.Drawing.Color.Gray;
            chartArea1.AxisX.ScrollBar.LineColor = System.Drawing.Color.Black;
            chartArea1.AxisX.ScrollBar.Size = 12D;
            chartArea1.AxisX2.LabelStyle.Format = "#,###";
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.LabelStyle.Format = "#,###";
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(165)))), ((int)(((byte)(191)))), ((int)(((byte)(228)))));
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.Name = "Default";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 92F;
            chartArea1.Position.Width = 92F;
            chartArea1.Position.X = 2F;
            chartArea1.Position.Y = 3F;
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.stackedChart.ChartAreas.Add(chartArea1);
            this.stackedChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Default";
            this.stackedChart.Legends.Add(legend1);
            this.stackedChart.Location = new System.Drawing.Point(0, 0);
            this.stackedChart.Name = "stackedChart";
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.ChartArea = "Default";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea100;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
            series1.IsValueShownAsLabel = true;
            series1.LabelFormat = "#,###";
            series1.Legend = "Default";
            series1.Name = "Code";
            series1.YValuesPerPoint = 2;
            series2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series2.ChartArea = "Default";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea100;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            series2.IsValueShownAsLabel = true;
            series2.LabelFormat = "#,###";
            series2.Legend = "Default";
            series2.Name = "Comments";
            series3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series3.ChartArea = "Default";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea100;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(224)))), ((int)(((byte)(64)))), ((int)(((byte)(10)))));
            series3.IsValueShownAsLabel = true;
            series3.LabelFormat = "#,###";
            series3.Legend = "Default";
            series3.Name = "Blanks";
            this.stackedChart.Series.Add(series1);
            this.stackedChart.Series.Add(series2);
            this.stackedChart.Series.Add(series3);
            this.stackedChart.Size = new System.Drawing.Size(349, 314);
            this.stackedChart.TabIndex = 2;
            this.stackedChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StackedChart_MouseDown);
            this.stackedChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.StackedChart_MouseMove);
            this.stackedChart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StackedChart_MouseUp);
            // 
            // SourceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SourceControl";
            this.Size = new System.Drawing.Size(607, 314);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.gbOptions.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stackedChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataVisualization.Charting.Chart stackedChart;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox checkBoxGrouped;
        private System.Windows.Forms.CheckBox checkBoxShow3D;
        private System.Windows.Forms.CheckBox checkBoxShowMargin;
        private System.Windows.Forms.CheckBox checkBoxShowLabels;
        private System.Windows.Forms.CheckBox checkBoxHundredPercent;
        private System.Windows.Forms.ComboBox comboBoxChartType;
        private System.Windows.Forms.Label label2;
    }
}

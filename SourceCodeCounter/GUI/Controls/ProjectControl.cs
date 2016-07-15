using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SourceCodeCounter.Common;
using SourceCodeCounter.Interfaces;

namespace SourceCodeCounter.GUI.Contols
{
    public partial class ProjectControl : UserControl
    {
        #region - Constructor -
        public ProjectControl()
        {
            InitializeComponent();
        }
        #endregion

        #region - Private Declarations -
        private Point _mouseDownPoint = Point.Empty;
        private int _origRotation;
        private int _origInclination;
        private int _angle;
        private ITaskArguments _taskArguments;
        #endregion

        #region - Public Methods
        public void Clear()
        {
            projectChart.DataSource = null;
        }
        public void Refresh(ITaskArguments taskArguments = null)
        {
            Clear();
            if (taskArguments != null) _taskArguments = taskArguments;
            PopulateProjectChartData();
            UpdateProjectChartSettings();
        }
        #endregion

        #region - Project Chart Methods -

        private void PopulateProjectChartData()
        {
            if (_taskArguments == null) return;
            // Clear Project Exploded items
            cbProjectExploded.Items.Clear();

            var xval = new string[_taskArguments.SourceHandler.Projects.Items.Count];
            var yval = new int[_taskArguments.SourceHandler.Projects.Items.Count];
            int i = 0;
            foreach (var project in  _taskArguments.SourceHandler.Projects.Items)
            {
                xval[i] = project.Name;
                yval[i] = project.FileCount;
                cbProjectExploded.Items.Add(project.Name);
                i++;
            }

            projectChart.Series[0].Points.DataBindXY(xval, yval);
            // Set selection
            cbProjectChartType.SelectedIndex = 1;
            cbProjectPieDrawingStyle.SelectedIndex = 1;
            cbProjectLabelStyle.SelectedIndex = 0;
            cbProjectRadius.SelectedIndex = 4;
            cbProjectExploded.SelectedIndex = (cbProjectExploded.Items.Count > 0) ? 0 : -1;
            checkProjectShowLegend.Checked = true;
            checkProject3D.Checked = true;

            UpdateProjectChartSettings();
            projectChart.DataSource = _taskArguments.SourceHandler.Projects.Items;
            projectChart.Series[0].XValueMember = "Name";
            projectChart.Series[0].YValueMembers = "FileCount";
            projectChart.DataBind();

        }
        private void UpdateProjectChartSettings()
        {
            // Set chart type
            string chartTypeName = cbProjectChartType.Text;
            if (string.IsNullOrEmpty(chartTypeName))
            {
                chartTypeName = "Column";
                cbProjectChartType.Text = chartTypeName;
            }
            // Grouping cannot be done using stacked area charts
            projectChart.Series[0]["DrawingStyle"] = (chartTypeName.In("Bar", "Column")) ? "Cylinder" : cbProjectPieDrawingStyle.SelectedItem.ToString();
            projectChart.Series[0].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), chartTypeName, true);
            // projectChart.Series[0]["PointWidth"] = "0.6";
            projectChart.Series[0].IsValueShownAsLabel = true;
            // Set Title
            projectChart.Titles[0].Text = string.Format("Projects {0} Chart", chartTypeName);

            cbProjectRadius.Enabled = (chartTypeName == "Doughnut");

            // Show Legend
            projectChart.Legends[0].Enabled = checkProjectShowLegend.Checked;

            // Disable X axis margin
            projectChart.ChartAreas[0].AxisX.IsMarginVisible = checkBoxShowMargin.Checked;

            // Enable 3D charts
            projectChart.ChartAreas[0].Area3DStyle.Enable3D = checkProject3D.Checked;
            projectChart.ChartAreas[0].Area3DStyle.LightStyle = LightStyle.Simplistic;
            // Disable/enable clustered series
            projectChart.ChartAreas[0].Area3DStyle.IsClustered = false;

            // Explode selected project
            foreach (DataPoint point in projectChart.Series[0].Points)
            {
                point["Exploded"] = (point.AxisLabel == cbProjectExploded.Text) ? "true" : "false";
            }

            if (chartTypeName.In("Pie", "Doughnut"))
            {
                projectChart.Series[0]["PieDrawingStyle"] = cbProjectPieDrawingStyle.SelectedItem.ToString();
                projectChart.Series[0]["PieLabelStyle"] = cbProjectLabelStyle.SelectedItem.ToString();
                // Set Doughnut hole size
                projectChart.Series[0]["DoughnutRadius"] = (cbProjectRadius.Enabled) ? cbProjectRadius.Text : string.Empty;
            }
            // Set Timer for Rotation
            timer1.Enabled = (checkProjectRotate.Checked);
            projectChart.Invalidate();
        }

        private void ProjectChartMouseDown(object sender, MouseEventArgs e)
        {
            projectChart.Cursor = Cursors.NoMove2D;
            _mouseDownPoint = new Point(e.X, e.Y);
            _origRotation = projectChart.ChartAreas[0].Area3DStyle.Rotation;
            _origInclination = projectChart.ChartAreas[0].Area3DStyle.Inclination;

            // Call HitTest Method
            HitTestResult hitTestResult = projectChart.HitTest(e.X, e.Y);
            if (hitTestResult.PointIndex == -1) return;

            // Check if data point is already exploded
            bool exploded = (projectChart.Series[0].Points[hitTestResult.PointIndex].CustomProperties == "Exploded=true");

            // Clear all exploded attributes first
            foreach (DataPoint dataPoint in projectChart.Series[0].Points)
            {
                dataPoint.CustomProperties = "";
            }

            // if dataPoint is already exploded, get out.
            if (exploded) return;

            // if datapoint or legend item is selected
            if ((hitTestResult.ChartElementType == ChartElementType.DataPoint) ||
                (hitTestResult.ChartElementType == ChartElementType.LegendItem))
            {
                // Set Attribute
                DataPoint dataPoint = projectChart.Series[0].Points[hitTestResult.PointIndex];
                dataPoint.CustomProperties = "Exploded=true";
            }
        }
        private void ProjectChartMouseUp(object sender, MouseEventArgs e)
        {
            projectChart.Cursor = Cursors.Hand;
            _mouseDownPoint = Point.Empty;
        }
        private void ProjectChartMouseMove(object sender, MouseEventArgs e)
        {
            #region // Explode selected item

            HitTestResult hitTestResult = projectChart.HitTest(e.X, e.Y);
            if (hitTestResult.PointIndex == -1) return;

            // Reset dataPoint attributes
            foreach (var point in projectChart.Series[0].Points)
            {
                point.BackSecondaryColor = Color.Black;
                point.BackHatchStyle = ChartHatchStyle.None;
                point.BorderWidth = 1;
            }

            // if dataPoint or legendItem is selected
            if ((hitTestResult.ChartElementType == ChartElementType.DataPoint) ||
                (hitTestResult.ChartElementType == ChartElementType.LegendItem))
            {
                // Set cursor type
                Cursor = Cursors.Hand;
                // find selected dataPoint
                DataPoint point = projectChart.Series[0].Points[hitTestResult.PointIndex];
                if (point != null)
                {
                    point.BackSecondaryColor = Color.White;
                    point.BackHatchStyle = ChartHatchStyle.Percent25;
                    point.BorderWidth = 2;
                }
            }
            else
            {
                Cursor = Cursors.Default;
            }
            #endregion

            #region // 3D rotation
            if (!_mouseDownPoint.IsEmpty)
            {
                int rotationDelta = (_mouseDownPoint.X - e.X);
                int rotation = _origRotation;
                for (int i = 0; i != rotationDelta; )
                {
                    if (rotationDelta > 0)
                    {
                        if (rotation >= 180)
                        {
                            rotation = -180;
                        }
                        ++rotation;
                    }
                    else
                    {
                        if (rotation <= -180)
                        {
                            rotation = 180;
                        }
                        --rotation;
                    }

                    i += (rotationDelta > 0) ? 1 : -1;
                }
                projectChart.ChartAreas[0].Area3DStyle.Rotation = rotation;

                int inclinationDelta = (e.Y - _mouseDownPoint.Y);
                int inclination = _origInclination;
                for (int i = 0; i != inclinationDelta; )
                {
                    if (inclinationDelta > 0)
                    {
                        if (inclination >= 90)
                        {
                            inclination = -90;
                        }
                        ++inclination;
                    }
                    else
                    {
                        if (inclination <= -90)
                        {
                            inclination = 90;
                        }
                        --inclination;
                    }

                    i += (inclinationDelta > 0) ? 1 : -1;
                }
                projectChart.ChartAreas[0].Area3DStyle.Inclination = inclination;

                projectChart.Invalidate();
                projectChart.Update();
            }
            #endregion
        }
        private void ProjectChartTypeChanged_Click(object sender, EventArgs e)
        {
            UpdateProjectChartSettings();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkProjectRotate.Checked)
            {
                _angle += 1;
                if (_angle >= 360)
                {
                    _angle = 0;
                }
                projectChart.Series[0]["PieStartAngle"] = _angle.ToString(CultureInfo.InvariantCulture);
            }
        }
        private void btnCopyProjectChart_Click(object sender, EventArgs e)
        {
            HelperClass.CopyChartToClipboard(projectChart);
        }
        private void btnSaveProjectChart_Click(object sender, EventArgs e)
        {
            HelperClass.SaveChart(projectChart);
        }
        private void btnRefreshProjectChart_Click(object sender, EventArgs e)
        {
            Refresh();
        }
        #endregion
    }
}

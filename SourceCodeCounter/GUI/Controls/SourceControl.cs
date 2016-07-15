using System;
using System.Drawing;
using System.Windows.Forms;

using SourceCodeCounter.Common;
using SourceCodeCounter.Interfaces;

namespace SourceCodeCounter.GUI.Contols
{
    using System.Windows.Forms.DataVisualization.Charting;
    public partial class SourceControl : UserControl
    {
        #region - Constructor -
        public SourceControl()
        {
            InitializeComponent();
        }
        #endregion

        #region - Private Declarations -
        private Point _mouseDownPoint = Point.Empty;
        private int _origRotation;
        private int _origInclination;
        private ITaskArguments _taskArguments;
        #endregion

        #region - Public Methods -
        public void Clear()
        {
            stackedChart.DataSource = null;
        }

        public void Refresh(ITaskArguments taskArguments = null)
        {
            Clear();
            if (taskArguments != null) _taskArguments = taskArguments;
            PopulateSourceChartData();
            UpdateChartSettings();
        }
        #endregion

        #region - Stacked Chart Methods -
        private void UpdateChartSettings()
        {
            // Set chart type
            string chartTypeName = comboBoxChartType.Text;
            if (string.IsNullOrEmpty(chartTypeName)) chartTypeName = "StackedArea";
         
            if (checkBoxHundredPercent.Checked)
            {
                chartTypeName = chartTypeName + "100";
            }
         
            // Grouping cannot be done using stacked area charts
            checkBoxGrouped.Enabled = (!chartTypeName.In("StackedArea", "StackedArea100"));

            foreach (var series in stackedChart.Series)
            {
                series.ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), chartTypeName, true);
                series.IsValueShownAsLabel = checkBoxShowLabels.Checked;
                series["StackedGroupName"] = (checkBoxGrouped.Checked) ? "Group1" : "";
            }

            stackedChart.ChartAreas[0].Area3DStyle.Enable3D = checkBoxShow3D.Checked;
            stackedChart.ChartAreas[0].Area3DStyle.LightStyle = LightStyle.Simplistic;

            // Enable/Disable margin
            stackedChart.ChartAreas[0].AxisX.IsMarginVisible = checkBoxShowMargin.Checked;

            stackedChart.ResetAutoValues();
            stackedChart.Invalidate();
        }
        private void PopulateSourceChartData()
        {
            // Populate series data
            if (_taskArguments == null) return;
            // Bind DataSource
            stackedChart.DataSource = _taskArguments.SourceHandler.Projects.Items;
            stackedChart.DataBind();

            foreach (var series in stackedChart.Series)
            {
                series.XValueMember = "Name";
                series["DrawingStyle"] = "Cylinder";
                series["PointWidth"] = "0.6";
            }
            stackedChart.Series["Code"].YValueMembers = "CodeLines";
            stackedChart.Series["Comments"].YValueMembers = "Comments";
            stackedChart.Series["Blanks"].YValueMembers = "BlankLines";

            // Set selection
            comboBoxChartType.SelectedIndex = 2;
        }

        private void StackedChart_CheckedChanged(object sender, EventArgs e)
        {
            UpdateChartSettings();
        }
        private void StackedChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChartSettings();
        }

        private void StackedChart_MouseDown(object sender, MouseEventArgs e)
        {
            stackedChart.Cursor = Cursors.NoMove2D;
            _mouseDownPoint = new Point(e.X, e.Y);
            _origRotation = stackedChart.ChartAreas[0].Area3DStyle.Rotation;
            _origInclination = stackedChart.ChartAreas[0].Area3DStyle.Inclination;
        }

        private void StackedChart_MouseUp(object sender, MouseEventArgs e)
        {
            stackedChart.Cursor = Cursors.Hand;
            _mouseDownPoint = Point.Empty;
        }

        private void StackedChart_MouseMove(object sender, MouseEventArgs e)
        {
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
                stackedChart.ChartAreas[0].Area3DStyle.Rotation = rotation;

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
                stackedChart.ChartAreas[0].Area3DStyle.Inclination = inclination;

                stackedChart.Invalidate();
                stackedChart.Update();
            }
        }
        private void btnRefreshSourceChart_Click(object sender, EventArgs e)
        {
            Refresh();
        }
        private void btnCopySourceChart_Click(object sender, EventArgs e)
        {
            HelperClass.CopyChartToClipboard(stackedChart);
        }
        private void btnSaveSourceChart_Click(object sender, EventArgs e)
        {
            HelperClass.SaveChart(stackedChart);
        }
        #endregion
    }
}

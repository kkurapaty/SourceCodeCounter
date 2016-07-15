using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

namespace SourceCodeCounter.GUI.Contols
{
    /// <summary>
    /// This class represents a custom vertical tab control that is used by docking windows.
    /// </summary>
    public partial class VerticalTabControl : UserControl
    {
        #region - Private Properties -

        /// <summary>
        /// Control tab pages collection.
        /// </summary>
        private readonly VerticalTabPageCollection _tabPages;

        /// <summary>
        /// Selected tab page or null.
        /// </summary>
        private VerticalTabPage _selectedTabPage;

        /// <summary>
        /// Indicates that tab control is vertical
        /// </summary>
        private bool _vertical = true;

        /// <summary>
        /// Tab buttons offset from the left and right side.
        /// </summary>
        private const int ButtonOffset = 7;

        /// <summary>
        /// Tab button text spacing
        /// </summary>
        private Rectangle _buttonTextSpacing = new Rectangle(12, 4, 12, 4);

        /// <summary>
        /// Control used to draw a horizontal splitter line
        /// </summary>
        private readonly Label _tabSplitterLine;

        /// <summary>
        /// Color of the box border.
        /// </summary>
        private Color _borderColor = Color.Black;

        /// <summary>
        /// Box border size.
        /// </summary>
        private int _borderSize = 1;

        /// <summary>
        /// Background image horizontal offset;
        /// </summary>
        public int BackImageOffsetX = 0;

        /// <summary>
        /// Background image vertical offset;
        /// </summary>
        public int BackImageOffsetY = 0;

        #endregion

        #region - Constructor -

        /// <summary>
        /// Default constructor.
        /// </summary>
        public VerticalTabControl()
        {
            ImageList = null;
            // Create tab pages collection
            _tabPages = new VerticalTabPageCollection(this);

            // Initialize splitter line control
            _tabSplitterLine = new Label {Text = String.Empty, Visible = false, BorderStyle = BorderStyle.FixedSingle};
            Controls.Add(_tabSplitterLine);

            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        #endregion

        #region - Public Properties -

        /// <summary>
        /// Border color of the box.
        /// </summary>
        [
        Category("Appearance"),
        DefaultValue(typeof(Color), "Black"),
        Description("Border color of the box."),
        ]
        public Color BorderColor
        {
            set
            {
                _borderColor = value;
                Invalidate();
            }
            get
            {
                return _borderColor;
            }
        }

        /// <summary>
        /// Border size of the box.
        /// </summary>
        [
        Category("Appearance"),
        DefaultValue(1),
        Description("Border size of the box."),
        ]
        public int BorderSize
        {
            set
            {
                _borderSize = value;
                Invalidate();
            }
            get
            {
                return _borderSize;
            }
        }

        /// <summary>
        /// Gets the number of non-hidden tab pages in the control.
        /// </summary>
        /// <value>The number of non-hidden tab pages in the control.</value>
        [
        Category("Misc"),
        DefaultValue(0),
        Description("Gets the number of non-hidden tab pages in the control."),
        ]
        public int VisibleTabPagesCount
        {
            get
            {
                return TabPages.Cast<VerticalTabPage>().Count(tabPage => !tabPage.Hidden);
            }
        }

        /// <summary>
        /// Gets the control's tab pages collection.
        /// <seealso cref="VerticalTabPageCollection"/>
        /// <seealso cref="VerticalTabPage"/>
        /// </summary>
        /// <value>The control's <see cref="VerticalTabPageCollection"/> object.</value>
        [
        Category("Misc"),
        DefaultValue(""),
        Description("Gets control tab pages collection."),
        ]
        public VerticalTabPageCollection TabPages
        {
            get
            {
                return _tabPages;
            }
        }

        /// <summary>
        /// Gets or sets the vertical style of the tab control.
        /// </summary>
        /// <value>If <b>true</b> the control is displayed vertically, if <b>false</b> it 
        /// is not.</value>
        [
        Category("Appearance"),
        DefaultValue(""),
        Description("Gets or sets the vertical style of the tab control."),
        ]
        public bool Vertical
        {
            get
            {
                return _vertical;
            }
            set
            {
                if (_vertical != value)
                {
                    _vertical = value;
                    OnVerticalChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the control's image list, which is used for the vertical tab page 
        /// buttons.
        /// <seealso cref="ImageList"/>
        /// <seealso cref="VerticalTabPage.ImageIndex"/>
        /// </summary>
        /// <value>The control's <see cref="ImageList"/> object.</value>
        [Category("Appearance"), DefaultValue(""), Description("Gets or sets the control's image list.")]
        public ImageList ImageList { get; set; }

        /// <summary>
        /// Gets or sets the index of the selected tab page.
        /// <seealso cref="VerticalTabPage"/>
        /// </summary>
        /// <value>The  index of the selected tab page.</value>
        [
        Category("Misc"),
        DefaultValue(""),
        Description("Gets or sets the index of the selected tab page."),
        ]
        public int SelectedIndex
        {
            get
            {
                // Get index of selected tab page
                if (_selectedTabPage != null)
                {
                    return _selectedTabPage.Index;
                }
                return -1;
            }
            set
            {
                // Select tab page using index
                if (value < TabPages.Count && value >= 0)
                {
                    SelectedTab = TabPages[value];
                }
                else
                {
                    SelectedTab = null;
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected tab page.
        /// <seealso cref="VerticalTabPage"/>
        /// </summary>
        /// <value>The selected <see cref="VerticalTabPage"/> object of the control.</value>
        [
        Category("Misc"),
        DefaultValue(""),
        Description("Sets or gets selected tab page."),
        ]
        public VerticalTabPage SelectedTab
        {
            get
            {
                return _selectedTabPage;
            }
            set
            {
                if (value == null || Contains(value))
                {
                    // Hidden tabs cannot be selected
                    if (VisibleTabPagesCount == 0)
                    {
                        value = null;
                    }
                    else if (value != null && value.Hidden)
                    {
                        // Try to find non-hidden tab page next to current
                        int index = value.Index + 1;
                        while (value.Hidden && index < TabPages.Count)
                        {
                            value = TabPages[index++];
                        }

                        // Try to find non-hidden tab page prev. to current
                        index = value.Index - 1;
                        while (value.Hidden && index >= 0)
                        {
                            value = TabPages[index--];
                        }

                    }

                    _selectedTabPage = value;
                    OnSelectedTabPageChanged();
                }
            }
        }

        #endregion

        #region - Methods -

        /// <summary>
        /// Called when the control is resized.
        /// <seealso cref="EventArgs"/>
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected override void OnResize(EventArgs e)
        {
            // Call base class
            base.OnResize(e);

            // Resize horizontal splitter line 
            if (!Vertical)
            {
                //tabSplitterLine.Visible = (VisibleTabPagesCount > 1) ? true : false;
                _tabSplitterLine.Location = new Point(0, ClientRectangle.Bottom - GetButtonHeight());
                _tabSplitterLine.Size = new Size(Width, 1);
                _tabSplitterLine.SendToBack();
            }

            // Reposition buttons in horizontal style
            if (!Vertical)
            {
                SuspendLayout();
                ResizeHorizontalTabPages();
                ResumeLayout();
            }
        }

        /// <summary>
        /// Called when the tab pages are changed. 
        /// </summary>
        internal void OnTabPagesChanged()
        {
            ReorderTabButtons();
        }

        /// <summary>
        /// Called when the vertical style of the tab control is changed.
        /// </summary>
        protected virtual void OnVerticalChanged()
        {
            // Hide/Show horizontal splitter line 
            //tabSplitterLine.Visible = !Vertical;

            // Reorder tabs
            ReorderTabButtons();
        }

        /// <summary>
        /// Called when the selected tab page is changed.
        /// </summary>
        protected virtual void OnSelectedTabPageChanged()
        {
            ReorderTabButtons();

            // Fire event
            if (SelectedIndexChanged != null)
            {
                SelectedIndexChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Sets tab buttons order, visibility and docking style.
        /// </summary>
        private void ReorderTabButtons()
        {
            SuspendLayout();

            // Hide paneles of all tab pages except of selected one
            bool beforeSelectedTab = true;
            int childControlIndex = TabPages.Count - 1;
            int tabIndex = 0;
            foreach (VerticalTabPage tabPage in TabPages)
            {
                // Set button orientation 
                tabPage.TabButton.Vertical = Vertical;

                // Set buttons docking and child order for vertical tabs
                if (Vertical)
                {

                    tabPage.TabButton.Visible = (!tabPage.Hidden);

                    // Set button height
                    tabPage.TabButton.Height = GetButtonHeight();

                    // Dock buttons to Top or Bottom
                    tabPage.TabButton.Dock = (beforeSelectedTab) ? DockStyle.Top : DockStyle.Bottom;

                    // Set button child index
                    Controls.SetChildIndex(tabPage.TabButton, childControlIndex);
                }

                if (tabPage == SelectedTab)
                {
                    // Rest of the buttons should be docked to the bottom
                    beforeSelectedTab = false;
                    childControlIndex = 0;

                    // Set selected style of the button
                    tabPage.TabButton.SelectedTab = true;

                    // Make sure the previous button has no separator line
                    if (tabIndex > 0)
                    {
                        TabPages[tabIndex - 1].TabButton.SeparatorLine = false;
                    }
                }
                else
                {
                    // Hide non selected tab panels
                    tabPage.Visible = false;

                    // Set non-selected style of the button
                    tabPage.TabButton.SelectedTab = false;
                    tabPage.TabButton.SeparatorLine = true;
                }

                // Get next child index 
                if (beforeSelectedTab)
                {
                    --childControlIndex;
                }
                else
                {
                    ++childControlIndex;
                }

                // Show selected tab panel
                if (SelectedTab != null)
                {
                    // Make sure panel is on the top of the Z order
                    SelectedTab.BringToFront();

                    // set fill docking style
                    if (Vertical)
                    {
                        SelectedTab.Dock = DockStyle.Fill;
                    }

                    // Show selected tab panel
                    SelectedTab.Visible = true;
                }

                ++tabIndex;
            }

            // Make sure all buttons fit in horizontal mode
            if (!Vertical)
            {
                ResizeHorizontalTabPages();
            }

            ResumeLayout();
        }

        /// <summary>
        /// Returns the height of the tab page button.
        /// </summary>
        /// <returns>The tab button's height.</returns>
        /// <remarks>The height of button is the same for all vertical tab pages.
        /// </remarks>
        public int GetButtonHeight()
        {
            int height = 0;
            if (TabPages.Count > 0)
            {
                // Get text size
                Graphics graphics = CreateGraphics();
                SizeF textSize = graphics.MeasureString(TabPages[0].TabButton.Text, TabPages[0].TabButton.Font);
                height = (int)textSize.Height;
                graphics.Dispose();

                // Get image size
                if (TabPages[0].TabButton.Image != null)
                {
                    height = Math.Max(height, TabPages[0].TabButton.Image.Height);
                }

                // Add extra spacing
                height += _buttonTextSpacing.Y + _buttonTextSpacing.Height;
            }
            return height;
        }

        /// <summary>
        /// Sets tab page button and panel position for non-vertical tab control.
        /// </summary>
        internal void ResizeHorizontalTabPages()
        {
            //************************************************************
            //** Reposition all tab page panel controls.
            //************************************************************
            Rectangle panelPosition = ClientRectangle;
            panelPosition.Inflate(-1, -1);
            if (VisibleTabPagesCount >= 1)
            {
                int tabButtonsHeight = GetButtonHeight() + 1;
                panelPosition.Height -= tabButtonsHeight;
                panelPosition.Y += tabButtonsHeight;
            }
            foreach (VerticalTabPage tabPage in TabPages)
            {
                tabPage.Dock = DockStyle.None;
                tabPage.Location = panelPosition.Location;
                tabPage.Size = panelPosition.Size;
            }

            //************************************************************
            //** Calculate positions for all buttons.
            //************************************************************

            // Create an arry of rectangles
            var buttonPos = new Rectangle[TabPages.Count];

            // Calculate position of each button
            int tabIndex = 0;
            int currentX = ButtonOffset;
            foreach (VerticalTabPage tabPage in TabPages)
            {
                if (!tabPage.Hidden)
                {
                    buttonPos[tabIndex] = new Rectangle(0, 0, 0, 0);

                    // Hide all buttons if only one tap page in control
                    tabPage.TabButton.Visible = (!tabPage.Hidden);

                    // Get left button coordinate using previous page button
                    buttonPos[tabIndex].X = currentX;

                    // Set button Top and Height
                    buttonPos[tabIndex].Y = 1;
                    buttonPos[tabIndex].Height = GetButtonHeight();

                    // Set button width
                    Graphics graphics = CreateGraphics();
                    SizeF textSize = graphics.MeasureString(tabPage.TabButton.Text, tabPage.TabButton.Font);
                    buttonPos[tabIndex].Width = (int)textSize.Width + _buttonTextSpacing.X + _buttonTextSpacing.Width;
                    graphics.Dispose();

                    // Add image width
                    if (tabPage.TabButton.Image != null)
                    {
                        buttonPos[tabIndex].Width += tabPage.TabButton.Image.Width + 3;
                    }

                    // Move current X coordinate
                    currentX = buttonPos[tabIndex].Right - 1;
                }

                // Increase index
                ++tabIndex;
            }

            //************************************************************
            //** Adjust buttons position if total width is too big.
            //************************************************************

            // Calculate max width for all buttons
            int maxX = ClientRectangle.Width - 2 * ButtonOffset;

            // Check if buttons width adjustment is required
            bool adjustmentRequired = buttonPos.Any(rect => rect.Right > maxX);

            // Make the adjustment
            if (adjustmentRequired)
            {
                // Calculate new button width
                int newWidth = maxX / TabPages.Count - TabPages.Count;
                if (newWidth < 10)
                {
                    newWidth = 10;
                }

                // Set new width
                currentX = ButtonOffset;
                for (int rectIndex = 0; rectIndex < buttonPos.Length; rectIndex++)
                {
                    buttonPos[rectIndex].X = currentX;
                    buttonPos[rectIndex].Width = newWidth;
                    currentX = buttonPos[rectIndex].Right + 1;
                }
            }

            //************************************************************
            //** Set buttons position.
            //************************************************************
            tabIndex = 0;
            foreach (VerticalTabPage tabPage in TabPages)
            {
                if (tabPage != null && tabPage.TabButton.Dock != DockStyle.None)
                {
                    tabPage.TabButton.Dock = DockStyle.None;
                }
                if (tabPage != null)
                {
                    tabPage.TabButton.Location = buttonPos[tabIndex].Location;
                    tabPage.TabButton.Size = buttonPos[tabIndex].Size;
                    tabPage.SendToBack();
                }

                // Increase index
                ++tabIndex;
            }

        }

        #endregion

        #region - Overriden painting methods -

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            int height = GetButtonHeight() + 1;
            if (BackgroundImage != null)
            {
                e.Graphics.Clear(BackColor);

                // Draw image in the background of the tab controls.
                // Image must be aligne to the bottom-right corner of the tabs area.
                var destRect = new Rectangle( Right - BackgroundImage.Width + BackImageOffsetX, 0, BackgroundImage.Width, height);
                var imageAttributes = new ImageAttributes();
                e.Graphics.DrawImage(BackgroundImage, destRect, 0, BackImageOffsetY, BackgroundImage.Width, height, GraphicsUnit.Pixel, imageAttributes);
            }
            else
            {
                base.OnPaintBackground(e);
            }

            // Border rectangle
            height -= 1;
            var rectBorder = new Rectangle(0, height, Width - 1, Height - height - 1);

            // Draw simple border
            using (var pen = new Pen(BorderColor, BorderSize))
            {
                e.Graphics.DrawRectangle(pen, rectBorder);
            }
        }

        #endregion

        #region - Events -

        /// <summary>
        /// Event that occurs when selected index is changed in the tab control.
        /// </summary>
        public event EventHandler SelectedIndexChanged;

        /// <summary>
        /// The tab page button's dragging started event.
        /// </summary>
        public event EventHandler TabPageButtonStartDragging;

        /// <summary>
        /// Tab page button dragging started event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        internal void OnTabPageButtonStartDragging(object sender, EventArgs e)
        {
            // Fire TabPageButtonStartDragging event
            if (TabPageButtonStartDragging != null)
            {
                TabPageButtonStartDragging(sender, e);
            }
        }

        #endregion
    }

    /// <summary>
    /// This class represents a vertical tab page.
    /// <seealso cref="VerticalTabControl"/>
    /// <seealso cref="VerticalTabPageButton"/>
    /// <seealso cref="VerticalTabPageCollection"/>
    /// <seealso>
    ///     <cref>DockingWindow</cref>
    /// </seealso>
    /// </summary>
    /// <remarks>One or more vertical tab pages can be displayed by the vertical tab control of a 
    /// docking window.<para>A vertical tab page displays a tab page button that has an image and 
    /// some text.
    /// </para>
    /// <para>These pages are stored in the <see cref="VerticalTabPageCollection"/> object property 
    /// of a vertical tab control.</para>
    /// <para>You can use the inherited properties to set panel-specific properties 
    /// (e.g. text, etc.).</para></remarks>
    public class VerticalTabPage : Panel
    {
        #region - Fields -

        /// <summary>
        /// Tab control this page belongs to.
        /// </summary>
        internal VerticalTabControl TabControl = null;

        /// <summary>
        /// Tab page button.
        /// </summary>
        internal VerticalTabPageButton tabButton = null;

        /// <summary>
        /// Indicates that tab page is hidden.
        /// </summary>
        private bool _hidden;

        #endregion

        #region - Constructor -

        /// <summary>
        /// Default constructor.
        /// </summary>
        public VerticalTabPage()
        {
            Initialize("TabName");
        }

        /// <summary>
        /// Default constructor that takes the text to be displayed on the tab.
        /// <seealso cref="VerticalTabControl"/>
        /// </summary>
        /// <param name="text">Text to be displayed on the tab.</param>
        public VerticalTabPage(string text)
        {
            Initialize(text);
        }

        /// <summary>
        /// Initialize tab control page.
        /// </summary>
        /// <param name="text">Text to be displayed on the tab.</param>
        private void Initialize(string text)
        {
            // Set button text
            Text = text;

            // Initialize Panel properties
            Visible = false;
            Dock = DockStyle.Fill;
            DockPadding.Left = 5;
            DockPadding.Right = 2;
            DockPadding.Top = 5;
            DockPadding.Bottom = 2;

            // Change control style
            //SetStyle(ControlStyles.ResizeRedraw, true);

            // Create tab page button
            tabButton = new VerticalTabPageButton
                {
                    Text = text,
                    Dock = DockStyle.Top,
                    FlatStyle = FlatStyle.Standard,
                    ImageAlign = ContentAlignment.MiddleLeft,
                    TextAlign = ContentAlignment.MiddleLeft
                };

            // Hookup to the button events
            tabButton.DragOver += OnButtonDragOver;
            tabButton.MouseDown += OnButtonMouseDown;
            tabButton.Click += OnButtonMouseClick;
            tabButton.StartDragging += OnButtonStartDragging;
        }

        #endregion

        #region - Properties -

        /// <summary>
        /// Gets or sets the tab page's hidden flag.
        /// <seealso cref="VerticalTabControl"/>
        /// </summary>
        /// <value>If <b>true</b> the tab page is hidden, if <b>false</b> it is not.</value>
        [
        Category("Appearance"),
        DefaultValue(false),
        Description("Gets or sets the tab page's hidden flag."),
        ]
        public bool Hidden
        {
            get
            {
                return _hidden;
            }
            set
            {
                if (_hidden != value)
                {
                    _hidden = value;
                    OnHiddenChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the index of the image to be drawn on the tab button.
        /// <seealso cref="VerticalTabControl"/>
        /// </summary>
        /// <value>Index of the tab button's image.</value>
        [
        Category("Misc."),
        DefaultValue(""),
        Description("Gets or sets the index of the image to be drawn on the tab button."),
        ]
        public int ImageIndex
        {
            get
            {
                return TabButton.ImageIndex;
            }
            set
            {
                // Set image list of the button
                if (TabControl != null)
                {
                    if (TabButton != null && TabButton.ImageList != TabControl.ImageList)
                    {
                        TabButton.ImageList = TabControl.ImageList;
                    }
                }

                // Set image index
                if (TabButton != null) TabButton.ImageIndex = value;
            }
        }

        /// <summary>
        /// Gets the tab page's button control.
        /// <seealso cref="VerticalTabPageButton"/>
        /// <seealso cref="VerticalTabControl"/>
        /// </summary>
        /// <value>The tab page's <see cref="VerticalTabPageButton"/> object.</value>
        [
        Category("Misc."),
        DefaultValue(""),
        Description("Gets the tab page's button control."),
        ]
        public VerticalTabPageButton TabButton
        {
            get
            {
                return tabButton;
            }
        }

        /// <summary>
        /// Gets the index of the page in the tab control's vertical tab page collection.
        /// <seealso cref="VerticalTabControl"/>
        /// <seealso cref="VerticalTabPageCollection"/>
        /// </summary>
        /// <value>The index of the tab page.</value>
        [
        Category("Misc."),
        DefaultValue(""),
        Description("Gets the index of the tab page in the collection."),
        ]
        public int Index
        {
            get
            {
                if (TabControl != null)
                {
                    // Find index of this tab page
                    int tabPageIndex = 0;
                    foreach (VerticalTabPage tabPage in TabControl.TabPages)
                    {
                        if (tabPage == this)
                        {
                            return tabPageIndex;
                        }
                        ++tabPageIndex;
                    }
                }
                return -1;
            }
        }


        #endregion

        #region - Methods -

        private void OnButtonDragOver(object sender, DragEventArgs e)
        {
            if (TabControl != null && this != TabControl.SelectedTab)
            {
                // Change selected tab control
                TabControl.SelectedTab = this;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Mouse button was pressed inside tab page button.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments</param>
        private void OnButtonMouseDown(object sender, MouseEventArgs e)
        {
            if (TabControl != null && !TabControl.Vertical)
            {
                // Change selected tab control
                TabControl.SelectedTab = this;
            }
        }

        /// <summary>
        /// Mouse button was pressed inside tab page button.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments</param>
        private void OnButtonMouseClick(object sender, EventArgs e)
        {
            if (TabControl != null && TabControl.Vertical)
            {
                // Change selected tab control
                TabControl.SelectedTab = this;
            }
        }

        /// <summary>
        /// Event is called when button was dragged with the mouse.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments</param>
        private void OnButtonStartDragging(object sender, EventArgs e)
        {
            if (TabControl != null)
            {
                // Notify tab control
                TabControl.OnTabPageButtonStartDragging(sender, e);
            }
        }

        /// <summary>
        /// Called after the controls text is changed.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected override void OnTextChanged(EventArgs e)
        {
            // Update button text
            if (TabButton != null)
            {
                TabButton.Text = Text;
            }
        }

        /// <summary>
        /// Called after the  controls hidden flag is changed.
        /// </summary>
        protected void OnHiddenChanged()
        {
            // Change visibility of the tab button
            TabButton.Visible = !Hidden;

            // Check if control reference is not null
            if (TabControl != null)
            {
                // Hidden tab page can't be selected
                if (TabControl.SelectedTab == this)
                {
                    int newIndex = Index;
                    if (newIndex >= TabControl.TabPages.Count)
                    {
                        newIndex = TabControl.TabPages.Count - 1;
                    }
                    TabControl.SelectedIndex = newIndex;
                }

                // If there is only one tab page in control - select it
                if (TabControl.SelectedTab == null)
                {
                    TabControl.SelectedTab = this;
                }

                // Notify tab control about the changes
                TabControl.OnTabPagesChanged();
            }
        }

        #endregion
    }

    /// <summary>
    /// This class represents a collection of tab pages that belong to a vertical tab control.
    /// <seealso cref="VerticalTabControl"/>
    /// <seealso cref="VerticalTabPage"/>
    /// </summary>
    /// <remarks><b>VerticalTabPageCollection</b> is exposed as the 
    /// <see cref="VerticalTabControl.TabPages"/> property of the <see cref="VerticalTabControl"/> 
    /// class.<para>A vertical tab control can display one or more tab pages.</para></remarks>
    public class VerticalTabPageCollection : CollectionBase
    {
        #region - Fields -

        /// <summary>
        /// Reference to the owner tab control.
        /// </summary>
        private readonly VerticalTabControl _tabControl;

        #endregion

        #region - Constructor and initialization -

        /// <summary>
        /// The constructor, which takes the vertical tab control owner of this object.
        /// <seealso cref="VerticalTabControl"/>
        /// <seealso cref="VerticalTabPage"/>
        /// </summary>
        /// <param name="tabControl">Owner of the collection.</param>
        public VerticalTabPageCollection(VerticalTabControl tabControl)
        {
            _tabControl = tabControl;
        }

        #endregion

        #region - Indexer -

        /// <summary>
        /// Strongly typed indexer of the collection.
        /// <seealso cref="VerticalTabControl"/>
        /// <seealso cref="VerticalTabPage"/>
        /// </summary>
        public VerticalTabPage this[int index]
        {
            get
            {
                return (VerticalTabPage)List[index];
            }

            set
            {
                List[index] = value;
            }
        }

        #endregion

        #region - Add and Insert methods -

        /// <summary>
        /// Adds the specified <b>VerticalTabPage</b> object to the end of the collection.
        /// <seealso cref="Remove"/>
        /// <seealso cref="SetTabIndex"/>
        /// <seealso cref="VerticalTabControl"/>
        /// <seealso cref="VerticalTabPage"/>
        /// </summary>
        /// <param name="tabPage">Tab page object.</param>
        /// <returns>Index of the added object.</returns>
        public int Add(VerticalTabPage tabPage)
        {
            return List.Add(tabPage);
        }

        /// <summary>
        /// Adds a new <b>VerticalTabPage</b> object to the end of the collection, 
        /// taking the tab page's text.
        /// <seealso cref="SetTabIndex"/>
        /// <seealso cref="Remove"/>
        /// <seealso cref="VerticalTabControl"/>
        /// <seealso cref="VerticalTabPage"/>
        /// </summary>
        /// <param name="text">Tab page's text.</param>
        /// <returns>Newly created object.</returns>
        public VerticalTabPage Add(string text)
        {
            var tabPage = new VerticalTabPage(text);
            List.Add(tabPage);
            return tabPage;
        }

        /// <summary>
        /// Inserts the specified <b>VerticalTabPage</b> object into the collection.
        /// <seealso cref="Remove"/>
        /// <seealso cref="SetTabIndex"/>
        /// <seealso cref="VerticalTabControl"/>
        /// <seealso cref="VerticalTabPage"/>
        /// </summary>
        /// <param name="index">Index where the tab page will be inserted.</param>
        /// <param name="tabPage">Tab page object.</param>
        public void Insert(int index, VerticalTabPage tabPage)
        {
            List.Insert(index, tabPage);
        }

        /// <summary>
        /// Changes the index of the tab page in the collection.
        /// <seealso cref="Remove"/>
        /// <seealso cref="VerticalTabControl"/>
        /// <seealso cref="VerticalTabPage"/>
        /// </summary>
        /// <param name="tabPage">Tab page object.</param>
        /// <param name="index">New index of the tab page.</param>
        public void SetTabIndex(VerticalTabPage tabPage, int index)
        {
            // Check if tab page exsists in the collection
            if (List.Contains(tabPage))
            {
                // Remove item from the list without notifications
                InnerList.Remove(tabPage);

                // Check insert index
                if (index > Count)
                {
                    index = Count;
                }

                // Insert item into the list without notifications
                InnerList.Insert(index, tabPage);

                // Notify control that tab pages where changed
                _tabControl.OnTabPagesChanged();
            }
        }

        /// <summary>
        /// Inserts a new tab page into the collection.
        /// </summary>
        /// <param name="index">Index where the tab page will be inserted.</param>
        /// <param name="text">Tab page's text.</param>
        public void Insert(int index, string text)
        {
            var tabPage = new VerticalTabPage(text);
            List.Insert(index, tabPage);
        }

        /// <summary>
        /// Removes the specified tab page from the collection.
        /// </summary>
        /// <param name="tabPage">Tab page to remove.</param>
        public void Remove(VerticalTabPage tabPage)
        {
            List.Remove(tabPage);
        }

        #endregion

        #region - Items Inserting and Removing Notification methods -

        /// <summary>
        /// Called before an item is inserted into the collection.
        /// </summary>
        /// <param name="index">Index where the item is being inserted.</param>
        /// <param name="value">Inserted object.</param>
        protected override void OnInsert(int index, object value)
        {
            var tabPage = (VerticalTabPage)value;

            // Set referense to the tab control
            tabPage.TabControl = _tabControl;

            // Set referense to the tab control image list
            if (_tabControl.ImageList != null)
            {
                tabPage.TabButton.ImageList = _tabControl.ImageList;
            }

            // Set button orientation
            tabPage.TabButton.Vertical = _tabControl.Vertical;

            // Add panel and button controls as child controls of the TabControl
            if (!_tabControl.Contains(tabPage))
            {
                _tabControl.Controls.Add(tabPage.TabButton);
                _tabControl.Controls.Add(tabPage);
            }
        }

        /// <summary>
        /// Called before an item is removed from the collection.
        /// </summary>
        /// <param name="index">Index of the item to be removed.</param>
        /// <param name="value">Object to be removed.</param>
        protected override void OnRemove(int index, object value)
        {
            var tabPage = (VerticalTabPage)value;

            // Remove panel and button controls from child controls of the TabControl
            if (_tabControl.Contains(tabPage))
            {
                _tabControl.Controls.Remove(tabPage.TabButton);
                _tabControl.Controls.Remove(tabPage);
            }
        }

        /// <summary>
        /// Called before all items are removed from the collection.
        /// </summary>
        protected override void OnClear()
        {
            for (int tabIndex = 0; tabIndex < List.Count; tabIndex++)
            {
                OnRemove(tabIndex, List[tabIndex]);
            }
        }

        /// <summary>
        /// Called after a new item is inserted into the collection.
        /// </summary>
        /// <param name="index">Index of the inserted item.</param>
        /// <param name="value">Object that was inserted.</param>
        protected override void OnInsertComplete(int index, object value)
        {
            var tabPage = (VerticalTabPage)value;

            // Set selected item
            if (_tabControl.SelectedTab == null)
            {
                _tabControl.SelectedTab = tabPage;
            }

            // Notify control that tab pages where changed
            _tabControl.OnTabPagesChanged();
        }

        /// <summary>
        /// Called after an item is removed from the collection.
        /// </summary>
        /// <param name="index">Index of the removed item.</param>
        /// <param name="value">Object that was removed.</param>
        protected override void OnRemoveComplete(int index, object value)
        {
            var tabPage = (VerticalTabPage)value;

            // Check if selected tab page should be updated
            if (_tabControl.SelectedTab == tabPage)
            {
                int newIndex = index;
                if (newIndex >= _tabControl.TabPages.Count)
                {
                    newIndex = _tabControl.TabPages.Count - 1;
                }
                _tabControl.SelectedIndex = newIndex;
            }

            // Notify control that tab pages where changed
            _tabControl.OnTabPagesChanged();
        }

        /// <summary>
        /// Called after all items are removed from the collection.
        /// </summary>
        protected override void OnClearComplete()
        {
            // Clear selected index
            _tabControl.SelectedTab = null;

            // Notify control that tab pages where changed
            _tabControl.OnTabPagesChanged();
        }

        #endregion
    }

    /// <summary>
    /// Helper class that draws horizontally tiled image .
    /// </summary>
    public class TiledPictureBox : PictureBox
    {
        #region - Constructor -

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TiledPictureBox()
        {
            // Change control style
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        #endregion

        #region - Overriden painting methods -

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (Image != null)
            {
                using (var bitmap = new Bitmap(e.ClipRectangle.Width, e.ClipRectangle.Height))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        var imageAttributes = new ImageAttributes();
                        for (int curentX = 0; curentX < e.ClipRectangle.Width; curentX += Image.Width)
                        {
                            graphics.DrawImage(
                                Image,
                                new Rectangle(curentX, 0, Image.Width, e.ClipRectangle.Height),
                                0, e.ClipRectangle.Y, Image.Width, e.ClipRectangle.Height,
                                GraphicsUnit.Pixel,
                                imageAttributes);
                        }

                        e.Graphics.DrawImage(
                            bitmap,
                            e.ClipRectangle,
                            0, 0, bitmap.Width, bitmap.Height,
                            GraphicsUnit.Pixel,
                            imageAttributes);
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
        }

        #endregion
    }

    /// <summary>
    /// Helper class that adds background image to the label.
    /// </summary>
    public class LabelWithBackImage : Label
    {
        #region - Constructor -

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LabelWithBackImage()
        {
            // Change control style
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        #endregion

        #region - Overriden painting methods -

        internal Image BackImage = null;

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Clear background
            e.Graphics.Clear(BackColor);

            // Draw back image
            if (BackImage != null)
            {
                int imageLeft = Right - BackImage.Width - Left;
                var dest = e.ClipRectangle;
                if (dest.X < imageLeft)
                {
                    dest.Width -= imageLeft - dest.X;
                    dest.X = imageLeft;
                }
                var imageAttributes = new ImageAttributes();
                e.Graphics.DrawImage(BackImage, dest, dest.X - imageLeft, e.ClipRectangle.Y + Top, dest.Width, dest.Height, GraphicsUnit.Pixel, imageAttributes);
            }

            // Get text position
            var textRect = new Rectangle(ClientRectangle.Location, ClientRectangle.Size);
            textRect.X += 5;
            textRect.Width -= 10;

            // Draw text
            var format = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Near,
                    Trimming = StringTrimming.EllipsisCharacter,
                    FormatFlags = StringFormatFlags.LineLimit
                };
            using (var brush = new SolidBrush(ForeColor))
            {
                e.Graphics.DrawString(Text, Font, brush, textRect, format);
            }

            format.Dispose();
        }

        #endregion
    }
}

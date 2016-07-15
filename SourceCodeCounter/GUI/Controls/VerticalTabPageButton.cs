using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SourceCodeCounter.GUI.Contols
{
    public sealed partial class VerticalTabPageButton : Button
    {
		#region -Private Declarations -

		/// <summary>
		/// Indicates that button is pressed
		/// </summary>
		private	bool	_pressed;

		/// <summary>
		/// Indicates button orientation in the tab control
		/// </summary>
		private	bool	_vertical;

		/// <summary>
		/// Indicates button represent selected tab in control.
		/// </summary>
		private	bool	_selectedTab;

		/// <summary>
		/// Indicates that separator line should be drawn on the right side of the button.
		/// </summary>
		private	bool	_separatorLine = true;

        /// <summary>
        /// Offset between image and text
        /// </summary>
        private const int Offset = 4;

        /// <summary>
		/// Button border color
		/// </summary>
		internal Color	BorderColor = Color.FromArgb(191,191,191);

		/// <summary>
		/// Unselected button back color
		/// </summary>
		internal Color	NonSelectedBackColor = Color.FromArgb(229,229,229);

		/// <summary>
		/// Gradient color used for the selected tab
		/// </summary>
		internal Color	SelectedGradientBackColor = Color.FromArgb(254,218,162);

		/// <summary>
		/// Selected text color.
		/// </summary>
		internal Color	TextColorSelected = Color.FromArgb(26,59,105);

		/// <summary>
		/// UnSelected text color.
		/// </summary>
		internal Color	TextColorUnSelected = Color.FromArgb(117,117,117);

		/// <summary>
		/// Background image horizontal offset;
		/// </summary>
		public	int		BackImageOffsetX = 0;

		/// <summary>
		/// Background image vertical offset;
		/// </summary>
		public	int		BackImageOffsetY = 0;

		#endregion

		#region - Public Properties -

		/// <summary>
		/// Gets or sets the button orientation in the tab control.
		/// </summary>
		[
		Category("Misc"),
		DefaultValue(false),
		Description("Gets or sets the button orientation in the tab control."),
		]
		public bool Vertical
		{
			get
			{
				return _vertical;
			}
			set
			{
				if(_vertical != value)
				{
					_vertical = value;
					Invalidate();
				}
			}
		}

		/// <summary>
		/// Gets or sets the button orientation in the tab control.
		/// </summary>
		[
		Category("Misc"),
		DefaultValue(false),
		Description("Gets or sets the button orientation in the tab control."),
		]
		public bool SelectedTab
		{
			get
			{
				return _selectedTab;
			}
			set
			{
				if(_selectedTab != value)
				{
					_selectedTab = value;
					Invalidate();
				}
			}
		}

		/// <summary>
		/// Gets or sets the flag that determines if the separation line should be drawn on the 
		/// right side of the button.
		/// </summary>
		[
		Category("Misc"),
		DefaultValue(false),
		Description("Determines if the separation line should be drawn on the right side of the button."),
		]
		public bool SeparatorLine
		{
			get
			{
				return _separatorLine;
			}
			set
			{
				if(_separatorLine != value)
				{
					_separatorLine = value;
					Invalidate();
				}
			}
		}

		#endregion

		#region - Constructor -

		/// <summary>
		/// Default constructor.
		/// </summary>
		public VerticalTabPageButton()
		{
			// Set button style
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.ResizeRedraw, true);

			AllowDrop = true;
		}

		#endregion

		#region - Overriden methods of the base class -

		/// <summary>
		/// Called when the mouse pointer is over the control and a 
		/// mouse button is released.
		/// <seealso cref="MouseEventArgs"/>
		/// </summary>
		/// <param name="e">Event arguments.</param>
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			_pressed = false;
			Invalidate();
			Capture = false;
		}
		
		/// <summary>
		/// Called when the mouse pointer is over the control and a mouse button is 
		/// pressed.
		/// <seealso cref="MouseEventArgs"/>
		/// </summary>
		/// <param name="e">Event arguments.</param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			_pressed = true;
			Invalidate();
			Capture = true;
		}

		/// <summary>
		/// Called when the mouse pointer is moved over the control.
		/// <seealso cref="MouseEventArgs"/>
		/// </summary>
		/// <param name="e">Event arguments.</param>
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			// If left mouse button is still pressed and we moved outside of the button - start button dragging
			if( (e.Button & MouseButtons.Left) == MouseButtons.Left &&
				!ClientRectangle.Contains(e.X, e.Y))
			{
				// Make sure the button is not in pressed mode
				if(_pressed)
				{
					_pressed = false;
					Invalidate();
				}

				Capture = false;

				// fire start dragging event
				OnStartDragging();
			}
		}

		/// <summary>
		/// Called when the control is painted.
		/// <seealso cref="PaintEventArgs"/>
		/// </summary>
		/// <param name="e">Event arguments.</param>
		protected override void OnPaint( PaintEventArgs e )
		{
			DrawButton(e.Graphics);
		}

		#endregion

		#region - Button drawing methods -

		/// <summary>
		/// Draws the vertical button back onto the specified graphics.
		/// <seealso cref="Graphics"/>
		/// </summary>
		/// <param name="graphics">Button graphics object.</param>
		private void DrawVerticalButtonBack(Graphics graphics)
		{
			// Draw button border
			ButtonState buttonState = (_pressed) ? ButtonState.Pushed : ButtonState.Normal;
			ControlPaint.DrawButton(graphics, ClientRectangle, buttonState);
		}

		/// <summary>
		/// Draw horizontal button back on  the graphics specified.
		/// </summary>
		/// <param name="graphics">Button graphics object.</param>
		private void DrawHorizontalButtonBack(Graphics graphics)
		{
			// Define button radius
			var radius = (int)Math.Round(ClientRectangle.Height / 3.0);

			// Draw background image
			var tabControl = Parent as VerticalTabControl;
			if(tabControl != null && tabControl.BackgroundImage != null)
			{
				int height = tabControl.GetButtonHeight() + 1;

				// Draw image in the background of the tab controls.
				// Image must be aligne to the bottom-right corner of the tabs area.
			    var destRect = new Rectangle(tabControl.Right - tabControl.BackgroundImage.Width + tabControl.BackImageOffsetX - Left, 0, tabControl.BackgroundImage.Width, height);
				var imageAttributes = new ImageAttributes();
				graphics.DrawImage(tabControl.BackgroundImage, destRect, 0, tabControl.BackImageOffsetY + Top, tabControl.BackgroundImage.Width, height, GraphicsUnit.Pixel, imageAttributes);
			}

			// Create button border path
			using( var buttonPath = new GraphicsPath() )
			{
				// Left vertical line
				buttonPath.AddLine(ClientRectangle.X, ClientRectangle.Bottom, ClientRectangle.X, ClientRectangle.Y + radius);

				// Top left arc
				buttonPath.AddArc(ClientRectangle.X, ClientRectangle.Y, 2 * radius, 2 * radius, 180, 90);

				// Top horizontal line
				buttonPath.AddLine(ClientRectangle.X + radius, ClientRectangle.Y, ClientRectangle.Right - radius, ClientRectangle.Y);

				// Top right arc
				buttonPath.AddArc(ClientRectangle.Right - 1 - 2 * radius, ClientRectangle.Y, 2 * radius, 2 * radius, 270, 90);

				// Right vertical line
				buttonPath.AddLine(ClientRectangle.Right - 1, ClientRectangle.Y + radius, ClientRectangle.Right - 1, ClientRectangle.Bottom);

				// Bottom horizontal line
				if(!SelectedTab)
				{
					buttonPath.AddLine(ClientRectangle.X, ClientRectangle.Bottom - 1, ClientRectangle.Right, ClientRectangle.Bottom - 1);
				}

				// Fill button background
				if(SelectedTab)
				{
					var brushRect = ClientRectangle;
					using( var backBrush = new LinearGradientBrush(brushRect, SelectedGradientBackColor, BackColor, 90 ) )
					{
						var blend = new Blend(3);
						blend.Positions[0] = 0.0f;
						blend.Positions[1] = 0.8f;
						blend.Positions[2] = 1.0f;
						blend.Factors[0] = 0.0f;
						blend.Factors[1] = 1.0f;
						blend.Factors[2] = 1.0f;

						backBrush.Blend = blend;
						graphics.FillPath(backBrush, buttonPath);
					}
				}
				else
				{
					using( var backBrush = new SolidBrush( (SelectedTab) ? BackColor : NonSelectedBackColor) )
					{
						graphics.FillPath(backBrush, buttonPath);
					}
				}

				// Draw button border using Anti-Aliasing
				using( var pen = new Pen(BorderColor, 1) )
				{
					var oldMode = graphics.SmoothingMode;
					graphics.SmoothingMode = SmoothingMode.AntiAlias;
					graphics.DrawPath(pen, buttonPath);
					graphics.SmoothingMode = oldMode;
				}
			}
		}

		/// <summary>
		/// Draws the button on the specified graphics.
		/// <seealso cref="Graphics"/>
		/// </summary>
		/// <param name="graphics">Button graphics object.</param>
		private void DrawButton(Graphics graphics)
		{
			// Clear the background with the Back color
			graphics.Clear(BackColor);

			// Draw background
			if(Vertical)
			{
				DrawVerticalButtonBack(graphics);
			}
			else
			{
				DrawHorizontalButtonBack(graphics);
			}

			// Draw image
			Rectangle	imageRect = Rectangle.Empty;
			if(Image != null)
			{
				// Calculate image rectangle position
				imageRect.X = ClientRectangle.X + Offset;
				imageRect.Y = ClientRectangle.Y + (ClientRectangle.Height - Image.Height) / 2;
				imageRect.Width = Image.Width;
				imageRect.Height = Image.Height;

				// Shift image by 1 pixel when in pressed state
				if(_pressed && Vertical)
				{
					++imageRect.X;
					++imageRect.Y;
				}

				// Replace transparent color (White) with button back color 
				var myColorMap = new ColorMap[1];
				myColorMap[0] = new ColorMap {OldColor = Color.White, NewColor = BackColor};

			    // Create an ImageAttributes object
				var imageAttr = new ImageAttributes();
				imageAttr.SetRemapTable(myColorMap);

				// Draw image
				graphics.DrawImage(Image, imageRect, 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel, imageAttr);

				imageAttr.Dispose();
			}

			// Draw button text
			if(Text.Length > 0)
			{
				var	textRect = new Rectangle(ClientRectangle.Location, ClientRectangle.Size);
				textRect.X += Offset - 2;
				textRect.Width -= 2 * Offset;
				if(Image != null)
				{
					textRect.X += Offset + Image.Width;
					textRect.Width -= Offset + Image.Width;
				}
				
				// Shift image by 1 pixel when in pressed state
				if(_pressed && Vertical)
				{
					++textRect.X;
					++textRect.Y;
				}

				var format = new StringFormat
				    {
				        LineAlignment = StringAlignment.Center,
				        Alignment = StringAlignment.Center,
				        Trimming = StringTrimming.EllipsisCharacter,
				        FormatFlags = StringFormatFlags.LineLimit
				    };
			    using( var brush = new SolidBrush( (SelectedTab) ? TextColorSelected : TextColorUnSelected ) )
				{
					graphics.DrawString(Text, Font, brush, textRect, format);
				}

				format.Dispose();
			}

		}

		#endregion

		#region - Events Handlers -

		/// <summary>
		/// This event is called when a mouse button is dragged with the mouse.
		/// </summary>
		public event EventHandler StartDragging;

		/// <summary>
		/// Event is called when  a mouse button is dragged with the mouse.
		/// </summary>
		private void OnStartDragging()
		{
			if(StartDragging != null)
			{
				StartDragging(this, new EventArgs());
			}
		}

		#endregion
    }
}

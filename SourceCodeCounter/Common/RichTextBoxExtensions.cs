using System;
using System.Drawing;
using System.Windows.Forms;

namespace SourceCodeCounter.Common
{
    /// <summary>
    /// RichTextBox Extension, to color code the string we are writing
    /// </summary>
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox richTextBox, string text, Color color)
        {
            richTextBox.SelectionStart = richTextBox.TextLength;
            richTextBox.SelectionLength = 0;

            richTextBox.SelectionColor = color;
            richTextBox.AppendText(text);
            richTextBox.SelectionColor = richTextBox.ForeColor;
        }

        public static void LogException(this RichTextBox richTextBox, Exception exception)
        {
            AppendText(richTextBox, exception.ToLogString("Exception"), Color.Purple);
        }
        public static void CompleteException(this RichTextBox richTextBox, Exception exception)
        {
            AppendText(richTextBox, exception.CompleteMessage(), Color.Red);
        }
    }
}
using System;
using System.Windows.Forms;

namespace SourceCodeCounter.Core
{
    public abstract class OutputLogger
    {
        //
        // Summary:
        //     Writes the current line terminator to the standard output stream.
        //
        // Exceptions:
        //   System.IO.IOException:
        //     An I/O error occurred.
        public abstract void WriteLine();
        //
        // Summary:
        //     Writes the text representation of the specified Boolean value, followed by
        //     the current line terminator, to the standard output stream.
        //
        // Parameters:
        //   value:
        //     The value to write.
        //
        // Exceptions:
        //   System.IO.IOException:
        //     An I/O error occurred.
        public abstract void WriteLine(bool value);
        //
        // Summary:
        //     Writes the specified Unicode character, followed by the current line terminator,
        //     value to the standard output stream.
        //
        // Parameters:
        //   value:
        //     The value to write.
        //
        // Exceptions:
        //   System.IO.IOException:
        //     An I/O error occurred.
        public abstract void WriteLine(char value);
        //
        // Summary:
        //     Writes the specified array of Unicode characters, followed by the current
        //     line terminator, to the standard output stream.
        //
        // Parameters:
        //   buffer:
        //     A Unicode character array.
        //
        // Exceptions:
        //   System.IO.IOException:
        //     An I/O error occurred.
        public abstract void WriteLine(char[] buffer);
        //
        // Summary:
        //     Writes the text representation of the specified System.Decimal value, followed
        //     by the current line terminator, to the standard output stream.
        //
        // Parameters:
        //   value:
        //     The value to write.
        //
        // Exceptions:
        //   System.IO.IOException:
        //     An I/O error occurred.
        public abstract void WriteLine(decimal value);
        //
        // Summary:
        //     Writes the text representation of the specified double-precision floating-point
        //     value, followed by the current line terminator, to the standard output stream.
        //
        // Parameters:
        //   value:
        //     The value to write.
        //
        // Exceptions:
        //   System.IO.IOException:
        //     An I/O error occurred.
        public abstract void WriteLine(double value);
        //
        // Summary:
        //     Writes the text representation of the specified single-precision floating-point
        //     value, followed by the current line terminator, to the standard output stream.
        //
        // Parameters:
        //   value:
        //     The value to write.
        //
        // Exceptions:
        //   System.IO.IOException:
        //     An I/O error occurred.
        public abstract void WriteLine(float value);
        //
        // Summary:
        //     Writes the text representation of the specified 32-bit signed integer value,
        //     followed by the current line terminator, to the standard output stream.
        //
        // Parameters:
        //   value:
        //     The value to write.
        //
        // Exceptions:
        //   System.IO.IOException:
        //     An I/O error occurred.
        public abstract void WriteLine(int value);
        //
        // Summary:
        //     Writes the text representation of the specified 64-bit signed integer value,
        //     followed by the current line terminator, to the standard output stream.
        //
        // Parameters:
        //   value:
        //     The value to write.
        //
        // Exceptions:
        //   System.IO.IOException:
        //     An I/O error occurred.
        public abstract void WriteLine(long value);
        //
        // Summary:
        //     Writes the text representation of the specified object, followed by the current
        //     line terminator, to the standard output stream.
        //
        // Parameters:
        //   value:
        //     The value to write.
        //
        // Exceptions:
        //   System.IO.IOException:
        //     An I/O error occurred.
        public abstract void WriteLine(object value);
        //
        // Summary:
        //     Writes the specified string value, followed by the current line terminator,
        //     to the standard output stream.
        //
        // Parameters:
        //   value:
        //     The value to write.
        //
        // Exceptions:
        //   System.IO.IOException:
        //     An I/O error occurred.
        public abstract void WriteLine(string value);
        //
        // Summary:
        //     Writes the text representation of the specified 32-bit unsigned integer value,
        //     followed by the current line terminator, to the standard output stream.
        //
        // Parameters:
        //   value:
        //     The value to write.
        //
        // Exceptions:
        //   System.IO.IOException:
        //     An I/O error occurred.
        //
        // Summary:
        //     Writes the text representation of the specified object, followed by the current
        //     line terminator, to the standard output stream using the specified format
        //     information.
        //
        // Parameters:
        //   format:
        //     A composite format string (see Remarks).
        //
        //   arg0:
        //     An object to write using format.
        //
        // Exceptions:
        //   System.IO.IOException:
        //     An I/O error occurred.
        //
        //   System.ArgumentNullException:
        //     format is null.
        //
        //   System.FormatException:
        //     The format specification in format is invalid.
        public abstract void WriteLine(string format, object arg0);
        //
        // Summary:
        //     Writes the text representation of the specified array of objects, followed
        //     by the current line terminator, to the standard output stream using the specified
        //     format information.
        //
        // Parameters:
        //   format:
        //     A composite format string (see Remarks).
        //
        //   arg:
        //     An array of objects to write using format.
        //
        // Exceptions:
        //   System.IO.IOException:
        //     An I/O error occurred.
        //
        //   System.ArgumentNullException:
        //     format or arg is null.
        //
        //   System.FormatException:
        //     The format specification in format is invalid.
        public abstract void WriteLine(string format, params object[] arg);
        //
        // Summary:
        //     Writes the text representation of the specified objects, followed by the
        //     current line terminator, to the standard output stream using the specified
        //     format information.
        //
        // Parameters:
        //   format:
        //     A composite format string (see Remarks).
        //
        //   arg0:
        //     The first object to write using format.
        //
        //   arg1:
        //     The second object to write using format.
        //
        // Exceptions:
        //   System.IO.IOException:
        //     An I/O error occurred.
        //
        //   System.ArgumentNullException:
        //     format is null.
        //
        //   System.FormatException:
        //     The format specification in format is invalid.
        public abstract void WriteLine(string format, object arg0, object arg1);
        //
        // Summary:
        //     Writes the text representation of the specified objects, followed by the
        //     current line terminator, to the standard output stream using the specified
        //     format information.
        //
        // Parameters:
        //   format:
        //     A composite format string (see Remarks).
        //
        //   arg0:
        //     The first object to write using format.
        //
        //   arg1:
        //     The second object to write using format.
        //
        //   arg2:
        //     The third object to write using format.
        //
        // Exceptions:
        //   System.IO.IOException:
        //     An I/O error occurred.
        //
        //   System.ArgumentNullException:
        //     format is null.
        //
        //   System.FormatException:
        //     The format specification in format is invalid.
        public abstract void WriteLine(string format, object arg0, object arg1, object arg2);
        //
        // Summary:
        //     Writes the text representation of the specified objects and variable-length
        //     parameter list, followed by the current line terminator, to the standard
        //     output stream using the specified format information.
        //
        // Parameters:
        //   format:
        //     A composite format string (see Remarks).
        //
        //   arg0:
        //     The first object to write using format.
        //
        //   arg1:
        //     The second object to write using format.
        //
        //   arg2:
        //     The third object to write using format.
        //
        //   arg3:
        //     The fourth object to write using format.
        //
        // Exceptions:
        //   System.IO.IOException:
        //     An I/O error occurred.
        //
        //   System.ArgumentNullException:
        //     format is null.
        //
        //   System.FormatException:
        //     The format specification in format is invalid.
        public abstract void WriteLine(string format, object arg0, object arg1, object arg2, object arg3);
    }

    public class RichTextLogger: OutputLogger
    {
        private RichTextBox _logger;

        public RichTextLogger(RichTextBox richTextBox)
        {
            _logger = richTextBox;
        }
        public override void WriteLine()
        {
            _logger.AppendText(Environment.NewLine);
        }

        public override void WriteLine(bool value)
        {
            _logger.AppendText(string.Format("{0}\n", value));
        }

        public override void WriteLine(char value)
        {
            _logger.AppendText(string.Format("{0}\n", value));
        }

        public override void WriteLine(char[] buffer)
        {
            _logger.AppendText(string.Format("{0}\n", buffer));
        }

        public override void WriteLine(decimal value)
        {
            _logger.AppendText(string.Format("{0}\n", value));
        }

        public override void WriteLine(double value)
        {
            _logger.AppendText(string.Format("{0}\n", value));
        }

        public override void WriteLine(float value)
        {
            _logger.AppendText(string.Format("{0}\n", value));
        }

        public override void WriteLine(int value)
        {
            _logger.AppendText(string.Format("{0}\n", value));
        }

        public override void WriteLine(long value)
        {
            _logger.AppendText(string.Format("{0}\n", value));
        }

        public override void WriteLine(object value)
        {
            _logger.AppendText(string.Format("{0}\n", value));
        }

        public override void WriteLine(string value)
        {
            _logger.AppendText(string.Format("{0}\n", value));
        }

        public override void WriteLine(string format, object arg0)
        {
            _logger.AppendText(string.Format(format + Environment.NewLine, arg0));
        }

        public override void WriteLine(string format, params object[] arg)
        {
            _logger.AppendText(string.Format(format + Environment.NewLine, arg));
        }

        public override void WriteLine(string format, object arg0, object arg1)
        {
            _logger.AppendText(string.Format(format + Environment.NewLine, arg0, arg1));
        }

        public override void WriteLine(string format, object arg0, object arg1, object arg2)
        {
            _logger.AppendText(string.Format(format + Environment.NewLine, arg0, arg1, arg2));
        }

        public override void WriteLine(string format, object arg0, object arg1, object arg2, object arg3)
        {
            _logger.AppendText(string.Format(format + Environment.NewLine, arg0, arg1, arg2, arg3));
        }
    }
}

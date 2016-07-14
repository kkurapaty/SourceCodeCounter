using System;
using System.Text;
using System.Windows.Forms;

namespace SourceCodeCounter.Common
{
    public static class ObjectExtensions
    {
        public static bool Assigned(this object obj)
        {
            return (obj != null);
        }

        /// <summary>
        ///     An object extension method that cast anonymous type to the specified type.
        /// </summary>
        /// <typeparam name="T">Generic type parameter. The specified type.</typeparam>
        /// <param name="value">The value to act on.</param>
        /// <returns>The object as the specified type.</returns>
        public static T As<T>(this object value)
        {
            return (T)value;
        }

        /// <summary>
        ///     A T extension method that can return the first not null value (including the value).
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="value">The value to act on.</param>
        /// <param name="values">A variable-length parameters list containing values.</param>
        /// <returns>The first not null value.</returns>
        public static T Coalesce<T>(this T value, params T[] values) where T : class
        {
            if (value != null)
            {
                return value;
            }

            foreach (T val in values)
            {
                if (val != null)
                {
                    return val;
                }
            }

            return null;
        }

        /// <summary>
        /// Usage: userControl.InvokeIfRequired(c => { c.Visible = true; });
        /// </summary>
        /// <param name="control"></param>
        /// <param name="action"></param>
        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }
        public static void InvokeIfRequired(this Control c, Action<Control> action)
        {
            if (c.InvokeRequired)
            {
                c.Invoke(new Action(() => action(c)));
            }
            else
            {
                action(c);
            }
        }

        public static string AsString(this TimeSpan timeSpan)
        {
            // Format and display the TimeSpan value. 
            var elapsedTime = new StringBuilder();

            if (timeSpan.Days > 0) elapsedTime.AppendFormat("{0:00} days", timeSpan.Days);
            if (timeSpan.Hours > 0) elapsedTime.AppendFormat(" {0:00} mins", timeSpan.Hours);
            if (timeSpan.Minutes > 0) elapsedTime.AppendFormat(" {0:00} secs", timeSpan.Minutes);
            if (timeSpan.Milliseconds > 0) elapsedTime.AppendFormat(" {0:00} msec", timeSpan.Milliseconds);

            return elapsedTime.ToString();
        }
    }

}
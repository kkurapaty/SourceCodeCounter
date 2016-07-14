using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace SourceCodeCounter.Common
{
    /// <summary>
    /// This class contains extension functions for enum type
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Returns description of enum value if attached with enum member through DiscriptionAttribute
        /// </summary>        
        /// <returns>Description of enum value</returns>
        /// <see cref="DescriptionAttribute"/>
        public static string ToDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            var descriptions = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return (descriptions.Length > 0) ? descriptions[0].Description : fi.Name;
        }

        /// <summary>
        /// Returns true if enum matches any of the given values
        /// </summary>
        /// <param name="value">Value to match</param>
        /// <param name="values">Values to match against</param>
        /// <returns>Return true if matched</returns>
        public static bool In(this Enum value, params Enum[] values)
        {
            return values.Any(x => Equals(x, value));
        }
    }
}
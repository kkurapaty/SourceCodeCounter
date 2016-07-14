//-----------------------------------------------------------------------
// <copyright file="CharExtension.cs" company="Morgan Stanley">
//     Copyright (c) 2014 Morgan Stanley All rights reserved
// </copyright>
//-----------------------------------------------------------------------

namespace SourceCodeCounter.Common
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed.")]
    public static class CharExtension
    {
        /// <summary>
        /// Checks for character existence
        /// </summary>
        /// <param name="value">Source Character</param>
        /// <param name="chars">Array of characters</param>
        /// <returns>true if exists, otherwise false</returns>
        public static bool In(this char value, params char[] chars)
        {
            return chars.Any(c => c == value);
        }
    }
}
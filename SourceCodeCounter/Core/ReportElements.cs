using System;

namespace SourceCodeCounter.Core
{
    /// <summary>
    /// Specifies the visible elements in a report.
    /// </summary>
    [Flags]
    public enum ReportElements
    {
        /// <summary>Show file elements in a report.</summary>
        Files = 1,

        /// <summary>Show projects elements in a report.</summary>
        Projects = 2,

        /// <summary>Show summary element in a report.</summary>
        Summary = 4
    }
}
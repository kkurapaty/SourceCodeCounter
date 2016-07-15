using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SourceCodeCounter.Common;
using SourceCodeCounter.Properties;

namespace SourceCodeCounter.Parsers
{
    public class ParserFactory
    {
        #region - Parser Identifier -

        public static BaseParser GetParser(string extension)
        {
            extension = extension.ToLower().Trim();
            if (extension.In(".p", ".pp")) return PascalParser.Instance;
            if (extension.In(".pas", ".dpr", ".dproj")) return DelphiParser.Instance;
            if (extension.In(".cs")) return CSharpParser.Instance;
            if (extension.In(".java", ".c", ".cpp", ".h", ".hpp", ".cc", ".hh", ".cxx", ".hxx"))
                return CParser.Instance;
            if (extension.In(".vb", ".bas", ".cls", ".frm")) return VisualBasicParser.Instance;
            if (extension.In(".sql")) return SqlParser.Instance;
            throw new ArgumentException(Resources.Resource_UnsupportedFileType, "extension");
        }

        #endregion
    }
}

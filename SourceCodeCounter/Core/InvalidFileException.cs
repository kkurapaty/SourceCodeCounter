using System;

namespace SourceCodeCounter.Core
{
    /// <summary>
    /// The exception that is thrown when a <see cref="SourceFile"/> object 
    /// contains invalid file informations.
    /// </summary>
    public class InvalidFileException : Exception
    {
        readonly SourceFile _file;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidFileException"/> 
        /// class with a specified source file.
        /// </summary>
        /// <param name="file">The source file that caused the exception.</param>
        public InvalidFileException(SourceFile file)
            : this(file, (Exception)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidFileException"/> 
        /// class with a specified source file and error message.
        /// </summary>
        /// <param name="file">The source file that caused the exception.</param>
        /// <param name="message"></param>
        public InvalidFileException(SourceFile file, string message)
            : base(message)
        {
            _file = file;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidFileException"/> 
        /// class with a specified source file and a reference to the inner 
        /// exception that is the cause of this exception.
        /// </summary>
        /// <param name="file">The source file that caused the exception.</param>
        /// <param name="inner">The exception that is the cause of the current 
        /// exception. If the inner arguments is not null, the current exception 
        /// is raised in a catch block that handles the inner exception.</param>
        public InvalidFileException(SourceFile file, Exception inner)
            : base("Invalid file: '" + file.Path + "'", inner)
        {
            _file = file;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidFileException"/> 
        /// class with a specified file and error message and a reference to the 
        /// inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="file">The source file that caused the exception.</param>
        /// <param name="message">The error message that explains the reason for 
        /// the exception.</param>
        /// <param name="inner">The exception that is the cause of the current 
        /// exception. If the inner arguments is not null, the current exception 
        /// is raised in a catch block that handles the inner exception.</param>
        public InvalidFileException(SourceFile file, string message, Exception inner)
            : base(message, inner)
        {
            _file = file;
        }

        /// <summary>
        /// Gets the source file that caused the exception.
        /// </summary>
        public SourceFile SourceFile
        {
            get { return _file; }
        }
    }
}
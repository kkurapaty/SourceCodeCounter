using System;

namespace SourceCodeCounter.Core
{
    /// <summary>
    /// The exception that is thrown when a command-line argument is invalid.
    /// </summary>
    internal class InvalidArgumentException : Exception
    {
        readonly string _argument;

        public InvalidArgumentException(string argument)
            : base("Invalid argument: '" + argument + "'")
        {
            _argument = argument;
        }

        public InvalidArgumentException(string argument, string message)
            : base(message)
        {
            _argument = argument;
        }

        public InvalidArgumentException(string argument, string message, Exception inner)
            : base(message, inner)
        {
            _argument = argument;
        }

        public InvalidArgumentException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public string Argument
        {
            get { return _argument; }
        }
    }
}
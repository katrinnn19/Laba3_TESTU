using System;

namespace Fotius.Example.Todo
{
    public class StorageException : Exception
    {
        public StorageException() : base()
        {
        }

        public StorageException(string message) : base(message)
        {
        }

        public StorageException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

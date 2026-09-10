using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
    public class DuplicateIdException : Exception
    {
        public DuplicateIdException(string message) : base(message)
        {
        }
    }

    public class UniversityNotFoundException : Exception
    {
        public UniversityNotFoundException(string message) : base(message)
        {
        }
    }
}

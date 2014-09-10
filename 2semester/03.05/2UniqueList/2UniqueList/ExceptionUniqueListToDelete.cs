using System;

namespace _2UniqueList
{
    [Serializable]
    public class ExceptionUniqueListToDelete : ApplicationException
    {
        public ExceptionUniqueListToDelete()
        { }

        public ExceptionUniqueListToDelete(string message): base(message)
        { }
    }
}

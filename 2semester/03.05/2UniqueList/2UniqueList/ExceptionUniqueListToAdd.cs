using System;

namespace _2UniqueList
{
    [Serializable]
    public class ExceptionUniqueListToAdd : ApplicationException
    {
        public ExceptionUniqueListToAdd()
        { }

        public ExceptionUniqueListToAdd(string message): base(message)
        { }
    }
}

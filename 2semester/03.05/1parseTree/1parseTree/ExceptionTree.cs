using System;

namespace _1parseTree
{
    /// <summary>
    /// Class exception in tree.
    /// </summary>
    [Serializable]
    public class ExceptionTree : ApplicationException
    {
        public ExceptionTree()
        { }

        public ExceptionTree(string message): base(message)
        { }
    }
}

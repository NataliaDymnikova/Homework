using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2HashTableWithFunction
{
    /// <summary>
    /// Class exception in hash table.
    /// </summary>
    public class ExceptionHash : ApplicationException
    {
        public ExceptionHash()
        { }

        public ExceptionHash(string message): base(message)
        { }
    }
}

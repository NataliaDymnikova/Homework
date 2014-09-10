using System;

namespace _2UniqueList
{
    class Program
    {
        static void Main(string[] args)
        {
            UniqueList list = new UniqueList();
            list.AddElement(2);
            try
            {
                list.AddElement(2);
            }
            catch (ExceptionUniqueListToAdd except)
            {
                Console.WriteLine("Error: " + except.Message);
            }
        }
    }
}

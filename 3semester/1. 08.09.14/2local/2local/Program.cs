using System;

namespace _2local
{
    // You have to put in your file this information:
    // number of computers - N
    // matrix N x N - which computers have connect..
    // list of OS, like - "1 mac". But you have to put number in ascending.
    // array with numbers infected computers (start with 1)
    // number of OS
    // list os name OS with the chance of infection, like "mac 100".
    class Program
    {
        static void Main(string[] args)
        {
            Network network = new Network("../../in.txt");
        }
    }
}

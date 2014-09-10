using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4CursorControl
{
    public class CursorControl
    {
        public void OnLeft(object sender, EventArgs args)
        {
            if (Console.CursorLeft - 1 >= 0)
            {
                Console.CursorLeft--;
                if (Console.CursorLeft + 1 < 80)
                {
                    Console.Write("_");
                    Console.CursorLeft--;
                }
            }
        }

        public void OnRight(object sender, EventArgs args)
        {
            if (Console.CursorLeft + 1 < 79)
                Console.CursorLeft++;
            if (Console.CursorLeft + 1 < 80)
            {
                Console.Write("_");
                Console.CursorLeft--;
            }
        }

        public void OnUp(object sender, EventArgs args)
        {
            if (Console.CursorTop - 1 > 0)
            {
                if (Console.CursorLeft + 1 < 80)
                {
                    Console.Write("|");
                    Console.CursorLeft--;
                }
                Console.CursorTop--;
            }
        }
        
        public void OnDown(object sender, EventArgs args)
        {
            if (Console.CursorTop + 1 < 25)
            {
                Console.CursorTop++;
                if (Console.CursorLeft + 1 < 80)
                {
                    Console.Write("|");
                    Console.CursorLeft--;
                }
            }
        }
    }
}

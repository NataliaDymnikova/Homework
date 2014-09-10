using System;

namespace _4CursorControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Escape to exit.");
            var eventLoop = new EventLoop();
            var cursor = new CursorControl();

            eventLoop.LeftHandler += cursor.OnLeft;
            eventLoop.RightHandler += cursor.OnRight;
            eventLoop.UpHandler += cursor.OnUp;
            eventLoop.DownHandler += cursor.OnDown;

            eventLoop.Run();
        }
    }
}

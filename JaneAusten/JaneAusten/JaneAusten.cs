using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    class JaneAusten
    {
        static void Main()
        {
            const int consoleWidth = 50;
            const int consoleHeight = 30;

            Console.WindowWidth = consoleWidth;
            Console.WindowHeight = consoleHeight;

            Console.BufferHeight = Console.WindowHeight;      //Remove scrollbar
            Console.BufferWidth = Console.WindowWidth;        //Remove scrollbar

            Engine.Run();
        }
    }
}

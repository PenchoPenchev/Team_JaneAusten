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
           

            //while (true)
            //{
            //    System.Threading.Thread.Sleep(1000);
            //}

            Console.BufferHeight = Console.WindowHeight = 35;      //Remove scrollbar
            Console.BufferWidth = Console.WindowWidth = 100;        //Remove scrollbar

            Engine.Run();
        }


    }
}

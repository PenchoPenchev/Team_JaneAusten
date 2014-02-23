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

            Console.BufferHeight = Console.WindowHeight = 36;      //Remove scrollbar
            Console.BufferWidth = Console.WindowWidth = 100;        //Remove scrollbar

            StartMenu.DrawMenu();
        }


    }
}

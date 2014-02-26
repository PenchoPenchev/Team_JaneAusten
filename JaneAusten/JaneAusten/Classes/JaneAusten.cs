using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    class JaneAusten
    {
        event EventHandler OnPKeyPressed;
        static void Main()
        {

            Console.BufferHeight = Console.WindowHeight = 36;      //Remove scrollbar
            Console.BufferWidth = Console.WindowWidth = 100;        //Remove scrollbar

            Console.CursorVisible = false;
            StartMenu.DrawMenu();

            Console.CancelKeyPress += new ConsoleCancelEventHandler(CtrlCHandlerHandler);

            //protected static void CtrlCHandlerHandler(object sender, ConsoleCancelEventArgs args)
            //{
            //    // Announce that the event handler has been invoked.
            //    Console.WriteLine("\nThe read operation has been interrupted.");

            //    // Announce which key combination was pressed.
            //    Console.WriteLine("  Key pressed: {0}", args.SpecialKey);

            //    // Announce the initial value of the Cancel property.
            //    Console.WriteLine("  Cancel property: {0}", args.Cancel);

            //    // Set the Cancel property to true to prevent the process from terminating.
            //    Console.WriteLine("Setting the Cancel property to true...");
            //    args.Cancel = true;

            //}
        }

        private static void CtrlCHandlerHandler(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine("\nThe read operation has been interrupted.\n");
         //   e.Cancel = true;
        }

    }
}

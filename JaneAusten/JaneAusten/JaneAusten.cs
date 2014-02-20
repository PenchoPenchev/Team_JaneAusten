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
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 2000;
            //aTimer.Enabled = true;

            //while (true)
            //{
            //    System.Threading.Thread.Sleep(1000);
            //}

            Console.BufferHeight = Console.WindowHeight = 36;      //Remove scrollbar
            Console.BufferWidth = Console.WindowWidth = 100;        //Remove scrollbar

            Engine.Run();
        }

        private static void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine(DateTime.Now);
        }
    }
}

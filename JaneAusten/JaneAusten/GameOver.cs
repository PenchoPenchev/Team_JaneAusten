using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JaneAusten
{
    public class GameOver
    {
        public static void Display()
        {
            using (StreamReader sr = new StreamReader(@"../../Content/GAME_OVER.txt"))
            {
                string text =
@"
██████╗  █████╗ ███╗   ███╗███████╗     ██████╗ ██╗   ██╗███████╗██████╗ 
██╔════╝ ██╔══██╗████╗ ████║██╔════╝    ██╔═══██╗██║   ██║██╔════╝██╔══██╗
██║  ███╗███████║██╔████╔██║█████╗      ██║   ██║██║   ██║█████╗  ██████╔╝
██║   ██║██╔══██║██║╚██╔╝██║██╔══╝      ██║   ██║╚██╗ ██╔╝██╔══╝  ██╔══██╗
╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗    ╚██████╔╝ ╚████╔╝ ███████╗██║  ██║
 ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝     ╚═════╝   ╚═══╝  ╚══════╝╚═╝  ╚═╝
"
                    ;

                string bunny = sr.ReadToEnd().ToString();

                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine(text);
                Console.WriteLine("\t\t\tYour Score: {0}", Engine.score);

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(bunny);

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Press enter to start new game and escape to exit.");
                while (true)
                {
                    if (Console.KeyAvailable)
                    {

                        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                        while (Console.KeyAvailable)
                        {
                            Console.ReadKey(true);
                        }

                        if (pressedKey.Key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                            StartMenu.DrawMenu();
                        }
                        else if (pressedKey.Key == ConsoleKey.Escape)
                        {
                            Console.Clear();
                            Console.SetCursorPosition(0, 0);
                            break;
                        }
                    }
                }

            }
        }
    }
}

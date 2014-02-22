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
                Console.WriteLine("\n                            Your Score: {0}", Engine.score);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(bunny);
            }
        }

    }
}

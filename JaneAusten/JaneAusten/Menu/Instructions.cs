using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JaneAusten.Menu
{
    public class Instructions
    {
        private static const string fileName = @"..\..\Content\Instructions.txt";

        public static void DisplayInstructions()
        {
            StreamReader reader = new StreamReader(fileName);
            using (reader)
            {
                reader.ReadToEnd();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(reader.ToString());
            }

            while (true)
            {
                if (Console.KeyAvailable)
                {

                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }

                    if (pressedKey.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        StartMenu.DrawMenu();
                    }
                }
            }
        }
    }
}

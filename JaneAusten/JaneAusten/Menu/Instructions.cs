using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JaneAusten.Menu
{
    public class Instructions
    {
        private const string fileName = @"..\..\Content\Instructions.txt";

        public static void DisplayInstructions()
        {
            StreamReader reader = new StreamReader(fileName);
            using (reader)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(reader.ReadToEnd().ToString());
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public static class LevelDifficulty
    {
        private const string menuPath = @"..\..\Content\DifficultyMenu.txt";
        private const string enter = "Press enter to selet difficulty";
        private const string escape = "Press escape to go to hero choice";
        private const int cursorTopMedium = 15;
        private const int cursorMovement = 5;
        private const int initialCursorLeft = 32;
        private const int initialCursorTop = 10;
        private const int maxCursorTop = 20;
        public static StringBuilder ReadComponents()
        {
            StringBuilder component = new StringBuilder();
            try
            {
                using (StreamReader sr = new StreamReader(menuPath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        component.AppendLine(line);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file {0} can not be found!", menuPath);
            }
            return component;
        }
        public static void DrawDifficulty(HeroMenu hero)
        {
            var cursor = new Cursor();
            cursor.Left = initialCursorLeft;
            cursor.Top = initialCursorTop;

            while (true)
            {
                if (Console.KeyAvailable)
                {

                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }

                    if (pressedKey.Key == ConsoleKey.UpArrow)
                    {
                        if (cursor.Top > initialCursorTop)
                        {
                            cursor.Top -= cursorMovement;

                        }
                    }
                    else if (pressedKey.Key == ConsoleKey.DownArrow)
                    {
                        if (cursor.Top < maxCursorTop)
                        {
                            cursor.Top += cursorMovement;

                        }
                    }
                    else if (pressedKey.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        var archerMenu = new ArcherMenu();
                        archerMenu.PrintHeroMenu();
                    }
                    else if (pressedKey.Key == ConsoleKey.Enter)
                    {

                        if (cursor.Top == initialCursorTop) 
                        {
                            Console.Clear();
                            Engine.Run(hero, 1);
                            break;
                        }
                        else if (cursor.Top == cursorTopMedium) 
                        {
                            Console.Clear();
                            Engine.Run(hero, 2);
                            break;
                        }
                        else if (cursor.Top == maxCursorTop) 
                        {
                            Console.Clear();
                            Engine.Run(hero, 3);
                            break;
                        }
                    }
                }
                StartMenu.DrawComponent(LevelDifficulty.ReadComponents().ToString(), 0, 0, ConsoleColor.DarkGreen);
                StartMenu.DrawComponent(Cursor.body, cursor.Left, cursor.Top, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(escape, 63, 31, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(enter, 63, 33, ConsoleColor.DarkYellow);
                System.Threading.Thread.Sleep(200);

            }
        }
    }
}

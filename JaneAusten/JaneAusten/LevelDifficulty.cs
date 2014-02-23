using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public static class LevelDifficulty
    {
        private const string enter = "Press enter to selet difficulty";
        private const string escape = "Press escape to go to hero choice";
        private const int cursorTopMedium = 14;
        private const int cursorMovement = 5;
        private const int initialCursorLeft = 32;
        private const int initialCursorTop = 9;
        private const int maxCursorTop = 19;
        private const string enterDifficulty = @"

                     ▄▄▄ ▄  ▄ ▄▄▄ ▄▄▄ ▄▄▄ ▄▄▄    ▄ ▄ ▄▄▄ ▄▄▄ ▄ ▄▄▄ ▄ ▄ ▄  ▄▄▄ ▄  ▄ ▄
                     █   █▄▄█ █ █ █ █ █▄▄ █▄▄  ▄▄█ █ █▄  █▄  █ █   █ █ █   █   ▀█  
                     █▄▄ █  █ █▄█ █▄█ ▄▄█ █▄▄  █▄█ █ █   █   █ █▄▄ █▄█ █▄▄ █   █   ▄  ";
        private const string easy = @"

                                         ▄▄▄ ▄▄▄▄ ▄▄▄ ▄  ▄  
                                         █▄▄ █▄▄█ █▄▄  ▀█ 
                                         █▄▄ █  █ ▄▄█  █  ";
        private const string medium = @"

                                     ▄▄▄▄▄ ▄▄▄   ▄ ▄ ▄ ▄ ▄▄▄▄▄
                                     █ █ █ █▄▄ ▄▄█ █ █ █ █ █ █
                                     █ █ █ █▄▄ █▄█ █ █▄█ █ █ █  ";
        private const string hard = @"

                                        ▄  ▄ ▄▄▄▄ ▄▄▄   ▄
                                        █▄▄█ █▄▄█ █▄█ ▄▄█
                                        █  █ █  █ █▀▄ █▄█   ";


        public static void DrawDifficulty()
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
                            Engine.Run();
                            
                        }
                        else if (cursor.Top == cursorTopMedium) 
                        {
                            Console.Clear();
                            Engine.Run();

                        }
                        else if (cursor.Top == maxCursorTop) 
                        {
                            Console.Clear();
                            Engine.Run();

                        }
                    }
                }
                StartMenu.DrawComponent(enterDifficulty, 30, 0, ConsoleColor.DarkGreen);
                StartMenu.DrawComponent(easy, 30, 6, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(medium, 30, 11, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(hard, 30, 16, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(Cursor.body, cursor.Left, cursor.Top, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(escape, 63, 30, ConsoleColor.DarkGreen);
                StartMenu.DrawComponent(enter, 63, 32, ConsoleColor.DarkGreen);
                System.Threading.Thread.Sleep(200);

            }
        }
    }
}

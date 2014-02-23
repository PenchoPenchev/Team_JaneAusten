using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public static class StartMenu
    {
        private const int initialCursorTop = 20;
        private const int initialCursorLeft = 24;
        private const int maxCursorTop = 29;
        private const int cursorMovement = 3;
        private const int cursorTopInstructions = 22;
        private const int cursorTopHighScores = 20;
        private const string menuPath = @"..\..\Content\StartMenu.txt";
        public const string gameName = @"
══╗ ╔══╝   ║   ▄█    █▄      ▄████████    ▄████████  ▄██████▄     ▄████████ ╔▄████████  ╔════╝  ╚══
  ║ ║      ║  ███    ███    ███    ███   ███    ███ ███    ███   ███    ███ ║███        ║   ╔══════
  ║ ║ ║ ╔═══▀▀███▀▀▀▀███▀╗▀▀███▀▀▀     ▀▀███▀▀▀▀▀   ███    ███ ▀▀███▀▀▀     ║▀███████████   ║ ║   ╔
  ║   ║ ║   ║ ███    ███ ║ ║███    █▄  ▀███████████ ███    ███   ███    █▄  ║         ███   ║ ║   ║
  ║   ║ ║   ║ ███    █▀  ║ ║██████████   ███    ███  ▀██████▀    ██████████ ║ ▄████████▀    ║ ║   ║
══╝         ╚════════════╝ ╚═════════════███    ███═════════════════════════╝ ╚═════════════╝     ║                            
              
═══╝     ═════╗ ╔═════════════════════════╗  ╔═════════════════════════════════════╗         ║    ║
═════╗  ╔═══╗ ║ ║  ▄██████▄     ▄████████ ║  ║  ▄██████▄   ▄██████▄     ▄███████▄  ║    ╔════╝    ║
     ║        ║ ║ ███    ███   ███    ███ ║  ║ ███    ███ ███    ███   ███    ███  ║    ║      ║  ║
     ║    ║   ║ ╚═███    ███ ▀▀███▀▀▀     ║  ║ ███    ███ ███    ███ ▀█████████▀   ║    ║        
  ═══╝        ╚═══███    ███   ███        ║  ║ ███    ███ ███    ███   ███     ╔══ ║    ║  ╔═══════
                   ▀██████▀    ███        ║  ║   ▀██████▀   ▀██████▀   ████▀   ╚═══╝  ";
        public const string start = @"
                               ██  █ ▄▄▄ ▄▄   ▄▄  █▀▀  ▄▄▄▄ ▄▄▄▄▄ ▄▄▄
                               █ █ █ █▄▄  █ ▄ █   █ ▄▄ █▄▄█ █ █ █ █▄▄
                               █  ██ █▄▄  █▄█▄█   █▄▄█ █  █ █ █ █ █▄▄";
        public const string instructions = @"

                               ▄ ▄▄  ▄ ▄▄▄ ▄▄▄ ▄▄▄ ▄ ▄ ▄▄▄ ▄▄▄ ▄ ▄▄▄ ▄▄  ▄ ▄▄▄   
                               █ █ █ █ █▄▄  █  █▄█ █ █ █    █  █ █ █ █ █ █ █▄▄
                               █ █  ██ ▄▄█  █  █▀▄ █▄█ █▄▄  █  █ █▄█ █  ██ ▄▄█       ";

        public const string highScores = @"
                               ▄  ▄ ▄ ▄▄▄  ▄  ▄ ▄▄▄ ▄▄▄ ▄▄▄ ▄▄▄ ▄▄▄ ▄▄▄
                               █▄▄█ █ █ ▄▄ █▄▄█ █▄▄ █   █ █ █▄█ █▄▄ █▄▄
                               █  █ █ █▄▄█ █  █ ▄▄█ █▄▄ █▄█ █▀▄ █▄▄ ▄▄█      ";
        public const string exit = @"

                               ▄▄▄         ▄▄▄
                               █▄▄  ▀▄▀  █  █
                               █▄▄  ▄▀▄  █  █
                                 

                            ";


        public static string[] ReadComponents()
        {

            string readText = default(string);
            try
            {
                using (StreamReader read = new StreamReader(menuPath))
                {
                    readText = read.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file {0} can not be found!", menuPath);
            }

            string[] components = readText.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
            return components;
        }

        public static void DrawComponent(string obj, int left, int top, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(left, top);
            Console.WriteLine(obj);

        }
        public static void DrawMenu()
        {
            var cursor = new Cursor();
            cursor.Top = initialCursorTop;
            cursor.Left = initialCursorLeft;

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
                    else if (pressedKey.Key == ConsoleKey.Enter)
                    {

                        if (cursor.Top == initialCursorTop) // Start new game 
                        {
                            Console.Clear();
                           // Engine.Run();
                            var chooseHero = new ArcherMenu();
                            chooseHero.PrintHeroMenu();
                        }
                        else if (cursor.Top == cursorTopHighScores) // Run highScores
                        {

                        }
                        else if (cursor.Top == cursorTopInstructions) // Run Instructions 
                        {

                        }
                        else if (cursor.Top == maxCursorTop) // exit
                        {
                            Console.SetCursorPosition(0, 35);
                            Environment.Exit(1);
                        }
                    }
                }
                StartMenu.DrawComponent(StartMenu.gameName, 15, 0, ConsoleColor.DarkGreen);
                StartMenu.DrawComponent(StartMenu.start, 18, 18, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(StartMenu.highScores, 18, 21, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(StartMenu.instructions, 18, 23, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(StartMenu.exit, 18, 26, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(Cursor.body, cursor.Left, cursor.Top, ConsoleColor.DarkYellow);
                System.Threading.Thread.Sleep(200);

            }
        }
    }
}
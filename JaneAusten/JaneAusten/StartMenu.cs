using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public static class StartMenu
    {
        private const int INITIAL_CURSOR_TOP = 20;
        private const int INITIAL_CURSOR_LEFT = 24;
        private const int MAX_CURSOR_TOP = 29;
        private const int CURSOR_MOVEMENT = 3;
        private const int CURSOR_TOP_INSTRUCTIONS = 22;
        private const int CURSOR_TOP_HIGH_SCORES = 20;
        private const string MENU_PATH = @"..\..\Content\StartMenu.txt";
        public const string GAME_NAME = @"
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
        public const string START = @"
                               ██  █ ▄▄▄ ▄▄   ▄▄  █▀▀  ▄▄▄▄ ▄▄▄▄▄ ▄▄▄
                               █ █ █ █▄▄  █ ▄ █   █ ▄▄ █▄▄█ █ █ █ █▄▄
                               █  ██ █▄▄  █▄█▄█   █▄▄█ █  █ █ █ █ █▄▄";
        public const string INSTRUCTIONS = @"

                               ▄ ▄▄  ▄ ▄▄▄ ▄▄▄ ▄▄▄ ▄ ▄ ▄▄▄ ▄▄▄ ▄ ▄▄▄ ▄▄  ▄ ▄▄▄   
                               █ █ █ █ █▄▄  █  █▄█ █ █ █    █  █ █ █ █ █ █ █▄▄
                               █ █  ██ ▄▄█  █  █▀▄ █▄█ █▄▄  █  █ █▄█ █  ██ ▄▄█       ";

        public const string HIGH_SCORE = @"
                               ▄  ▄ ▄ ▄▄▄  ▄  ▄ ▄▄▄ ▄▄▄ ▄▄▄ ▄▄▄ ▄▄▄ ▄▄▄
                               █▄▄█ █ █ ▄▄ █▄▄█ █▄▄ █   █ █ █▄█ █▄▄ █▄▄
                               █  █ █ █▄▄█ █  █ ▄▄█ █▄▄ █▄█ █▀▄ █▄▄ ▄▄█      ";
        public const string EXIT = @"

                               ▄▄▄         ▄▄▄
                               █▄▄  ▀▄▀  █  █
                               █▄▄  ▄▀▄  █  █
                                 

                            ";


        public static string[] ReadComponents()
        {

            string readText = default(string);
            try
            {
                using (StreamReader read = new StreamReader(MENU_PATH))
                {
                    readText = read.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file {0} can not be found!", MENU_PATH);
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
            cursor.Top = INITIAL_CURSOR_TOP;
            cursor.Left = INITIAL_CURSOR_LEFT;

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
                        if (cursor.Top > INITIAL_CURSOR_TOP)
                        {
                            cursor.Top -= CURSOR_MOVEMENT;

                        }
                    }
                    else if (pressedKey.Key == ConsoleKey.DownArrow)
                    {
                        if (cursor.Top < MAX_CURSOR_TOP)
                        {
                            cursor.Top += CURSOR_MOVEMENT;

                        }
                    }
                    else if (pressedKey.Key == ConsoleKey.Enter)
                    {

                        if (cursor.Top == INITIAL_CURSOR_TOP) // Start new game 
                        {
                            Console.Clear();
                           // Engine.Run();
                            var chooseHero = new ArcherMenu();
                            chooseHero.PrintHeroMenu();
                        }
                        else if (cursor.Top == CURSOR_TOP_HIGH_SCORES) // Run highScores
                        {

                        }
                        else if (cursor.Top == CURSOR_TOP_INSTRUCTIONS) // Run Instructions 
                        {

                        }
                        else if (cursor.Top == MAX_CURSOR_TOP) // exit
                        {
                            Console.SetCursorPosition(0, 35);
                            Environment.Exit(1);
                        }
                    }
                }
                StartMenu.DrawComponent(StartMenu.GAME_NAME, 15, 0, ConsoleColor.DarkGreen);
                StartMenu.DrawComponent(StartMenu.START, 18, 18, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(StartMenu.HIGH_SCORE, 18, 21, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(StartMenu.INSTRUCTIONS, 18, 23, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(StartMenu.EXIT, 18, 26, ConsoleColor.DarkYellow);
                StartMenu.DrawComponent(Cursor.body, cursor.Left, cursor.Top, ConsoleColor.DarkYellow);
                System.Threading.Thread.Sleep(200);

            }
        }
    }
}
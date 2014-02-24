using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public  class EnterName
    {
        private static string Name { get; set; }
        private const string menuPath = @"..\..\Content\EnterNAme.txt";

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
        public static void DrawNameChoice(HeroMenu hero)
        {
            StartMenu.DrawComponent(EnterName.ReadComponents().ToString(), 0, 0, ConsoleColor.DarkGreen);
            var cursor = new Cursor();
            cursor.Left = 26;
            cursor.Top = 19;
            StartMenu.DrawComponent(Cursor.body, cursor.Left, cursor.Top, ConsoleColor.DarkGreen);
            EnterName.ReadName(hero);
            System.Threading.Thread.Sleep(200);

        }
        public static void ReadName(HeroMenu hero)
        {
            Console.SetCursorPosition(38, 19);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string name = Console.ReadLine();
            EnterName.Name = name;

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
                       // ArcherMenu archer = new ArcherMenu();
                        LevelDifficulty.DrawDifficulty(hero);
                    }
                    else if (pressedKey.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        var chooseHero = new ArcherMenu();
                        chooseHero.PrintHeroMenu();
                    }
                }
            }
        }
    }
}


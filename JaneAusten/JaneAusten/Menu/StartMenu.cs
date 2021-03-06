﻿using JaneAusten.Menu;
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
        private const int cursorTopInstructions = 26;
        private const int cursorTopHighScores = 20;
        private const string menuPath = @"..\..\Content\StartMenu.txt";
    
        public static StringBuilder ReadComponents(string path)
        {
            StringBuilder component = new StringBuilder();
            try
            {
                using (StreamReader sr = new StreamReader(path))
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
                            var chooseHero = new ArcherMenu();
                            chooseHero.PrintHeroMenu();
                            
                        }                        
                        else if (cursor.Top == cursorTopHighScores) // Run highScores
                        {
                            
                        }
                        else if (cursor.Top == cursorTopInstructions) // Run Instructions 
                        {
                            Console.Clear();
                            Instructions.DisplayInstructions();
                        }
                        else if (cursor.Top == maxCursorTop) // exit
                        {
                            Console.SetCursorPosition(0, 35);
                            Environment.Exit(1);
                        }
                    }
                }
                StartMenu.DrawComponent(StartMenu.ReadComponents(menuPath).ToString(), 0, 0, ConsoleColor.DarkGreen);
                StartMenu.DrawComponent(Cursor.body, cursor.Left, cursor.Top, ConsoleColor.DarkYellow);
                System.Threading.Thread.Sleep(200);

            }
        }
    }
}
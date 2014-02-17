namespace JaneAusten
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    public class Engine
    {
        public static void Run()
        {            
            string[,] labyrinth = GenerateLabyrinthLevel("1");

            PrintLabyrinth(labyrinth);

            // JustTest
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            while (true)
            {
                //Read pressed key
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                //Move hero (keypressed)
                //Move enemies
                //Check if some enemy is hitting us
                //Console clear
                Console.Clear();
                //Redraw playfield
                //Redraw hero
                //Redraw left enemies
            }
        }

        public static void PrintOnPosition(int x, int y, char chr, ConsoleColor color = ConsoleColor.Magenta)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(chr);
        }

        public static string[,] GenerateLabyrinthLevel(string level)
        {
            string filePath = @"..\..\Content\lab" + level + ".txt";
            StreamReader reader = new StreamReader(filePath);

            const int labRows = 13;
            const int labCols = 24;

            string[,] labyrinth = new string[labRows, labCols];

            using (reader)
            {
                for (int i = 0; i < labRows; i++)
                {
                    for (int ii = 0; ii < labCols; ii++)
                    {
                        labyrinth[i, ii] = ((char)reader.Read()).ToString();
                    }
                }
            }

            return labyrinth;
        }

        public static void PrintLabyrinth(string[,] labyrinth)
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int ii = 0; ii < labyrinth.GetLength(1); ii++)
                {
                    if (labyrinth[i, ii] == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(labyrinth[i, ii]);
                }
                Console.WriteLine();
            }
        }
    }
}

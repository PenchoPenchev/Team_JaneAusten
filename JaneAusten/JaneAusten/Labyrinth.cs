namespace JaneAusten
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    public class Labyrinth : IDrawable
    {
        private const int consoleWidth = 100;
        private const int consoleHeight = 36;

        private string mazeFile;

        public static int[,] maze = new int[consoleWidth, consoleHeight];


        public Labyrinth(string mazeFile = @"..\..\Content\MazeLevel2.txt")
        {
            this.MazeFile = mazeFile;
        }
        public string MazeFile
        {
            get
            {
                return this.mazeFile;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = @"..\..\Content\MazeLevel2.txt";
                }
                else
                {
                    this.mazeFile = value;
                }
            }
        }

        public void DrawObject()
        {
            try
            {
                using (StreamReader sr = new StreamReader(mazeFile))
                {
                    string line;
                    int row = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        for (int col = 0; col < line.Length; col++)
                        {
                            if (line[col] != ' ')
                            {
                                maze[col, row] = 1;
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.SetCursorPosition(col, row);
                                Console.Write(line[col]);
                            }
                        }
                        row++;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file {0} can not be found!", mazeFile);
            }
        }


        public void ClearObject()
        {
            throw new NotImplementedException();
        }
    }
}

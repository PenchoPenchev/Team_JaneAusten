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
        private const int consoleHeight = 35;

        public static int[,] maze = new int[consoleWidth, consoleHeight];

        public void DrawObject(int x, int y)
        {
            using (StreamReader sr = new StreamReader(@"..\..\Content\MazeLevel1.txt"))
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
                            Console.SetCursorPosition(col, row);
                            Console.Write(line[col]);
                        }
                    }
                    row++;
                }
            }
        }
    }
}

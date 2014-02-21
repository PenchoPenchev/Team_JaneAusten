namespace JaneAusten
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    public abstract class Enemy : Creature, IDrawable
    {
        public static readonly char[,] enemyFigure = new char[3, 3];

        private Levels level;

        public Levels Level
        {
            get { return level; }
            private set { level = value; }
        }

        public Enemy()
            : base()
        {

        }

        public Enemy(int x, int y, int health, int speed, ConsoleColor color, Levels level)
            : base(x, y, health, speed, color)
        {
            this.Level = level;
        }

        public void LoadEnemy()
        {
            using (StreamReader sr = new StreamReader(@"..\..\Content\monster.txt"))
            {
                string line;
                int row = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    for (int col = 0; col < line.Length; col++)
                    {
                        enemyFigure[row, col] = line[col];
                    }
                    row++;
                }
            }
        }

        public void DrawObject()
        {   
            Console.ForegroundColor = this.Color;

            for (int i = 0; i < enemyFigure.GetLength(0); i++)
            {
                for (int j = 0; j < enemyFigure.GetLength(1); j++)
                {
                    Console.SetCursorPosition(this.PosX + i, this.PosY + j);
                    Console.Write(enemyFigure[j, i]);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ClearObject()
        {
            for (int i = 0; i < enemyFigure.GetLength(0); i++)
            {
                for (int j = 0; j < enemyFigure.GetLength(1); j++)
                {
                    Console.SetCursorPosition(this.PosX + i, this.PosY + j);
                    Console.Write(' ');
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public abstract class Enemy : Creature, IDrawable
    {
        public char[,] enemyFigure = new char[3, 3];

        private int level;

        public int Level
        {
            get { return level; }
            private set { level = value; }
        }

        public Enemy(int x, int y, bool isDead, int health, int lives, int speed, ConsoleColor color, int level = 1)
            : base(x, y, health, lives, speed, color, isDead)
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

        public void ClearObject(int row, int col)
        {
            for (int i = 0; i < enemyFigure.GetLength(0); i++)
            {
                for (int j = 0; j < enemyFigure.GetLength(1); j++)
                {
                    Console.SetCursorPosition(row + i, col + j);
                    Console.Write(' ');
                }
            }
        }
    }
}

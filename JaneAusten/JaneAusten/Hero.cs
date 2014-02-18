using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public abstract class Hero : Creature, IDrawable
    {
        public char[,] heroFigure = new char[3, 3];

        private double damage;

        public double Damage
        {
            get { return this.damage; }
            private set { this.damage = value; }
        }

        public Hero(int x, int y, bool isDead, int speed, ConsoleColor color,
            int health = 100, int lives = 3, double damage = 10)
            : base(x, y, health, lives, speed, color, isDead)
        {
            this.Health = health;
            this.Lives = lives;
            this.Damage = damage;
        }

        public void LoadHero()
        {
            using (StreamReader sr = new StreamReader(@"..\..\Content\hero.txt"))
            {
                string line;
                int row = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    for (int col = 0; col < line.Length; col++)
                    {
                        heroFigure[row, col] = line[col];
                    }
                    row++;
                }
            }
        }

        protected bool CheckHeroHitWall(int heroXPosition, int heroYPosition)
        {
            for (int col = 0; col < heroFigure.GetLength(0); col++)
            {
                for (int row = 0; row < heroFigure.GetLength(1); row++)
                {
                    if (Labyrinth.maze[heroXPosition + col, heroYPosition + row] == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void DrawObject(int row, int col)
        {
            Console.ForegroundColor = this.Color;

            for (int i = 0; i < heroFigure.GetLength(0); i++)
            {
                for (int j = 0; j < heroFigure.GetLength(1); j++)
                {
                    Console.SetCursorPosition(row + i, col + j);
                    Console.Write(heroFigure[j, i]);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ClearObject(int row, int col)
        {
            for (int i = 0; i < heroFigure.GetLength(0); i++)
            {
                for (int j = 0; j < heroFigure.GetLength(1); j++)
                {
                    Console.SetCursorPosition(row + i, col + j);
                    Console.Write(' ');
                }
            }
        }
    }
}

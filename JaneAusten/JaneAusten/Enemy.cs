namespace JaneAusten
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    public abstract class Enemy : Creature, IDrawable
    {
        public static readonly char[,] enemyFigure = new char[movingFigure.GetLength(0), movingFigure.GetLength(1)];

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
        public void TakeDamage(double damage)
            {
            this.Health -= (int)damage;
            }

        public void ChangeEnemyColor()
        {
            if (this.Health >= 70)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            else if (this.Health >= 50)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else if (this.Health >= 30 && this.Health < 50)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                if (this.Health < 30)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }

            for (int col = 0; col < enemyFigure.GetLength(1); col++)
            {
                for (int row = 0; row < enemyFigure.GetLength(0); row++)
                {
                    Console.SetCursorPosition(this.PosX + col, this.PosY + row);
                    Console.Write(enemyFigure[row, col]);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public abstract void Move();
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
                        //creatureFigure[row, col] = line[col];
                    }
                    row++;
                }
            }
        }

        public override void DrawObject()
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
    }
}

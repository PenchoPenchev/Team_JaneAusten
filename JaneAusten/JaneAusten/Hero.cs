using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public abstract class Hero : Creature, IDrawable
    {
        public readonly char[,] heroFigure = new char[3, 3];
        public readonly char[,] heroCollision = new char[3, 3];

        private string heroFile = @"..\..\Content\hero.txt";
        private string heroAndEnemyCollideFile = @"..\..\Content\Collision.txt";
        
        private double damage;

        public double Damage
        {
            get { return this.damage; }
            private set { this.damage = value; }
        }

        public Hero()
            : base()
        {

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
            try
            {
                using (StreamReader sr = new StreamReader(heroFile))
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
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file {0} can not be found!", heroFile);
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

        public void DrawObject()
        {
            Console.ForegroundColor = this.Color;

            for (int i = 0; i < heroFigure.GetLength(0); i++)
            {
                for (int j = 0; j < heroFigure.GetLength(1); j++)
                {
                    Console.SetCursorPosition(this.PosX + i, this.PosY + j);
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

        private bool CollideWithEnemy()
        {
            foreach (var enemy in FirstLevel.listOfFighterEnemies)
            {
                if ((this.PosX + Enemy.enemyFigure.GetLength(0) == enemy.PosX && this.PosY == enemy.PosY) || 
                    (this.PosX == enemy.PosX && this.PosY == enemy.PosY + Enemy.enemyFigure.GetLength(1)))
                {
                    this.IsDead = true;
                    return true;     
                }
            }
            return false;
        }

        public void CollisionWithEnemyCheck()
        {
            if (CollideWithEnemy() && this.Lives > 0 && this.IsDead)
            {
                this.ClearObject(this.PosX, this.PosY);
                
                PrintHeroCollision();
                System.Threading.Thread.Sleep(500);
                ClearObject(this.PosX, this.PosY);
                
                DecreaseHeroLives();

                this.PosX = 1;
                this.PosY = 1;
                
                this.DrawObject();
            }
        }

        private void DecreaseHeroLives()
        {
            if (CollideWithEnemy() && this.Lives > 0)
            {
                this.Lives--;
            }
            if (this.Lives == 0)
            {
                PrintOnPosition(30, 10, "GAME OVER");
                
            }
        }

        public void LoadHeroCollision()
        {
            try
            {
                using (StreamReader sr = new StreamReader(heroAndEnemyCollideFile))
                {
                    string line;
                    int row = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        for (int col = 0; col < line.Length; col++)
                        {
                            heroCollision[row, col] = line[col];
                        }
                        row++;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file {0} can not be found!", heroAndEnemyCollideFile);
            }
        }

        //public char[,] LoadFile(string imageWithPath)
        //{
        //    char[,] charArray = new char[3, 3];
        //    try
        //    {
        //        using (StreamReader sr = new StreamReader(imageWithPath))
        //        {
        //            string line;
        //            int row = 0;
        //            while ((line = sr.ReadLine()) != null)
        //            {
        //                for (int col = 0; col < line.Length; col++)
        //                {
        //                    charArray[row, col] = line[col];
        //                }
        //                row++;
        //            }
        //        }
        //    }
        //    catch (FileNotFoundException)
        //    {
        //        Console.WriteLine("The file {0} can not be found!");
        //    }

        //    return charArray;
        //}

        private void PrintHeroCollision()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            for (int i = 0; i < heroCollision.GetLength(0); i++)
            {
                for (int j = 0; j < heroCollision.GetLength(1); j++)
                {
                    Console.SetCursorPosition(this.PosX + i, this.PosY + j);
                    Console.Write(heroCollision[j, i]);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintOnPosition(int x, int y, string message)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(message);
        }
    }
}

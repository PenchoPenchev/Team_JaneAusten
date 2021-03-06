﻿namespace JaneAusten
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    public abstract class Hero : Creature, IMovable
    {
        public readonly char[,] heroFigure = new char[3, 3];
        public readonly char[,] heroCollision = new char[3, 3];

        private string heroAndEnemyCollideFile = @"..\..\Content\Collision.txt";

        private int range;

        public int Range
        {
            get { return range; }
            set { range = value; }
        }

        private double damage;

        public double Damage
        {
            get { return this.damage; }
            private set { this.damage = value; }
        }

        private int score;

        public int Score
        {
            get { return this.score; }
            set { this.score = value; }
        }

        public Hero()
            : base()
        {

        }

        public Hero(int x, int y, int speed, ConsoleColor color,
            int health, int lifes, double damage, int range, int score)
            : base(x, y, health, lifes, speed, color)
        {
            this.Health = health;
            this.Lifes = lifes;
            this.Damage = damage;
            this.Range = range;
            this.Score = score;
        }

        public abstract void Move();
        
        public void LoadHero(string heroName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"..\..\Content\" + heroName + ".txt"))
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
                Console.WriteLine("The file {0} can not be found!");
            }
        }
        
        public override void DrawObject()
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

        protected override bool CheckCreatureHitWall(int heroXPosition, int heroYPosition)
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

        public virtual void CollisionWithEnemyCheck(Level level)
        {
            if (CollideWithMovingObject(level) && this.Lifes > 0)
            {
                this.ClearObject();

                PrintHeroCollision();
                System.Threading.Thread.Sleep(500);
                ClearObject();

                DecreaseHeroLifes(level);

                this.PosX = 1;
                this.PosY = 1;

                this.DrawObject();
            }
        }

        protected void DecreaseHeroLifes(Level level)
        {
            if (CollideWithMovingObject(level) && this.Lifes > 0)
            {
                this.Lifes--;
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

        protected void PrintHeroCollision()
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

        public void PotentialCollideWithBonus(Level level)
        {
            List<Bonus> levelBonuses = level.BonusesList;
            foreach (var bonus in levelBonuses)
            {

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if ((this.PosX + i == bonus.PosX && this.PosY + j == bonus.PosY) && !bonus.IsCollected)
                        {
                            if (bonus is HidingBonus)
                            {
                                if (((HidingBonus)bonus).IsHidden)
                                {
                                    continue;
                                }
                            }
                        
                            switch (bonus.Type)
                            {
                                case BonusType.gold: this.Score += 50; break;
                                case BonusType.diamond: this.Score += 100; break;
                                case BonusType.lifePotion: this.Lifes++; break;
                                case BonusType.extraDamage: this.Damage += 10; break;
                                case BonusType.longerRange: this.Range++; break;
                            }
                           bonus.Collect();
                        }                 
                    }
                }
            }
        }

        public void PrintOnPosition(int x, int y, string message)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(message);
        }
    }
}

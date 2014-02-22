namespace JaneAusten
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

        public Hero(int x, int y, int speed, ConsoleColor color,
            int health, int lives, double damage)
            : base(x, y, health, lives, speed, color)
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
                            //creatureFigure[row, col] = line[col];
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
        public abstract void Move();
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

        //protected virtual bool CollideWithEnemy()
        //{
        //    foreach (var enemy in FirstLevel.listOfFighterEnemies)
        //    {
        //        if ((this.PosX + Enemy.enemyFigure.GetLength(0) == enemy.PosX && this.PosY == enemy.PosY) ||
        //            (this.PosX == enemy.PosX && this.PosY == enemy.PosY + Enemy.enemyFigure.GetLength(1)))
        //        {
        //            return true;
        //        }
        //        else if ((this.PosX - Enemy.enemyFigure.GetLength(0) == enemy.PosX && this.PosY == enemy.PosY) ||
        //            (this.PosX == enemy.PosX && this.PosY == enemy.PosY - Enemy.enemyFigure.GetLength(1)))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        public void CollisionWithEnemyCheck()
        {
            if (CollideWithMovingObject(this.PosX, this.PosY) && this.Lives > 0)
            {
                this.ClearObject();

                PrintHeroCollision();
                System.Threading.Thread.Sleep(500);
                ClearObject();

                DecreaseHeroLives();

                this.PosX = 1;
                this.PosY = 1;

                this.DrawObject();
            }
        }

        private void DecreaseHeroLives()
        {
            if (CollideWithMovingObject(this.PosX, this.PosY) && this.Lives > 0)
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

        public void PotentialCollideWithBonus()
        {
            foreach (var bonus in FirstLevel.listOfBonuses)
            {

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if ((this.PosX + i == bonus.PosX && this.PosY + j == bonus.PosY) && !bonus.IsCollected)
                        {
                            if (bonus is HidingBonus)
                            {
                                if (((HidingBonus)bonus).IsHided)
                                {
                                    continue;
                                }
                            }
                        
                            switch (bonus.Type)
                            {
                                case BonusType.gold: Engine.score += 50; break;
                                case BonusType.diamond: Engine.score += 100; break;
                                case BonusType.lifePotion: this.Lives++; break;
                                case BonusType.extraDamage: this.Damage += 10; break;
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

namespace JaneAusten
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    public class Archer : Hero, IMovable, IDrawable, IShootable
    {
        private char shotDirection = 'R';
        private char shotSybmol = '→';

        public char ShotSymbol
        {
            get { return this.shotSybmol; }
            private set { this.shotSybmol = value; }
        }

        public Archer()
            : base()
        {

        }

        public Archer(int x, int y, int speed, ConsoleColor color,
            int health = 100, int Lifes = 3, int damage = 10, int range = 5)
            : base(x, y, speed, color, health, Lifes, damage, range)
        {
        }

        public override void Move()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    if (!CheckCreatureHitWall(this.PosX + 1, this.PosY))
                    {
                        ClearObject();
                        this.PosX++;
                        DrawObject();
                        shotDirection = 'R';
                    }
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (!CheckCreatureHitWall(this.PosX - 1, this.PosY))
                    {
                        ClearObject();
                        this.PosX--;
                        DrawObject();
                        shotDirection = 'L';
                    }
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (!CheckCreatureHitWall(this.PosX, this.PosY - 1))
                    {
                        ClearObject();
                        this.PosY--;
                        DrawObject();
                        shotDirection = 'U';
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (!CheckCreatureHitWall(this.PosX, this.PosY + 1))
                    {
                        ClearObject();
                        this.PosY++;
                        DrawObject();
                        shotDirection = 'D';
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    Shoot();
                }
            }
        }

        public void Shoot()
        {
            int bulletPosX = 0;
            int bulletPosY = 0;

            Bullet.shotSound.Play();

            switch (shotDirection)
            {
                case 'L':
                    shotSybmol = '←';
                    bulletPosX = this.PosX - 1;
                    bulletPosY = this.PosY + heroFigure.GetLength(1) / 2;
                    break;
                case 'R':
                    shotSybmol = '→';
                    bulletPosX = this.PosX + heroFigure.GetLength(0);
                    bulletPosY = this.PosY + heroFigure.GetLength(1) / 2;
                    break;
                case 'U':
                    shotSybmol = '↑';
                    bulletPosX = this.PosX + heroFigure.GetLength(0) / 2;
                    bulletPosY = this.PosY - 1;
                    break;
                case 'D':
                    shotSybmol = '↓';
                    bulletPosX = this.PosX + heroFigure.GetLength(0) / 2;
                    bulletPosY = this.PosY + heroFigure.GetLength(1);
                    break;
            }

            // Add bullet to bullet list
            Engine.listOfBullets.Add(
                new Bullet(bulletPosX, bulletPosY, ShotSymbol, this.Range, this.Damage));
        }

        public override void CollisionWithEnemyCheck(Level level)
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
    }
}

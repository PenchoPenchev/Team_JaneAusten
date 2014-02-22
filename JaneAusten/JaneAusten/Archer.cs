using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public class Archer : Hero, IMovable
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
            int health = 100, int lives = 3, int damage = 10)
            : base(x, y, speed, color, health, lives, damage)
        {
        }

        public void Move()
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
                    int bulletPosX = 0;
                    int bulletPosY = 0;

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
                        new Bullet(bulletPosX, bulletPosY, ShotSymbol, this.Damage));
                }
            }
        }

    }
}

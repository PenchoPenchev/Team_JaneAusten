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

        public List<Bullet> listOfBullets = new List<Bullet>();

        public char ShotSymbol
        {
            get { return this.shotSybmol; }
            private set { this.shotSybmol = value; }
        }

        public Archer(int x, int y, bool isDead, int speed, ConsoleColor color,
            int health = 100, int lives = 3, double damage = 10)
            : base(x, y, isDead, speed, color, health, lives, damage)
        {

        }

        public void MoveAllBulletsOneStepForward()
        {
            //Clear all current bullets
            foreach (var oldBullet in listOfBullets)
            {
                Console.SetCursorPosition(oldBullet.PosX, oldBullet.PosY);
                Console.Write(' ');
            }
            
            List<Bullet> listOfNewBulletPositions = new List<Bullet>();

            for (int i = 0; i < listOfBullets.Count; i++)
            {
                switch (listOfBullets[i].BulletSymbol)
                {
                    case '←':
                        listOfBullets[i].PosX--;
                        break;
                    case '→':
                        listOfBullets[i].PosX++;
                        break;
                    case '↑':
                        listOfBullets[i].PosY--;
                        break;
                    case '↓':
                        listOfBullets[i].PosY++;
                        break;
                }

                if (!CheckShotHitWall(listOfBullets[i].PosX, listOfBullets[i].PosY))
                {
                    listOfNewBulletPositions.Add(listOfBullets[i]);    
                }
            }

            listOfBullets.Clear();
            listOfBullets = listOfNewBulletPositions;
        }

        public void PrintAllBullets()
        {
            foreach (var bullet in listOfBullets)
            {
                Console.SetCursorPosition(bullet.PosX, bullet.PosY);
                Console.Write(bullet.BulletSymbol);
            }
        }

        private bool CheckShotHitWall(int heroXposition, int heroYposition)
        {
            if (Labyrinth.maze[heroXposition, heroYposition] == 1) return true;

            return false;
        }

        public void MoveAndShoot()
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
                    if (!CheckHeroHitWall(this.PosX + 1, this.PosY))
                    {
                        ClearObject(this.PosX, this.PosY);
                        this.PosX++;
                        DrawObject(this.PosX, this.PosY);
                        shotDirection = 'R';
                    }
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (!CheckHeroHitWall(this.PosX - 1, this.PosY))
                    {
                        ClearObject(this.PosX, this.PosY);
                        this.PosX--;
                        DrawObject(this.PosX, this.PosY);
                        shotDirection = 'L';
                    }
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (!CheckHeroHitWall(this.PosX, this.PosY - 1))
                    {
                        ClearObject(this.PosX, this.PosY);
                        this.PosY--;
                        DrawObject(this.PosX, this.PosY);
                        shotDirection = 'U';
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (!CheckHeroHitWall(this.PosX, this.PosY + 1))
                    {
                        ClearObject(this.PosX, this.PosY);
                        this.PosY++;
                        DrawObject(this.PosX, this.PosY);
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

                    Bullet bullet = new Bullet(bulletPosX, bulletPosY, ShotSymbol);
                    listOfBullets.Add(bullet);
                }
            }
        }

        //In use only because the interface IMovable
        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}

namespace JaneAusten
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bullet : MovingObject, IDrawable
    {
        public static List<Bullet> listOfBullets = new List<Bullet>();

        private char bulletSymbol;

        public char BulletSymbol
        {
            get { return this.bulletSymbol; }
            set { this.bulletSymbol = value; }
        }

        private int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        private int range;

        public int Range
        {
            get { return range; }
            set { range = value; }
        }

        private double damage;

        public double Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        

        public Bullet(int x, int y, char shotSymbol, int speed = 10, int range = 5)
            : base(x, y)
        {
            this.BulletSymbol = shotSymbol;
            this.Speed = speed;
            this.Range = range;
        }

        public Bullet(int x, int y, char shotSymbol, double damage, int speed = 10, int range = 5)
            : base(x, y)
        {
            this.BulletSymbol = shotSymbol;
            this.Damage = damage;
            this.Speed = speed;
            this.Range = range;
        }

        public void DrawObject()
        {
            Console.SetCursorPosition(this.PosX, this.PosY);
            Console.Write(bulletSymbol);
        }

        public static void ClearObject(int shotXPosition, int shotYPosition)
        {
            Console.SetCursorPosition(shotXPosition, shotYPosition);
            Console.Write(' ');
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public static void MoveAllBulletsOneStepForward()
        {
            //Clear all current bullets
            foreach (var oldBullet in Bullet.listOfBullets)
            {
                Console.SetCursorPosition(oldBullet.PosX, oldBullet.PosY);
                Console.Write(' ');
            }

            List<Bullet> listOfNewBulletPositions = new List<Bullet>();

            for (int i = 0; i < Bullet.listOfBullets.Count; i++)
            {
                switch (Bullet.listOfBullets[i].BulletSymbol)
                {
                    case '←':
                        Bullet.listOfBullets[i].PosX--;
                        break;
                    case '→':
                        Bullet.listOfBullets[i].PosX++;
                        break;
                    case '↑':
                        Bullet.listOfBullets[i].PosY--;
                        break;
                    case '↓':
                        Bullet.listOfBullets[i].PosY++;
                        break;
                }

                if (!CheckShotHitWall(Bullet.listOfBullets[i].PosX, Bullet.listOfBullets[i].PosY))
                {
                    if (CheckShotHitEnemy(Bullet.listOfBullets[i]))
                    {
                        ModifyEnemy(Bullet.listOfBullets[i]);
                    }
                    else
                    {
                        listOfNewBulletPositions.Add(Bullet.listOfBullets[i]);
                    }
                }
            }

            Bullet.listOfBullets.Clear();
            Bullet.listOfBullets = listOfNewBulletPositions;
        }

        public static void PrintAllBullets()
        {
            foreach (var bullet in Bullet.listOfBullets)
            {
                Console.SetCursorPosition(bullet.PosX, bullet.PosY);
                Console.Write(bullet.BulletSymbol);
            }
        }

        private static bool CheckShotHitWall(int heroXposition, int heroYposition)
        {
            if (Labyrinth.maze[heroXposition, heroYposition] == 1) return true;

            return false;
        }

        private static bool CheckShotHitEnemy(Bullet bullet)
        {
            for (int enemy = 0; enemy < FirstLevel.listOfFighterEnemies.Count; enemy++)
            {
                if (bullet.PosX == FirstLevel.listOfFighterEnemies[enemy].PosX &&
                    bullet.PosY / 2 == FirstLevel.listOfFighterEnemies[enemy].PosY)
                {
                    return true;
                }
            }

            return false;
        }

        private static void ModifyEnemy(Bullet bullet)
        {
            for (int enemy = 0; enemy < FirstLevel.listOfFighterEnemies.Count; enemy++)
            {
                if (bullet.PosX == FirstLevel.listOfFighterEnemies[enemy].PosX &&
                    bullet.PosY / 2 == FirstLevel.listOfFighterEnemies[enemy].PosY)
                {
                    FighterEnemy.DecreaseEnemyHealth(FirstLevel.listOfFighterEnemies[enemy], bullet);
                    FighterEnemy.ChangeEnemyColor(FirstLevel.listOfFighterEnemies[enemy]);
                    FirstLevel.RemoveAllDeadEnemies();
                }
            }
        }
    }
}

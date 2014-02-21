namespace JaneAusten
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bullet : MovingObject, IDrawable
    {
     
        private char bulletSymbol;
        public char BulletSymbol
        {
            get { return this.bulletSymbol; }
            set { this.bulletSymbol = value; }
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
        

        public Bullet(int x, int y, char shotSymbol, int range = 5)
            : base(x, y)
        {
            this.BulletSymbol = shotSymbol;
            this.Range = range;
        }

        public Bullet(int x, int y, char shotSymbol, double damage, int range = 5)
            : base(x, y)
        {
            this.BulletSymbol = shotSymbol;
            this.Damage = damage;
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
            // Clear bullet
            if (!CheckShotHitWall(this.PosX, this.PosY))
            {
                Console.SetCursorPosition(this.PosX, this.PosY);
                Console.Write(' ');

                switch (this.BulletSymbol)
                {
                    case '←':
                        this.PosX--;
                        break;
                    case '→':
                        this.PosX++;
                        break;
                    case '↑':
                        this.PosY--;
                        break;
                    case '↓':
                        this.PosY++;
                        break;
                }
            }

            // Collision check - second !CheckShotHitWall(this.PosX, this.PosY) is NOT redundant!
            if (!CheckShotHitWall(this.PosX, this.PosY))
            {
                if (CheckShotHitEnemy(this))
                {
                    ModifyEnemy(this);
                    Engine.listOfBullets.Remove(this);
                }
                else
                {
                    DrawObject();
                }
            }
            else
            {
                Engine.listOfBullets.Remove(this);
            }
        }

        public static bool CheckShotHitWall(int bulletXposition, int bulletYposition)
        {
            if (Labyrinth.maze[bulletXposition, bulletYposition] == 1)
            {
                return true;
            }
            return false;
        }

        private static bool CheckShotHitEnemy(Bullet bullet)
        {
            for (int enemy = 0; enemy < FirstLevel.listOfFighterEnemies.Count; enemy++)
            {
                //"bullet.PosY - 1" because bullet always hits targets in the middle 
                //Horizontal checks
                if (bullet.PosX == FirstLevel.listOfFighterEnemies[enemy].PosX &&
                    bullet.PosY - 1 == FirstLevel.listOfFighterEnemies[enemy].PosY)
                {
                    return true;
                }
                else if (bullet.PosX == FirstLevel.listOfFighterEnemies[enemy].PosX + Enemy.enemyFigure.GetLength(0) &&
                    bullet.PosY - 1 == FirstLevel.listOfFighterEnemies[enemy].PosY)
                {
                    return true;
                }
                //Vertical checks
                else if (bullet.PosX >= FirstLevel.listOfFighterEnemies[enemy].PosX &&
                        bullet.PosX <= FirstLevel.listOfFighterEnemies[enemy].PosX + Enemy.enemyFigure.GetLength(0) &&
                        bullet.PosY == FirstLevel.listOfFighterEnemies[enemy].PosY)
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
                    bullet.PosY - 1 == FirstLevel.listOfFighterEnemies[enemy].PosY)
                {
                    FighterEnemy.DecreaseEnemyHealth(FirstLevel.listOfFighterEnemies[enemy], bullet);
                    FighterEnemy.ChangeEnemyColor(FirstLevel.listOfFighterEnemies[enemy]);
                    FirstLevel.RemoveAllDeadEnemies();
                }
                else if (bullet.PosX == FirstLevel.listOfFighterEnemies[enemy].PosX + Enemy.enemyFigure.GetLength(0) &&
                    bullet.PosY - 1 == FirstLevel.listOfFighterEnemies[enemy].PosY)
                {
                    FighterEnemy.DecreaseEnemyHealth(FirstLevel.listOfFighterEnemies[enemy], bullet);
                    FighterEnemy.ChangeEnemyColor(FirstLevel.listOfFighterEnemies[enemy]);
                    FirstLevel.RemoveAllDeadEnemies();
                }
                else if (bullet.PosX >= FirstLevel.listOfFighterEnemies[enemy].PosX &&
                        bullet.PosX <= FirstLevel.listOfFighterEnemies[enemy].PosX + Enemy.enemyFigure.GetLength(0) &&
                        bullet.PosY == FirstLevel.listOfFighterEnemies[enemy].PosY)
                {
                    FighterEnemy.DecreaseEnemyHealth(FirstLevel.listOfFighterEnemies[enemy], bullet);
                    FighterEnemy.ChangeEnemyColor(FirstLevel.listOfFighterEnemies[enemy]);
                    FirstLevel.RemoveAllDeadEnemies();
                }
            }
        }
    }
}

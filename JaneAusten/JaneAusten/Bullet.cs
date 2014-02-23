namespace JaneAusten
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Media;

    public class Bullet : MovingObject, IDrawable
    {
        
     
        private char bulletSymbol;
        public char BulletSymbol
        {
            get { return this.bulletSymbol; }
            set { this.bulletSymbol = value; }
        }

        private double damage;

        public double Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        private int range;

        public int Range
        {
            get { return range; }
            set { range = value; }
        }
        
        public Bullet(int x, int y, char shotSymbol, int range, double damage)
            : base(x, y)
        {
            this.BulletSymbol = shotSymbol;
            this.Range = range;
            this.Damage = damage;
        }

        public void DrawObject()
        {
            Console.SetCursorPosition(this.PosX, this.PosY);
            Console.Write(bulletSymbol);
        }

        public void ClearObject()
        {
            Console.SetCursorPosition(this.PosX, this.PosY);
            Console.Write(' '); 
        }

        public static void DrawObject(int shotXPosition, int shotYPosition, char bulletSymbol)
        {
            Console.SetCursorPosition(shotXPosition, shotYPosition);
            Console.Write(bulletSymbol);
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
        }

        public static bool CheckShotHitWall(int bulletXposition, int bulletYposition)
        {
            if (Labyrinth.maze[bulletXposition, bulletYposition] == 1)
            {
                return true;
            }
            return false;
        }

        public static bool CheckShotHitBonus(int bulletXposition, int bulletYposition)
        {
            foreach (var bonus in FirstLevel.listOfBonuses)
            {
                if (bulletXposition == bonus.PosX && bulletYposition == bonus.PosY)
                {
                    Console.SetCursorPosition(bonus.PosX, bonus.PosY);
                    Console.Write(' ');
                    FirstLevel.listOfBonuses.Remove(bonus);

                    return true;
                }
            }

            return false;
        }

        public static bool CheckShotHitEnemy(Bullet bullet)
        {
            for (int enemy = 0; enemy < FirstLevel.listOfEnemies.Count; enemy++)
            {
                //"bullet.PosY - 1" because bullet always hits targets in the middle 
                //Horizontal checks
                if (bullet.PosX == FirstLevel.listOfEnemies[enemy].PosX &&
                    bullet.PosY - 1 == FirstLevel.listOfEnemies[enemy].PosY)
                {
                    return true;
                }
                else if (bullet.PosX == FirstLevel.listOfEnemies[enemy].PosX + Enemy.enemyFigure.GetLength(0) &&
                    bullet.PosY - 1 == FirstLevel.listOfEnemies[enemy].PosY)
                {
                    return true;
                }
                //Vertical checks
                else if (bullet.PosX >= FirstLevel.listOfEnemies[enemy].PosX &&
                        bullet.PosX <= FirstLevel.listOfEnemies[enemy].PosX + Enemy.enemyFigure.GetLength(0) &&
                        bullet.PosY == FirstLevel.listOfEnemies[enemy].PosY)
                {
                    return true;
                }
            }

            return false;
        }

        public static void ModifyEnemy(Bullet bullet, double damage)
        {
            for (int enemy = 0; enemy < FirstLevel.listOfEnemies.Count; enemy++)
            {
                if (bullet.PosX == FirstLevel.listOfEnemies[enemy].PosX &&
                    bullet.PosY - 1 == FirstLevel.listOfEnemies[enemy].PosY)
                {
                    Enemy.TakeDamage(FirstLevel.listOfEnemies[enemy], damage);
                    Enemy.ChangeEnemyColor(FirstLevel.listOfEnemies[enemy]);
                    FirstLevel.RemoveAllDeadEnemies();
                }
                else if (bullet.PosX == FirstLevel.listOfEnemies[enemy].PosX + Enemy.enemyFigure.GetLength(0) &&
                    bullet.PosY - 1 == FirstLevel.listOfEnemies[enemy].PosY)
                {
                    FighterEnemy.TakeDamage(FirstLevel.listOfEnemies[enemy], damage);
                    FighterEnemy.ChangeEnemyColor(FirstLevel.listOfEnemies[enemy]);
                    FirstLevel.RemoveAllDeadEnemies();
                }
                else if (bullet.PosX >= FirstLevel.listOfEnemies[enemy].PosX &&
                        bullet.PosX <= FirstLevel.listOfEnemies[enemy].PosX + Enemy.enemyFigure.GetLength(0) &&
                        bullet.PosY == FirstLevel.listOfEnemies[enemy].PosY)
                {
                    FighterEnemy.TakeDamage(FirstLevel.listOfEnemies[enemy], damage);
                    FighterEnemy.ChangeEnemyColor(FirstLevel.listOfEnemies[enemy]);
                    FirstLevel.RemoveAllDeadEnemies();
                }
            }
        }

    }
}

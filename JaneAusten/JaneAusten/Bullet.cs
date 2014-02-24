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

        public void ClearObject()
        {
            Console.SetCursorPosition(this.PosX, this.PosY);
            Console.Write(' '); 
        }

        public void DrawObject()
        {
            Console.SetCursorPosition(this.PosX, this.PosY);
            Console.Write(this.BulletSymbol);
        }

        public override void Move()
        {
            // Clear bullet
            if (!CheckShotHitWall())
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

        public bool CheckShotHitWall()
        {
            if (Labyrinth.maze[this.PosX, this.PosY] == 1)
            {
                return true;
            }
            return false;
        }

        public bool CheckShotHitBonus(Level level)
        {
            List<Bonus> levelBonuses = level.BonusesList;
            foreach (var bonus in levelBonuses)
            {
                if (this.PosX == bonus.PosX && this.PosY == bonus.PosY)
                {
                    Console.SetCursorPosition(bonus.PosX, bonus.PosY);
                    Console.Write(' ');
                    level.RemoveBonus(bonus);

                    return true;
                }
            }

            return false;
        }

        public bool CheckShotHitEnemy(Level level)
        {
            List<Enemy> levelEnemies = level.EnemiesList;
            for (int enemy = 0; enemy < levelEnemies.Count; enemy++)
            {
                //"bullet.PosY - 1" because bullet always hits targets in the middle 
                //Horizontal checks
                if (this.PosX == levelEnemies[enemy].PosX &&
                    this.PosY - 1 == levelEnemies[enemy].PosY)
                {
                    return true;
                }
                else if (this.PosX == levelEnemies[enemy].PosX + Enemy.enemyFigure.GetLength(0) &&
                    this.PosY - 1 == levelEnemies[enemy].PosY)
                {
                    return true;
                }
                //Vertical checks
                else if (this.PosX >= levelEnemies[enemy].PosX &&
                        this.PosX <= levelEnemies[enemy].PosX + Enemy.enemyFigure.GetLength(0) &&
                        this.PosY == levelEnemies[enemy].PosY)
                {
                    return true;
                }
            }

            return false;
        }

        public void ModifyEnemy(Level level, double damage)
        {
            List<Enemy> levelEnemies = level.EnemiesList;
            for (int enemy = 0; enemy < levelEnemies.Count; enemy++)
            {
                Enemy currentEnemy = levelEnemies[enemy];
                if (this.PosX == currentEnemy.PosX &&
                    this.PosY - 1 == currentEnemy.PosY)
                {
                    currentEnemy.TakeDamage(damage);
                    currentEnemy.ChangeEnemyColor();
                    level.RemoveAllDeadEnemies();
                }
                else if (this.PosX == currentEnemy.PosX + Enemy.enemyFigure.GetLength(0) &&
                    this.PosY - 1 == currentEnemy.PosY)
                {
                    currentEnemy.TakeDamage(damage);
                    currentEnemy.ChangeEnemyColor();
                    level.RemoveAllDeadEnemies();
                }
                else if (this.PosX >= currentEnemy.PosX &&
                        this.PosX <= currentEnemy.PosX + Enemy.enemyFigure.GetLength(0) &&
                        this.PosY == currentEnemy.PosY)
                {
                    currentEnemy.TakeDamage(damage);
                    currentEnemy.ChangeEnemyColor();
                    level.RemoveAllDeadEnemies();
                }
            }
        }

        public static void BulletsMovement(List<Bullet> listOfBullets, double damage, Level level)
        {
            for (int bullet = listOfBullets.Count() - 1; bullet >= 0; bullet--)
            {
                Bullet currentBullet = listOfBullets[bullet];
                currentBullet.Move();

                if (!currentBullet.CheckShotHitWall())
                {
                    if (currentBullet.CheckShotHitEnemy(level))
                    {
                        currentBullet.ModifyEnemy(level, damage);
                        listOfBullets.Remove(listOfBullets[bullet]);
                    }
                    else if (currentBullet.CheckShotHitBonus(level))
                    {
                        listOfBullets.Remove(listOfBullets[bullet]);
                    }
                    else if (listOfBullets[bullet].Range == 0)
                    {
                        listOfBullets.Remove(listOfBullets[bullet]);
                    }
                    else
                    {
                        if (listOfBullets[bullet].Range > 0)
                        {
                            listOfBullets[bullet].Range--;
                        }
                        currentBullet.DrawObject();
                    }
                }
                else
                {
                    listOfBullets.Remove(listOfBullets[bullet]);
                }
            }
        }

    }
}

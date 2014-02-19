namespace JaneAusten
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FighterEnemy : Enemy, IMovable
    {
        public FighterEnemy()
            : base()
        {

        }
        
        public FighterEnemy(int x, int y, bool isDead, int health, int lives, int speed, ConsoleColor color, int level = 1)
            : base(x, y, isDead, health, lives, speed, color)
        {
            this.Health = 50;
            this.Lives = 1;
            this.Speed = 5;
        }

        public void Move()
        {

        }

        public static void DecreaseEnemyHealth(FighterEnemy enemy, Bullet bullet)
        {
            enemy.Health -= (int)bullet.Damage;
        }

        //Change enemy color according hiw own health
        public static void ChangeEnemyColor(FighterEnemy fighter)
        {
            ConsoleColor newColor = ConsoleColor.DarkRed;

            if (fighter.Health >= 30 && fighter.Health < 50)
            {
                newColor = ConsoleColor.Red;
            }
            else
            {
                if (fighter.Health < 30)
                {
                    newColor = ConsoleColor.Green;
                }
            }

            Console.ForegroundColor = newColor;

            for (int col = 0; col < enemyFigure.GetLength(1); col++)
            {
                for (int row = 0; row < enemyFigure.GetLength(0); row++)
                {
                    Console.SetCursorPosition(fighter.PosX + col, fighter.PosY + row);
                    Console.Write(enemyFigure[row, col]);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

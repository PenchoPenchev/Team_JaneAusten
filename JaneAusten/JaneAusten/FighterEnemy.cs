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

        public FighterEnemy(int x, int y, int health, int speed, ConsoleColor color, Levels level)
            : base(x, y, health, speed, color, level)
        {
            this.Health = health;
            this.Speed = speed;
        }

        private char lastMoveDirection = 'R';

 
        public override void Move()
        {
            int currentX = this.PosX;
            int currentY = this.PosY;

            //Clear current position
            ClearObject();

            //Check right direction
            switch (lastMoveDirection)
            {
                case 'R':
                    currentX++;
                    break;
                case 'L':
                    currentX--;
                    break;
                default:
                    break;
            }

            if (lastMoveDirection == 'R')
            {
                if (!CheckCreatureHitWall(currentX, currentY))
                {
                    this.PosX++;
                }
                else
                {
                    lastMoveDirection = 'L';
                    currentX = this.PosX;
                }
            }

            if (lastMoveDirection == 'L')
            {
                //Move one step left
                if (currentX > 1)
                {
                    currentX--;
                }
                if (!CheckCreatureHitWall(currentX, currentY) && this.PosX > 1)
                {
                    this.PosX--;
                }
                else
                {
                    lastMoveDirection = 'R';
                    currentX = this.PosX;
                }
            }

            //Draw next position
            ChangeEnemyColor();
        }

       

        //Change enemy color according his own health
        //public static void ChangeEnemyColor(FighterEnemy fighter)
        //{
        //    if (fighter.Health == 70)
        //    {
        //        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        //    }
        //    else if (fighter.Health >= 50)
        //    {
        //        Console.ForegroundColor = ConsoleColor.DarkRed;
        //    }
        //    else if (fighter.Health >= 30 && fighter.Health < 50)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //    }
        //    else
        //    {
        //        if (fighter.Health < 30)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Green;
        //        }
        //    }

        //    for (int col = 0; col < enemyFigure.GetLength(1); col++)
        //    {
        //        for (int row = 0; row < enemyFigure.GetLength(0); row++)
        //        {
        //            Console.SetCursorPosition(fighter.PosX + col, fighter.PosY + row);
        //            Console.Write(enemyFigure[row, col]);
        //        }
        //    }

        //    Console.ForegroundColor = ConsoleColor.White;
        //}

        public void ChangeEnemyColor()
        {
            if (this.Health == 70)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            else if (this.Health >= 50)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else if (this.Health >= 30 && this.Health < 50)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                if (this.Health < 30)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }

            for (int col = 0; col < enemyFigure.GetLength(1); col++)
            {
                for (int row = 0; row < enemyFigure.GetLength(0); row++)
                {
                    Console.SetCursorPosition(this.PosX + col, this.PosY + row);
                    Console.Write(enemyFigure[row, col]);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

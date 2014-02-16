using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public abstract class Hero : Creature
    {   
        private double damage;

        public double Damage
        {
            get { return damage; }
            private set { damage = value; }
        }


        public Hero(int x, int y, bool isDead, int health, int lives, int speed, ConsoleColor color)
            : base(x, y, health, lives, speed, color, isDead)
        {
            this.Health = 100;
            this.Lives = 3;
        }
        
        public override void Move(string direction)
        {
            switch (direction)
            {
                case "up":
                    //x--;
                    break;
                case "down":
                    //x++;
                    break;
                case "left":
                    //y--;
                    break;
                case "right":
                    //y++;
                    break;
                default:
                    break;
            }
        }

        //static void DrawObject(int row, int col)
        //{
        //    for (int i = 0; i < hero.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < hero.GetLength(1); j++)
        //        {
        //            Console.SetCursorPosition(row + i, col + j);
        //            Console.Write(hero[j, i]);
        //        }
        //    }
        //}

    }
}

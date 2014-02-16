using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public class Archer : Hero
    {
        private char[,] archer;

        public Archer(int x, int y, bool isDead, int health, int lives, int speed, ConsoleColor color)
            : base(x, y, isDead, health, lives, speed, color)
        {

        }


    }
}

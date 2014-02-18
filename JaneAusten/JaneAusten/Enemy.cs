using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public abstract class Enemy : Creature
    {
        private int level;

        public int Level
        {
            get { return level; }
            private set { level = value; }
        }

        public Enemy(int x, int y, int health, int lives, int speed, ConsoleColor color, int level = 1)
            : base(x, y, health, lives, speed, color)
        {
            this.Level = level;
        }
    }
}

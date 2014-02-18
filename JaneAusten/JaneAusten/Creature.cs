using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public abstract class Creature : MovingObject
    {
        private ConsoleColor color;
        private int health;
        private int lives;
        private int speed;

        public bool IsDead
        {
            get { return this.Health == 0; }
        }

        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }

        public ConsoleColor Color 
        {
            get { return this.color; }
            set { this.color = value; } 
        }

        public int Health 
        { 
            get {return this.health; }
            set { this.health = value; } 
        }

        public int Speed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }

        public Creature(int x, int y, int health, int lives, int speed, ConsoleColor color)
            : base(x, y)
        {
            this.Health = health;
            this.Lives = lives;
            this.Speed = speed;
            this.Color = color;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public abstract class Creature : GameObject
    {
        private ConsoleColor color;
        private int health;
        private int lives;
        private int speed;

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

        public Creature() 
            : base()
        {

        }

        public Creature(int x, int y, int health, int speed, ConsoleColor color)
            : base(x, y)
        {
            this.Health = health;
            this.Speed = speed;
            this.Color = color;
        }

        public Creature(int x, int y, int health, int lives, int speed, ConsoleColor color)
            : base(x, y)
        {
            this.Health = health;
            this.Lives = lives;
            this.Speed = speed;
            this.Color = color;
        }

        public Creature(Point point, int health, int lives, int speed, ConsoleColor color)
            : base(point)
        {
            this.Health = health;
            this.Lives = lives;
            this.Speed = speed;
            this.Color = color;
        }

        protected bool CollideWithEnemy()
        {
            foreach (var enemy in FirstLevel.listOfFighterEnemies)
            {
                if ((this.PosX + Enemy.enemyFigure.GetLength(0) == enemy.PosX && this.PosY == enemy.PosY) ||
                    (this.PosX == enemy.PosX && this.PosY == enemy.PosY + Enemy.enemyFigure.GetLength(1)))
                {
                    return true;
                }
                else if ((this.PosX - Enemy.enemyFigure.GetLength(0) == enemy.PosX && this.PosY == enemy.PosY) ||
                    (this.PosX == enemy.PosX && this.PosY == enemy.PosY - Enemy.enemyFigure.GetLength(1)))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

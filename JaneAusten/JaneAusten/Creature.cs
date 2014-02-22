using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public abstract class Creature : GameObject
    {
        protected static char[,] movingFigure = new char[3, 3];
        
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

        public virtual bool CollideWithMovingObject(int x, int y)
        {
            foreach (var enemy in FirstLevel.listOfFighterEnemies)
            {
                if ((x <= enemy.PosX && x + movingFigure.GetLength(0) >= enemy.PosX &&
                    y <= enemy.PosY && y + movingFigure.GetLength(1) >= enemy.PosY))
                {
                    return true;
                }
                else if ((x >= enemy.PosX && x <= enemy.PosX + movingFigure.GetLength(0) &&
                        y <= enemy.PosY && y + movingFigure.GetLength(1) >= enemy.PosY))
                {
                    return true;
                }
            }
            return false;
        }

        public virtual void DrawObject()
        {
            Console.ForegroundColor = this.Color;

            for (int i = 0; i < movingFigure.GetLength(0); i++)
            {
                for (int j = 0; j < movingFigure.GetLength(1); j++)
                {
                    Console.SetCursorPosition(this.PosX + i, this.PosY + j);
                    Console.Write(movingFigure[j, i]);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ClearObject()
        {
            for (int i = 0; i < movingFigure.GetLength(0); i++)
            {
                for (int j = 0; j < movingFigure.GetLength(1); j++)
                {
                    Console.SetCursorPosition(this.PosX + i, this.PosY + j);
                    Console.Write(' ');
                }
            }
        }

        protected virtual bool CheckCreatureHitWall(int heroXPosition, int heroYPosition)
        {
            for (int col = 0; col < movingFigure.GetLength(0); col++)
            {
                for (int row = 0; row < movingFigure.GetLength(1); row++)
                {
                    if (Labyrinth.maze[heroXPosition + col, heroYPosition + row] == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

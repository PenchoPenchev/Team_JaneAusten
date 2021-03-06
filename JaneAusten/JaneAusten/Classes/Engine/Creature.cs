﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public abstract class Creature : GameObject, ICreature
    {
        protected static char[,] movingFigure = new char[3, 3];
        
        private ConsoleColor color;
        private int health;
        private int lifes;
        private int speed;

        public int Lifes
        {
            get { return lifes; }
            set { lifes = value; }
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

        public Creature(int x, int y, int health, int lifes, int speed, ConsoleColor color)
            : base(x, y)
        {
            this.Health = health;
            this.Lifes = lifes;
            this.Speed = speed;
            this.Color = color;
        }

        public Creature(Point point, int health, int lifes, int speed, ConsoleColor color)
            : base(point)
        {
            this.Health = health;
            this.Lifes = lifes;
            this.Speed = speed;
            this.Color = color;
        }

        public virtual bool CollideWithMovingObject(Level level)
        {
            foreach (var enemy in level.EnemiesList)
            {
                if ((this.PosX <= enemy.PosX && this.PosX + movingFigure.GetLength(0) >= enemy.PosX &&
                    this.PosY <= enemy.PosY && this.PosY + movingFigure.GetLength(1) >= enemy.PosY))
                {
                    return true;
                }
                else if ((this.PosX >= enemy.PosX && this.PosX <= enemy.PosX + movingFigure.GetLength(0) &&
                        this.PosY <= enemy.PosY && this.PosY + movingFigure.GetLength(1) >= enemy.PosY))
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

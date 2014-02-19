﻿namespace JaneAusten
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bullet : MovingObject, IDrawable
    {
        private char bulletSymbol;

        public char BulletSymbol
        {
            get { return this.bulletSymbol; }
            set { this.bulletSymbol = value; }
        }

        private int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        private int range;

        public int Range
        {
            get { return range; }
            set { range = value; }
        }

    //    public char ShotDirection { get; set; }

        public Bullet(int x, int y, char shotSymbol, int speed = 10, int range = 5)
            : base(x, y)
        {
            this.BulletSymbol = shotSymbol;
            this.Speed = speed;
            this.Range = range;
        }

        public void DrawObject()
        {
            Console.SetCursorPosition(this.PosX, this.PosY);
            Console.Write(bulletSymbol);
        }

        public static void ClearObject(int shotXPosition, int shotYPosition)
        {
            Console.SetCursorPosition(shotXPosition, shotYPosition);
            Console.Write(' ');
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    //София тест   
    public abstract class GameObject
    {
        private int posX;
        private int posY;
        public Point Point { get; set; }

        public int PosX
        {
            get { return posX; }
            protected set 
            {
                if (value >= 0)
                {
                    posX = value;     
                }
            }
        }

        public int PosY
        {
            get { return posY; }
            protected set 
            {
                if (PosY >= 0)
                {
                    posY = value;    
                }
            }
        }

        public GameObject()
        {
        }

        public GameObject(int x, int y)
        {
            this.PosX = x;
            this.PosY = y;
        }

        public GameObject(Point point)
        {
            this.Point = point; 
        }

    }
}

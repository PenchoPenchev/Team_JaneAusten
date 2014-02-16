using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public abstract class Object
    {
        private int posX;
        private int posY;

        public int PosX
        {
            get { return posX; }
            private set { posX = value; }
        }

        public int PosY
        {
            get { return posY; }
            private set { posY = value; }
        }

        public Object(int x, int y)
        {
            this.PosX = x;
            this.PosY = y;
        }

    }
}

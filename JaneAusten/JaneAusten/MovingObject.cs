namespace JaneAusten
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    public abstract class MovingObject : GameObject, IMovable
    {
        public MovingObject()
            : base()
        {

        }
        
        public MovingObject(int x, int y)
            : base(x, y)
        {

        }

        public MovingObject(Point point)
            : base(point)
        {

        }


        public abstract void Move();
    }
}

namespace JaneAusten
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    public abstract class MovingObject : Object, IMovable
    {
        public MovingObject()
            : base()
        {

        }
        
        public MovingObject(int x, int y)
            : base(x, y)
        {

        }

        public abstract void Move();
    }
}

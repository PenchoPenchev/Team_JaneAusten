namespace JaneAusten
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    public class Bullet : MovingObject
    {
        
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

        public Bullet(int x, int y, int speed, int range)
            : base(x, y)
        {
            this.Speed = speed;
            this.Range = range;
        }

        public override void Move(string direction)
        {
            switch (direction)
            {
                case "up":
                    
                    break;
                case "down":
                    
                    break;
                case "left":
                    
                    break;
                case "right":
                    
                    break;
                default:
                    break;
            }
        }
    }
}

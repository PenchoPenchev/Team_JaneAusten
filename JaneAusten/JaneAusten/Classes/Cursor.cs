using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public class Cursor
    { 
        public const string body = "══";
        private  int left;
        private  int top;
        public int Left
        {
            get{return this.left;}
            set
            {
                if (value > 0 && value < Console.WindowWidth)
                {
                    left = value;
                }
                else { throw new ArgumentException("Invalid coordinates!"); }
            }
        }
        public int Top
        {
            get { return this.top; }
            set
            {
                if (value > 0)
                {
                    top = value;
                }
                else { throw new ArgumentException("Invalid coordinates!"); }
            }
        }
        
    }
}

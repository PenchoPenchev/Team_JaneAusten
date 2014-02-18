using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public struct Point
    {
        public readonly int X { get; set; }

        public readonly int Y { get; set; }

        public Point(int x, int y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }
    }
}

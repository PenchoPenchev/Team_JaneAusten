using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public static class Cursor
    {
        private const int minCursorTop = 17;
        private const int maxCursorTop = 29;
        public const string body = "══";
        private static int left;
        public static int top;
        public static int Left
        {
            get { return left; }
            set
            {
                if (value > 0 && value < Console.WindowWidth)
                {
                    left = value;
                }
            }
        }
        public static int Top
        {
            get { return top; }
            set
            {
                if (value > 0 && value >= minCursorTop && value <= maxCursorTop)
                {
                    top = value;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    [Serializable]
    public class Point
    {
        public int x, y;
        public Point() {
            x = y = 0;
        }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }
        static public double getDist(Point a, Point b)
        {
            return  Math.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y));
        }
    }
}

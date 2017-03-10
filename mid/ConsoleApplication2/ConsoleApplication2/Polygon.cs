using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    [Serializable]
    public class Polygon
    {
        List<Point> a = new List<Point> ();
        public Polygon()
        {
        }
        public override string ToString()
        {
            string x = new string (' ', 0);
            for (int i = 0; i < a.Count; ++i)
            {
                x += a[i].ToString();
                x += ' ';
            }
            return x;
        }
        public void Add(Point x) 
        {
            a.Add(x);
        }
        public double getPerimeter() {
            double res = 0;
            for (int i = 1; i < a.Count; ++i)
            {
                res += Point.getDist(a[i], a[i - 1]);
            }
            if (a.Count > 2) {
                res += Point.getDist(a[a.Count - 1], a[0]);
            }
            return res;
        }
    }
}

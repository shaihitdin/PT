using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snuke
{
    class Food
    {
        public Point a;
        public ConsoleColor color = ConsoleColor.Green;
        public char sign = '@';
        public Food() {
            Random rnd = new Random();
            a = new Point(rnd.Next () % (Console.WindowWidth - 5), rnd.Next () % (Console.WindowHeight - 5));
        }
        public Food(Point b) {
            a = new Point(b.x, b.y);
        }
        public void Draw() {
            List<Point> c = new List<Point>();
            c.Add(a);
            new Drawing(c, color, sign).use_coloring();
        }
    }
}

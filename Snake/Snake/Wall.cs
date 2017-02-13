using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake
{
    class Wall
    {
        List<Point> body;
        public char sign = '0';
        public ConsoleColor color = ConsoleColor.Red;
        public Wall()
        {
            StreamReader sr = new StreamReader("wall.txt");
            int n = int.Parse(sr.ReadLine());
            body = new List<Point>();
            for (int i = 0; i < n; ++i)
            {
                String s = sr.ReadLine();
                for (int j = 0; j < s.Length; ++j)
                {
                    if (s[j] == '*')
                        body.Add(new Point(j, i));
                }
            }
        }
        public void Draw()
        {
            //Console.Clear();
            Console.ForegroundColor = this.color;
            foreach (Point p in this.body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace Snuke
{
    class Wall
    {
        public List<Point> body;
        public char sign = '#';
        public ConsoleColor color = ConsoleColor.DarkRed;
        public Wall() 
        {
            body = new List<Point>();
        }
        public Wall(List<Point> elements) 
        {
            body = elements;
        }
        public Wall(StreamReader f) 
        {
            body = new List<Point>();
            string[] s = f.ReadLine().Split();
            int n = int.Parse(s[0]), m = int.Parse(s[1]);
            for (int i = 0; i < n; ++i) {
                string x = f.ReadLine();
                for (int j = 0; j < m; ++j) {
                    if (x[j] == sign) {
                        body.Add(new Point(j, i));
                    }                                        
                }
            }
        }
        public void Draw() {
            new Drawing(body, color, sign).use_coloring();
        }
    }
}

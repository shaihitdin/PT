using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snuke
{
    class Drawing
    {
        public List<Point> to_draw;
        public ConsoleColor color;
        public char sign;
        public Drawing (List<Point> to_draw, ConsoleColor color, char sign) {
            this.to_draw = to_draw;
            this.color = color;
            this.sign = sign;
        }
        public void use_coloring() {
            for (int i = 0; i < to_draw.Count; ++i)
            {
                Console.SetCursorPosition(to_draw[i].x, to_draw[i].y);
                Console.ForegroundColor = color;
                Console.Write(sign);
            }
            Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
        }
    }
}

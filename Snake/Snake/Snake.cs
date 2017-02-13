using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Snake
{
    class Snake
    {
        public List<Point> body;
        public char sign = '*';
        public ConsoleColor color;
        public int cnt;
        public Snake()
        {
            body = new List<Point>();
            body.Add(new Point(10, 10));
            color = ConsoleColor.Yellow;
            cnt = 1;
        }
        public void Move(int dx, int dy)
        {
            Console.SetCursorPosition(body[body.Count - 1].x, body[body.Count - 1].y);
            Console.Write(" ");
            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i] = new Point(body[i - 1].x, body[i - 1].y);
            }
            body[0].x += dx;
            body[0].y += dy;
            if (body[0].x >= Console.WindowWidth - 3)
                body[0].x = 1;
            if (body[0].x < 1)
                body[0].x = Console.WindowWidth - 3;
            if (body[0].y >= Console.WindowHeight - 3)
                body[0].y = 1;
            if (body[0].y < 1)
                body[0].y = Console.WindowHeight - 3;
            if (++cnt % 10 == 0)
                body.Add(new Point(0, 0));
        }

        public void Draw()
        {
            //Console.Clear();
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }

    }
}

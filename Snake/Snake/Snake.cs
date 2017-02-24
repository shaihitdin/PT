using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snuke
{
    class Snake
    {
        public List<Point> body;
        public char sign = 'O';
        public ConsoleColor color = ConsoleColor.Cyan;
        public Snake() {
            body = new List<Point>();
            body.Add(new Point (20, 20));
        }
        public Snake(List<Point> body) {
            this.body = body;
        }
        public void Add() {
            body.Add(body.Last());
        }
        public void move_maker(Point d) {
            for (int i = 0; i < Console.WindowHeight; ++i) {
                Console.WriteLine(body.Count);
            }
            Console.ReadKey();
            new Drawing(body, ConsoleColor.Black, ' ').use_coloring();
            for (int i = 1; i < body.Count; ++i)
                body[i] = body[i - 1];
            body[0].x += d.x;
            body[0].y += d.y;
            if (body[0].x >= Console.WindowWidth - 3)
                body[0].x = 1;
            if (body[0].x < 1)
                body[0].x = Console.WindowWidth - 3;
            if (body[0].y >= Console.WindowHeight - 3)
                body[0].y = 1;
            if (body[0].y < 1)
                body[0].y = Console.WindowHeight - 3;
            new Drawing(body, color, sign).use_coloring();
        }
        public void Draw() {
            new Drawing(body, color, sign).use_coloring();
        }
    }
}

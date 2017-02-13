using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food
    {
        public Point a;
        public ConsoleColor color = ConsoleColor.Green;
        public char sign = 'F';
        public Food() 
        {
            Random rnd = new Random();
            a = new Point(Convert.ToInt32(rnd.Next()) % (Console.WindowWidth), Convert.ToInt32(rnd.Next()) % (Console.WindowHeight));
        }
        public void Draw() 
        {
            Console.ForegroundColor = this.color;
            Console.SetCursorPosition (a.x, a.y);
            Console.Write(sign);

        }
    }
}

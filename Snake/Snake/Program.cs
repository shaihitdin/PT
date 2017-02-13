using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Wall wall = new Wall();
            Snake snake = new Snake();
            Food food = new Food();
            String[] s = new String[50];
            
            for (int step = 1; true; ++step)
            {
                ConsoleKeyInfo pressed = Console.ReadKey();
                if (pressed.Key == ConsoleKey.UpArrow)
                {
                    snake.Move(0, -1);
                }
                if (pressed.Key == ConsoleKey.DownArrow)
                {
                    snake.Move(0, 1);
                }
                if (pressed.Key == ConsoleKey.LeftArrow)
                {
                    snake.Move(-1, 0);
                }
                if (pressed.Key == ConsoleKey.RightArrow)
                {
                    snake.Move(1, 0);
                }
                if (pressed.Key == ConsoleKey.Escape)
                {
                    break;
                }
                if (step % 10 == 0)
                    snake.body.Add(new Point (0, 0));
                snake.Draw();
                wall.Draw();
                food.Draw();
            }

        }
    }
}

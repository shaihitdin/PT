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
                foreach (Point a in wall.body)
                {
                    if (a.x == snake.body[0].x && a.y == snake.body[0].y)
                    {

                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Clear();
                        for (int i = 0; i < Console.WindowHeight - 1; ++i)
                        {
                            Console.WriteLine("Game over");
                        }
                            while (true)
                            {
                                Console.ReadKey();
                            }
                    }
                }
                if (food.a.x == snake.body[0].x && food.a.y == snake.body[0].y)
                {
                    snake.body.Add(new Point(0, 0));
                    food = new Food();
                }
                snake.Draw();
                wall.Draw();
                food.Draw();
            }

        }
    }
}

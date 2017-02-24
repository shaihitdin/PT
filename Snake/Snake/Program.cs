using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Threading;

namespace Snuke
{
    class Program
    {
        static int d = 0;
        static Point move = new Point (0, 0);
        static Snake snake = new Snake();
        static bool intersection_check(List <Point> body1, List <Point> body2) {
            for (int i = 0; i < body2.Count; ++i) {
                if (body2[i].x == body1[0].x && body2[i].y == body1[0].y)
                    return true;
            }
            return false;
        }
        static public void move_maker() {
            while (1 != 0)
            {
                if (d < 4)
                {
                    snake.move_maker(move);
                    Thread.Sleep(50 - snake.body.Count);
                }
                else
                {
                    while (1 != 0)
                    {
                        ConsoleKeyInfo s = Console.ReadKey();
                        if (s.Key == ConsoleKey.Escape)
                            break;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Wall wall = new Wall(new StreamReader("wall.txt"));
            Food food = new Food();
            Thread thread = new Thread(move_maker);
            thread.Start();
            while (1 != 0) {
                ConsoleKeyInfo pressed = Console.ReadKey();
                if (pressed.Key == ConsoleKey.UpArrow)
                {
                    move = new Point(0, -1);
                    d = 0;
                }
                if (pressed.Key == ConsoleKey.DownArrow)
                {
                    move = new Point(0, 1);
                    d = 1;
                }
                if (pressed.Key == ConsoleKey.LeftArrow)
                {
                    move = new Point(-1, 0);
                    d = 2;
                }
                if (pressed.Key == ConsoleKey.RightArrow)
                {
                    move = new Point(1, 0);
                    d = 3;
                }
                if (pressed.Key == ConsoleKey.Escape)
                {
                    d = 4;
                }
                if (intersection_check(snake.body, wall.body)) {
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
                List<Point> Foody = new List<Point>();
                Foody.Add(food.a);
                if (intersection_check (snake.body, Foody)) {
                    snake.Add();
                    food = new Food();
                }
                Console.Clear();
                snake.Draw();
                wall.Draw();
                food.Draw();
            }
        }
    }
}

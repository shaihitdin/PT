using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication3
{
    class Threading
    {
        static void Paint(int x, int y, ConsoleColor c) {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = c;
            for (int i = 0; i < 4; ++i) {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine("********");
            }
        }

        static void Red()
        {
            while (1 != 0) {
                Paint(2, 2, ConsoleColor.Red);
                Thread.Sleep(3000);
                Paint(2, 2, ConsoleColor.White);
                Thread.Sleep(6000);
            }
        }

        static void Yellow()
        {
            Thread.Sleep(3200);
            while (1 != 0)
            {
                Paint(2, 10, ConsoleColor.Yellow);
                Thread.Sleep(3000);
                Paint(2, 10, ConsoleColor.White);
                Thread.Sleep(6000);
            }
        }

        static void Green()
        {
            Thread.Sleep(6300);
            while (1 != 0)
            {
                Paint(2, 18, ConsoleColor.Green);
                Thread.Sleep(3000);
                Paint(2, 18, ConsoleColor.White);
                Thread.Sleep(6000);
            }
        }

        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 40);
            Thread[] thread = new Thread[3];
            Paint(2, 2, ConsoleColor.White);
            Paint(2, 10, ConsoleColor.White);
            Paint(2, 18, ConsoleColor.White);

            thread[0] = new Thread(Red);
            thread[1] = new Thread(Yellow);
            thread[2] = new Thread(Green);
            for (int i = 0; i < 3; ++i) {
                thread[i].Start();
            }
        }
    }
}

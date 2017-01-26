using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication3
{
    class Program
    {
        static bool isPrime(int x)
        {
            if (x < 2)
                return Convert.ToBoolean(0);
            for (int i = 2; i < x; ++i)
                if (x % i == 0)
                    return Convert.ToBoolean(1);
            return Convert.ToBoolean(0);
        }

        static void Main(string[] args)
        {
            StreamReader fin = new StreamReader(@"C:\work\chopchop.txt");
            string[] arr = fin.ReadLine().Split();
            int n = arr.Length;
            Console.WriteLine(n);
            int mn = int.MaxValue, mx = int.MinValue;
            for (int i = 0; i < n; ++i)
            {
                int x = int.Parse(arr[i]);
                if (isPrime(x))
                    mn = Math.Min(x, mn);
            }
            StreamWriter fout = new StreamWriter(@"C:\work\chopchopchop.txt");
            if (mn != int.MaxValue)
                fout.WriteLine(mn);
            else
                fout.WriteLine("An array is prime-free");
            fout.Flush();
        }
    }
}

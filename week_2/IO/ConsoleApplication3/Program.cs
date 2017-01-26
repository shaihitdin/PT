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
                mn = Math.Min(x, mn);
                mx = Math.Max(mx, x);
            }
            StreamWriter fout = new StreamWriter(@"C:\work\chopchopchop.txt");
            fout.WriteLine(mn + " " + mx);
            fout.Flush();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Sum
    {
        static void Main(string[] args)
        {
            string x = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < x.Length; ++i)
            {
                sum += (x[i] - '0');
            }
            Console.WriteLine(sum);
        }
    }
}

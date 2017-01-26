using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static bool isPrime(int x)
        {
            if (x < 2)  //0, 1 are not primes
                return Convert.ToBoolean(0);
            for (int i = 2; i * i <= x; ++i) //if i * (x / i) = x, then i or (x/i) should be less than sqrt (x), so check until sqrt (x) is sufficient
                if (x % i == 0)
                    return Convert.ToBoolean(1);   //is divisible by i
            return Convert.ToBoolean(0);
        }

        static void Main(string[] args)
        {
            int n = args.Length; //how many numbers are there
            for (int i = 0; i < n; ++i)
            {
                int x = Convert.ToInt32(args[i]); //converting to int i-th number
                if (isPrime(x)) //if isPrime returns 1 number should be printed
                    Console.WriteLine(x);
            }
        }
    }
}

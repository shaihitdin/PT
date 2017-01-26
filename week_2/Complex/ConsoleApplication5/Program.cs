using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{

    class Complex
    {
        int a, b;
        public Complex (int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public override string ToString()
        {
            return this.a + "/" + this.b;
        }
        public static Complex operator + (Complex a, Complex b)
        {
            return new Complex(a.a * b.b + b.a * a.b, a.b * b.b);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Complex a = new Complex(5, 3);
            Complex b = new Complex(2, 2);
            Console.WriteLine(a + b);
            Console.ReadKey();
        }
    }
}

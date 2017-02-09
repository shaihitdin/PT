using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    class Complex
    {
        public int x, y;

        static public int gcd(int x, int y)
        {
            if (y == 0)
                return x;
            return gcd(y, x % y);
        }
        public Complex(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return this.x + "/" + this.y;
        }
        static public Complex Simplify(Complex a)
        {
            int g = gcd(a.x, a.y);
            return new Complex(a.x / g, a.y / g);
        }

        static public Complex operator +(Complex a, Complex b)
        {
            return Simplify(new Complex(a.x * b.y + b.x * a.y, a.y * b.y));
        }

    }
}

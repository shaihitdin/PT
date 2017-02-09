using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    
    class Program
    {
        static void Main(string[] args)
        {
            FileStream f = new FileStream(@"C:/work/hellou.privet", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter gut = new BinaryFormatter();
            Complex a = new Complex(5, 3), b = new Complex(2, 2);
            Complex c = new Complex(1, 1);
            gut.Serialize(f, c);
            c = a + b;
            Console.WriteLine(c);
            gut = new BinaryFormatter();
            f.Close();
            f = new FileStream(@"C:/work/hellou.privet", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            
            c = gut.Deserialize(f) as Complex;
            Console.WriteLine(c);
            Console.ReadKey();

        }
    }
}

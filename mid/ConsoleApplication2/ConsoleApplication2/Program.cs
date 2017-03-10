using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace ConsoleApplication2
{
    class Program
    {

        static void Main(string[] args)
        {
            Polygon a = new Polygon();
            a.Add(new Point(0, 0));
            a.Add(new Point(0, 3));
            a.Add(new Point(3, 0));
            Console.WriteLine(a.getPerimeter());
            Console.ReadKey();
            DirectoryInfo s = new DirectoryInfo ("/Polygon");
            for (int i = 0; i < s.GetFiles().Count(); ++i) {
                Console.WriteLine(s.GetFiles()[i]);
            }
            Console.WriteLine("Write format of serialization");
            string q = Console.ReadLine();
            Console.WriteLine("Write filename of serialization");
            string qs = Console.ReadLine();
            FileStream fs = new FileStream(qs, FileMode.Open, FileAccess.Read);
            if (q == "Binary") 
            {
                BinaryFormatter bf = new BinaryFormatter();
                a = (Polygon)bf.Deserialize(fs);
            }
            else if (q == "Xml")
            {
                XmlSerializer xs = new XmlSerializer(typeof(Polygon));
                a = (Polygon)xs.Deserialize(fs);
            }
            else 
            {
                Console.WriteLine("Type unknown");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class App
    {
        public class Student {
            double GPA;
            string name, surname;
            //int age;
            public Student(string firstname, string lastname, /*DateTime birthdate, */double gpa) {
                this.name = firstname;
                this.surname = lastname;
                this.GPA = gpa;
                /*
                DateTime today = DateTime.Today;
                this.age = today.Year - birthdate.Year - 1;
                if ((birthdate.Month < today.Month) || (birthdate.Month == today.Month && birthdate.Day <= today.Day))
                    ++this.age;
                */
            }
            public Student() {
                this.name = this.surname = "";
                this.GPA = 0;
                //this.age = 0;
            }
            public override string ToString()
            {
                return this.name + " " + this.surname + " " + this.GPA /*+ " age of " + age*/;
            }
        }

        static void Main(string[] args)
        {
            Student a0 = new Student("Amina", "Aman", /*new DateTime(),*/ 3.28);
            Student a1 = new Student("Symbat", "Bashkeeva", /*new DateTime(),*/ 3.28);
            Student a2 = new Student("Altynay", "Erkhasym", /*new DateTime(),*/ 3.45);
            Student a3 = new Student("Shaikhitdin", "Nezametdinov", /*new DateTime(1999, 3, 1),*/ 1.37);
            Student a4 = new Student("Elibay", "Nuptebek", /*new DateTime(),*/ 2.36);
            Student a5 = new Student("Nargiz", "Oglan", /*new DateTime(),*/ 3);
            Student a6 = new Student("Ayzhan", "Sapina", /*new DateTime(),*/ 2.78);
            Student a7 = new Student("Nurzhigit", "Smailov", /*new DateTime(), */ 2.22);
            Student a8 = new Student("Shynbolat", "Tuganbay", /*new DateTime(), */ 2.61);
            Student a9 = new Student("Dilbara", "Ustambekova", /*new DateTime(), */ 1.61);
            Student a10 = new Student("Alisher", "Halykbaev", /*new DateTime(), */ 2.39);
            Student a11 = new Student("Aleksandra", "Khan", /*new DateTime(), */ 2.22);

            Console.WriteLine(a0.ToString());
            Console.WriteLine(a9.ToString());
            Console.ReadKey();
        }
    }
}

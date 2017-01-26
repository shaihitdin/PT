using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {
        static void emptySpace(int level)
        {
            for (int i = 0; i < level; ++i)
                Console.Write("-");
            Console.Write("> ");
        }
        static void Rec(string path, int level)
        {
            if (level > 3)
                return;
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            DirectoryInfo[] directories = directory.GetDirectories();
            foreach (FileInfo file in files)
            {
                emptySpace(level);
                Console.WriteLine(file.Name);
            }
            foreach (DirectoryInfo dInfo in directories)
            {
                emptySpace(level);
                Console.WriteLine(dInfo.Name);
                Rec(dInfo.FullName, level + 1);
            }

        }
        static int N = 100000;
        static string[] directory_stack = new string[N];
        static int[] child_num = new int[N];
        static int[] rec_level = new int[N];
        static int sz;
        static void add (string path, int stopnum, int lvl)
        {
            directory_stack[sz] = path;
            child_num[sz] = stopnum;
            rec_level[sz] = lvl;
            sz++;
        }
        static void Main(string[] args)
        {
            //Rec(@"C:\Users\shaih_000\Documents\GitHub\CP\Olymp", 0);
            add(@"C:\Users\shaih_000\Documents\GitHub\CP\Olymp", 0, 0);
            while (sz > 0)
            {
                --sz;
                string path = directory_stack[sz];
                int child = child_num[sz];
                int level = rec_level[sz];
                DirectoryInfo directory = new DirectoryInfo(path);
                FileInfo[] files = directory.GetFiles();
                DirectoryInfo[] directories = directory.GetDirectories();
                if (level > 3)
                    continue;

                if (child == 0)
                {
                    foreach (FileInfo file in files)
                    {
                        emptySpace(level);
                        Console.WriteLine(file.Name);
                    }
                }
                if (child >= directories.Length)
                    continue;
                DirectoryInfo dInfo = directories[child];
                add(path, child + 1, level);
                add(dInfo.FullName, 0, level + 1);
                emptySpace(level);
                Console.WriteLine(dInfo.Name);
            }
            Console.ReadKey();
        }
    }
}

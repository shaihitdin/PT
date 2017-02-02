/**
 *  Copyright (c) 2017 Satisfactory Hierarched Automated Information Komponented Human
 *
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 *  The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SHAIKH_manager
{
    class Program
    {
        static void Print(DirectoryInfo parent, int ps, int it, int cursor, int state, int start, int[] selected)
        {
            String a;
            int t_pos = start + it;
            if (t_pos == -1)
                a = "..";
            else if (t_pos < parent.GetFileSystemInfos().Length)
                a = parent.GetFileSystemInfos()[start + it].Name;
            else
                a = " ";
            if (cursor == 1 && start + state == t_pos)
                Console.BackgroundColor = ConsoleColor.DarkGray;
            else
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            if (t_pos != -1 && selected[t_pos] == 1)
                Console.ForegroundColor = ConsoleColor.Magenta;
            else if (t_pos != -1 && t_pos < parent.GetFileSystemInfos().Length && parent.GetFileSystemInfos()[t_pos].GetType() == typeof(FileInfo))
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            else
                Console.ForegroundColor = ConsoleColor.White;
            while (a.Length > Console.WindowWidth / 2 - 3)
                a = a.Remove(a.Length - 1);
            while (a.Length < Console.WindowWidth / 2 - 3)
                a += " ";
            Console.Write(a);
        }
        static void Move(DirectoryInfo[] a, int[] ps, int[] start, int cursor, int delta)
        {
            int nw = ps[cursor] + delta;
            if (nw < 0)
            {
                if (start[cursor] + ps[cursor] != -1)
                    --start[cursor];
                start[cursor] = Math.Max(start[cursor], -1);
            }
            else if (nw > Console.WindowHeight - 3)
            {
                ++start[cursor];
                start[cursor] = Math.Min(start[cursor], a[cursor].GetFileSystemInfos().Length - 1);
            }
            else
            {
                ps[cursor] += delta;
                if (start[cursor] + ps[cursor] >= a[cursor].GetFileSystemInfos().Length)
                    --ps[cursor];

            }
        }
        static void Copy(DirectoryInfo from, DirectoryInfo to, int[] selected)
        {
            for (int i = 0; i < 1000 && i < from.GetFileSystemInfos().Length; ++i)
            {
                string sourceFile = from.GetFileSystemInfos()[i].FullName;
                string destFile = Path.Combine(to.FullName, from.GetFileSystemInfos()[i].Name);
                if (selected[i] == 0)
                    continue;
                if (from.GetFileSystemInfos()[i].GetType() == typeof (FileInfo))
                {
                    File.Copy(sourceFile, destFile, true);
                }
                else
                {
                    if (!Directory.Exists(destFile))
                        Directory.CreateDirectory(destFile);
                    int[] selected2 = new int[1000];
                    for (int j = 0; j < 1000; ++j)
                        selected2[j] = 1;
                    Copy(new DirectoryInfo (sourceFile), new DirectoryInfo (destFile), selected2);
                }
            }
        }
        static void Make_Move (DirectoryInfo[] dir, int[] ps , int[] start, int cursor, ConsoleKeyInfo a)
        {
            if (a.Key == ConsoleKey.UpArrow)
                Move(dir, ps, start, cursor, -1);
            if (a.Key == ConsoleKey.DownArrow)
                Move(dir, ps, start, cursor, +1);
            if (a.Key == ConsoleKey.PageUp)
                for (int i = 0; i < 52; ++i)
                    Move(dir, ps, start, cursor, -1);
            if (a.Key == ConsoleKey.PageDown)
                for (int i = 0; i < 52; ++i)
                    Move(dir, ps, start, cursor, +1);
        }

        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.Clear();
            DirectoryInfo[] dir = new DirectoryInfo[2]; //First and second windows directories
            dir[0] = new DirectoryInfo (@"C:\");
            dir[1] = new DirectoryInfo (@"C:\");
            string command = ""; /// Command that you have written
            const int N = 1000;
            int[] state = new int[2]; // Cursor position (counts from start pos)
            int[][] selected = new int[2][]; // Files that have been selected
            selected[0] = new int[N];
            selected[1] = new int[N];
            int[] start = new int[2];
            int cursor = 0; //On which side you are
            start[0] = start[1] = -1;
            while (true)
            {
                // Print directories
                Console.Clear();
                for (int i = 0; i + 2 < Console.WindowHeight; ++i)
                {
                    for (int j = 0; j < 2; ++j)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("|");
                        Print(dir[j], j, i, Convert.ToInt32(cursor == j), state[j], start[j], selected[j]);
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("|");
                    }
                    Console.Write("\n");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(dir[cursor].FullName + ">");
                Console.Write(command);
                ConsoleKeyInfo typed = Console.ReadKey();
                if (typed.Key == ConsoleKey.Enter && command.Length == 0) //Enter directory
                {
                        if (start[cursor] + state[cursor] == -1)
                        {
                            if (dir[cursor].Parent != null)
                                dir[cursor] = dir[cursor].Parent;
                        }
                        else
                        {
                            dir[cursor] = new DirectoryInfo (dir[cursor].GetFileSystemInfos()[state[cursor] + start[cursor]].FullName);
                        }
                    state[cursor] = 0;
                    start[cursor] = -1;
                    for (int i = 0; i < N; ++i)
                        selected[cursor][i] = 0;

                }
                else if (typed.Key == ConsoleKey.Enter && command.Length > 0) //Perform command
                {
                    if (command == "COPY")
                    {
                        Copy(dir[cursor], dir[cursor^1], selected[cursor]);
                        for (int i = 0; i < N; ++i)
                            selected[cursor][i] = 0;
                    }
                    else
                    {
                        Console.WriteLine("\nCommand is unknown, press any character to continue");
                    }
                    command = "";
                }
                else if (typed.Key == ConsoleKey.Tab)    //Switch cursor
                {
                    cursor ^= 1;
                }
                else if (typed.Modifiers == ConsoleModifiers.Shift && (typed.Key == ConsoleKey.UpArrow || typed.Key == ConsoleKey.DownArrow 
                    || 
                    typed.Key == ConsoleKey.PageUp || typed.Key == ConsoleKey.PageDown))
                {
                    selected[cursor][start[cursor] + state[cursor]] ^= 1;
                    Make_Move(dir, state, start, cursor, typed);
                }
                else if ((typed.Key == ConsoleKey.UpArrow || typed.Key == ConsoleKey.DownArrow
                    || 
                    typed.Key == ConsoleKey.PageUp || typed.Key == ConsoleKey.PageDown))
                {
                    Make_Move(dir, state, start, cursor, typed);
                }
                else if (typed.Key == ConsoleKey.Backspace)
                {
                    if (command.Length > 0)
                    command = command.Remove(command.Length - 1);
                }
                else
                {
                    command += typed.KeyChar;
                }
            }
        }
    }
}

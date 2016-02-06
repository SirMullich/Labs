using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_git
{
    class Program
    {
        static void ShowInfo(string path) {
            DirectoryInfo directory = new DirectoryInfo(path);
            Console.WriteLine(directory.FullName + ": " + directory.GetFiles().Length);
            
            DirectoryInfo[] directories = directory.GetDirectories();

            for (int i = 0; i < directories.Length; i++) {
                Console.WriteLine(directories[i].FullName + ": " + directories[i].GetFiles().Length);
                DirectoryInfo[] d2 = directories[i].GetDirectories();
                for (int j=0; j < d2.Length; j++) {
                    Console.WriteLine(d2[j].FullName + ": " + d2[j].GetFiles().Length);
                }
            }

        }
        static void ShowRecursive(string path)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                Console.WriteLine(dir.FullName + ": " + dir.GetFiles().Length);
                //Console.WriteLine("Check" + dir.ToString());

                DirectoryInfo[] subdirs = dir.GetDirectories();

                for (int i = 0; i < subdirs.Length; i++)
                {
                    ShowRecursive(subdirs[i].FullName);
                }
            }
            catch
            {

            }
     
        }
        static void Main(string[] args)
        {
            ShowRecursive(@"D:\Programming");
            //Ex4();
        }
        static void Ex4()
        {
            FileStream fs = new FileStream("input.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string text = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            Console.WriteLine(text);
        }
        static void Ex3()
        {
            FileStream fs = new FileStream("input.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadLine();
            sr.Close();
            fs.Close();
            string[] str_arr = line.Split(' ');
            int sum = 0;
            for (int i = 0; i < str_arr.Length; i++)
            {
                sum += int.Parse(str_arr[i]);
            }
            Console.WriteLine(sum);

        }
        static void Ex2()
        {
            FileStream fs = new FileStream("input.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            Console.WriteLine(sr.ReadLine());
            sr.Close();
            fs.Close();
        }
        static void Ex1()
        {
            FileStream fs = new FileStream("input.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Hiiiii noobs");
            sw.Close();
            fs.Close();
        }
    }
}

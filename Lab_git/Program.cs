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
        static void Main(string[] args)
        {
            Ex4();
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

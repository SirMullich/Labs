using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example2
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(doit));
            t1.Start("t1");

            Thread t2 = new Thread(new ParameterizedThreadStart(doit));
            t2.Start("t2");
        }

        private static void doit(object obj)
        {
            while (true)
            {
                string message = obj as string;
                Console.WriteLine(message + Thread.CurrentThread.ManagedThreadId);
               // Thread.Sleep(1000);
            }
        }
    }
}
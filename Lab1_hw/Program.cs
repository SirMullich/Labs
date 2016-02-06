using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


//Added comment
namespace Lab1_hw
{
    class Program
    {
        /// <summary>
        /// файловый менеджер, который использует Console.ReadKey()
        /// </summary>
        static void FileMan1()
        {
            string path = @"D:\Programming\Workspaces";
            DirectoryInfo dir = new DirectoryInfo(path);

            //Все директории и файлы из dir запоминаем в list
            List<FileSystemInfo> items = new List<FileSystemInfo>();
            items.AddRange(dir.GetDirectories());
            items.AddRange(dir.GetFiles());

            //подсвеченный каталог или файл
            int index = 0;

            //открыт ли файл
            bool fileOpened = false;

            //флаг для остановки программы
            bool run = true;

            while (run)
            {
                //Рисование
                if (fileOpened)
                {
                    string line;
                    StreamReader sr = new StreamReader(items[index].FullName);
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                    sr.Close();
                }
                else
                {
                    //вывод папок и управление ими
                    for (int i = 0; i < items.Count; ++i)
                    {
                        if (i == index)
                        {
                            //папка
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                        }
                        if (items[i].GetType() == typeof(FileInfo))
                        {
                            //файл
                            Console.ForegroundColor = ConsoleColor.Green;
                        }

                        Console.WriteLine(items[i].Name);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                //нажатие клавиш
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if ((index > 0) && (!fileOpened)) index--;
                        break;
                    case ConsoleKey.DownArrow:
                        if ((index < items.Count - 1) && (!fileOpened)) index++;
                        break;
                    case ConsoleKey.Enter:
                        //если это файл
                        if (items[index].GetType() == typeof(FileInfo))
                        {
                            fileOpened = true;
                        }
                        //если это папка
                        if (items[index].GetType() == typeof(DirectoryInfo))
                        {
                            path = items[index].FullName;
                            dir = new DirectoryInfo(path);
                            items.Clear();
                            items.AddRange(dir.GetDirectories());
                            items.AddRange(dir.GetFiles());
                            index = 0;
                        }
                        
                        break;
                    case ConsoleKey.Escape:
                        try
                        {
                            //Выходит в родительскую папку, если не открыт файл
                            if (!fileOpened)
                            {
                                if  ( Directory.Exists(dir.Parent.FullName) )
                                {
                                    path = dir.Parent.FullName;
                                    dir = new DirectoryInfo(path);
                                    items.Clear();
                                    items.AddRange(dir.GetDirectories());
                                    items.AddRange(dir.GetFiles());
                                    index = 0;
                                }
                                else
                                {
                                }
                                
                            }
                            else
                            {
                                //закрываем файл
                                fileOpened = false;
                            }
                        }
                        catch
                        {

                        }
                        break;
                    case ConsoleKey.X:
                        run = false;
                        break;
                }
                Console.Clear();
            }
        }
        /// <summary>
        /// для каждой директории в path выводит количество файлов. Работает через стэк
        /// </summary>
        /// <param name="path">путь к начальной директории</param>
        static void Prob1(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            Stack<DirectoryInfo> stacky = new Stack<DirectoryInfo>();

            //пуш начальной директории в стэк
            stacky.Push(dir);

            //используем try, чтобы не отлавливать ошибки связанные с правами доступа и т.д.
            try
            {
                //пока стэк не пустой
                while (stacky.Count > 0)
                {
                    //поп верхний элемент стэка
                    DirectoryInfo poped = stacky.Pop();
                    //выводим количество файлов в этой директории
                    Console.WriteLine("{0}: {1} files.", poped.FullName, poped.GetFiles().Length);
                    //все под-директории пушим в стэк
                    foreach (DirectoryInfo subdir in poped.GetDirectories())
                    {
                        stacky.Push(subdir);
                    }
                }
            }
            catch
            {
                //ничего не делаем с ошибками, потому что лень
            }
        }
        /// <summary>
        /// Открывает файл и прочитывает его. Находит минимальное и масимальное число и выводит их.
        /// </summary>
        static void Prob2()
        {
            FileStream fs = new FileStream(@"D:\Programming\Workspaces\Lab_git\Lab1_hw\input.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            //читаем всё содержимое файла
            string text = sr.ReadToEnd();

            //закрываем стримы
            sr.Close();
            fs.Close();

            //разделители, по которым делим текст
            char[] delimiters = new char[] { '\r', ' ', '\n' };
            string[] str_arr = text.Split( delimiters, StringSplitOptions.RemoveEmptyEntries);

            //Проверка на пустоту массива чисел
            if (str_arr.Length > 0)
            {
                int max = int.Parse(str_arr[0]);
                int min = int.Parse(str_arr[0]);

                for (int i = 0; i < str_arr.Length; ++i)
                {
                    if (int.Parse(str_arr[i]) > max)
                    {
                        max = int.Parse(str_arr[i]);
                    }
                    if (int.Parse(str_arr[i]) < min)
                    {
                        min = int.Parse(str_arr[i]);
                    }
                }
                Console.WriteLine("Минимальное число: {0} \t Максимальное число: {1}", min, max);
            }
            else
            {
                Console.WriteLine("В файле должно быть хотя бы одно число");
            }
        }
        /// <summary>
        /// Открывает файл (создаёт новый, если файл не существует). Проверяет числа на простату и выводит минимальное простое число.
        /// </summary>
        static void Prob3()
        {
            FileStream fs = new FileStream("input2.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            //Считывает всё содержимое файла
            String text = sr.ReadToEnd();
            sr.Close();
            fs.Close();

            //разделители, по которым делим текст
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            String[] str_array = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            //используем try чтобы не прога не падали из-за кучи разных ошибок
            try
            {
                //список хранит простые числа найденные в файле
                List<int> spisok = new List<int>();

                //для каждого числа из файла
                foreach (string str in str_array)
                {
                    //если простое, то записываем в лист
                    if (IsPrime(str))
                    {
                        spisok.Add(int.Parse(str));
                    }
                }
                //Создаём папку output в текущей директории и создаём файл output1.txt. Потом записываем в него результат
                string currentdir = Directory.GetCurrentDirectory();
                if (!Directory.Exists(currentdir + "\\output"))
                {
                    Directory.CreateDirectory(currentdir + "\\output");
                }
                //Стрим для записи в файл
                FileStream fs_out = new FileStream(currentdir + @"\output\output1.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs_out);

                //Запись минимального простого числа в файл output1.txt
                sw.Write(spisok.Min().ToString() + " ");

                //Закрытие стримов
                sw.Close();
                fs_out.Close();
            }
            catch
            {

            }
        }
        /// <summary>
        /// Функция для проверки числа на простое
        /// </summary>
        /// <param name="s">число в виде строки, которое нужно проверить</param>
        /// <returns> ответ правда или ложь, простое ли число</returns>
        /// Код с первой недели
        static bool IsPrime(string s)
        {
            //конвертация от типа строки в тип целое число
            int x = int.Parse(s);
            int cnt = 0;
            //подсчет кол-ва делителей отличных от 1 и самого числа
            for (int j = 2; j <= Math.Sqrt(x); ++j)
            {
                if (x % j == 0)
                {
                    cnt++;
                }
            }

            return cnt == 0 && x != 1;
        }
        static void Main(string[] args)
        {
            //Prob1(@"D:\Programming"); //1-ая задача
            //Prob2();                  //2-ая задача
            //Prob3();                  //3-яя задача
            FileMan1();                //файловый менеджер 
        }
    }
}

//Спросить разницу между
//1. string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");
//2. System.IO.StreamReader file = 
//    new System.IO.StreamReader(@"c:\test.txt");
//while((line = file.ReadLine()) != null)
//{
//    System.Console.WriteLine (line);
//}
//3. FileStream fs = new FileStream("test.txt");
//StreamReader sr = new StreamReader(fs);

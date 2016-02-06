using Lab2_hw.Models;
using System;
using System.IO;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab2_hw
{
    class Program
    {
        //сохранение с помощью BinaryFormatter
        public static void SaveBinary(Game g) 
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("save.dat", FileMode.OpenOrCreate, FileAccess.Write);

            bf.Serialize(fs, g);
            fs.Close();
        }
        //загрузка с помощью BinaryFormatter
        public static Game LoadBinary(Game g)
        {
            FileStream fs = new FileStream("save.dat", FileMode.OpenOrCreate, FileAccess.Read);
            Game returnGame = new Game();
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                returnGame = bf.Deserialize(fs) as Game;
            }
            catch
            {

            }
            finally
            {
                fs.Close();
            }
            return returnGame;
        }
        static void Main(string[] args)
        {
            Game g1 = new Game();
            g1.LoadLevel(g1.level);
            g1.Init();

            Console.SetWindowSize(78, 49);

            while (g1.inGame)
            {
                if (g1.score > 4) 
                {
                    //если последний уровень, то выигрыш
                    if (g1.level == 4)
                    {
                        g1.Win();
                        return;
                    }
                    //в противном случае, переход на следующий уровень
                    else
                    {
                        g1.NextLevel();
                    }
                }
                g1.ReDraw();

                ConsoleKeyInfo pressedKey = Console.ReadKey();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        g1.snake.Move(0, -1, g1);
                        break;
                    case ConsoleKey.DownArrow:
                        g1.snake.Move(0, 1, g1);
                        break;
                    case ConsoleKey.LeftArrow:
                        g1.snake.Move(-1, 0, g1);
                        break;
                    case ConsoleKey.RightArrow:
                        g1.snake.Move(1, 0, g1);
                        break;
                    case ConsoleKey.Escape:
                        g1.inGame = false;
                        break;
                    case ConsoleKey.F2:
                        g1.Save(g1);
                        break;
                    case ConsoleKey.F3:
                        g1.Resume(g1);
                        break;
                    case ConsoleKey.F4:
                        SaveBinary(g1);
                        break;
                    case ConsoleKey.F5:
                        g1 = LoadBinary(g1);
                        break;
                    case ConsoleKey.W:
                        g1.Win();
                        break;
                    case ConsoleKey.D:
                        foreach (Point p in g1.food.available)
                        {
                            Console.SetCursorPosition(p.x, p.y);
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write('%');
                        }
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}

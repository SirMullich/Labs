using Lab2_hw.Models;
using System;
using System.IO;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.Timers;

namespace Lab2_hw
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Game g1 = Game.GetInstance;
            Console.SetWindowSize(78, 49);
            g1.Init();
            while (g1.inGame && g1.timer.Enabled)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (g1.snake.velocity[1] == 0)
                        {
                            g1.snake.velocity[0] = 0;
                            g1.snake.velocity[1] = -1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (g1.snake.velocity[1] == 0)
                        {
                            g1.snake.velocity[0] = 0;
                            g1.snake.velocity[1] = 1;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (g1.snake.velocity[0] == 0)
                        {
                            g1.snake.velocity[0] = -1;
                            g1.snake.velocity[1] = 0;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (g1.snake.velocity[0] == 0)
                        {
                            g1.snake.velocity[0] = 1;
                            g1.snake.velocity[1] = 0;
                        }
                        break;
                    case ConsoleKey.Escape:
                        g1.inGame = false;
                        break;
                    case ConsoleKey.F2:
                        g1.Save();
                        break;
                    case ConsoleKey.F3:
                        g1.Resume();
                        break;
                    case ConsoleKey.F4:
                        g1.SaveBinary();
                        break;
                    case ConsoleKey.F5:
                        g1.LoadBinary();
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

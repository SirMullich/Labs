using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Lab2_hw.Models
{
    [Serializable]
    public sealed class Game
    {
        private static Game instance = null;
        private static readonly object lockObj = new object();
        
        public bool inGame;
        public int level;
        public Snake snake;
        public Wall wall;
        public Food food;
        public Border border;
        public Random rnd;
        public int score;
        public int totalScore;
        public System.Timers.Timer timer;

        private Game()
        {
            inGame = true;
            level = 1;
            snake = new Snake();
            wall = new Wall();
            food = new Food();
            border = new Border();
            rnd = new Random();
            score = 0;
            totalScore = 0;
            timer = new System.Timers.Timer();
            
            //timer = new Timer(new TimerCallback(Tick));
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            GetInstance.snake.Move(GetInstance);
            //ReDraw();
        }
        public static Game GetInstance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new Game();
                    }
                    return instance;
                }
            }
        }
        //перерисовка
        public void ReDraw() {
            snake.Draw();
        }
        //Загрузка уровня
        public void LoadLevel(int level)
        {
            //открытие стрима и считывание по одной строке из файла
            FileStream fs = new FileStream(string.Format(@"Levels\LevelWall{0}.txt", level), FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line;
            int row = 0;
            int col = 0;

            while ((line = sr.ReadLine()) != null)
            {
                col = 0;
                foreach (char c in line)
                {
                    if (c == '#')
                    {
                        Point wallPoint = new Point { x = col, y = row };
                        wall.body.Add(wallPoint);

                        //Удалить эту точку, если она в списке возможных точек еды
                        food.DeleteAvail(wallPoint, GetInstance);
                    }
                    col++;
                }
                row++;
            }
            fs.Close();
            wall.Draw();
        }
        //Сохранить игру
        public void Save()
        {
            wall.Save(GetInstance);
            food.Save(GetInstance);
            snake.Save(GetInstance);
        }
        //Продолжить игру
        public void Resume()
        {
            wall.Resume(GetInstance);
            food.Resume(GetInstance);
            snake.Resume(GetInstance);
        }
        //Инициализация игры
        public void Init()
        {
            Point startPoint = new Point { x = 10, y = 10 };
            snake.body.Add(startPoint);
            food.DeleteAvail(startPoint, GetInstance);
            food.body.Add(new Point { x = 20, y = 10 });
            LoadLevel(level);
            // запуск таймера
            wall.Draw();
            border.Draw();
            snake.Draw();
            food.Draw();
            DrawScoreLevel();

            timer.Elapsed += timer_Elapsed;
            timer.Interval = 180;
            timer.Start();
        }
        //Конец игры
        public void GameOver()
        {
            timer.Stop();
            timer.Close();
            SoundPlayer simpleSound = new SoundPlayer(@"Sounds/lose.wav");
            simpleSound.Play();
            Console.Clear();
            Console.SetCursorPosition(25, 15);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game Over!");
            Console.SetCursorPosition(20, 25);
            Console.WriteLine("Your total score: {0}", totalScore);
            inGame = false;
            //пауза чтобы музыка доиграла
            System.Threading.Thread.Sleep(5000);
        }
        public void Win()
        {
            timer.Stop();
            SoundPlayer simpleSound = new SoundPlayer(@"Sounds/win.wav");
            simpleSound.Play();
            Console.Clear();
            Console.SetCursorPosition(25, 15);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Congratulations you WON!!!");
            //пауза чтобы музыка доиграла
            System.Threading.Thread.Sleep(5000);
            inGame = false;
        }
        //рисование очков рядом с игровым полем
        public void DrawScoreLevel()
        {
            Console.SetCursorPosition(60, 10);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Level: {0}", level);
            Console.SetCursorPosition(60, 18);
            Console.Write("Score: {0}", score);
            Console.SetCursorPosition(60, 26);
            Console.Write("Total score: {0}", totalScore);
        }
        public void NextLevel()
        {
            if (level < 5)
            {
                Console.Clear();
                //опусташение тел змеи и еды и стены
                snake.body.Clear();
                food.body.Clear();
                wall.body.Clear();
                //создание новой еды, чтобы занаво пополнить список available
                food = new Food();

                //следующий уровень
                level++;
                LoadLevel(level);
                food.Draw();
                border.Draw();
                score = 0;
                if (timer.Interval > 50)
                {
                    timer.Interval -= 50;    
                }

                int r1 = rnd.Next(food.available.Count);
                Point s = food.available[r1];
                snake.body.Add(s);
                food.DeleteAvail(s, GetInstance);
                int r2 = rnd.Next(food.available.Count);
                Point f = food.available[r2];
                food.body.Add(f);
                //food.body.Add(new Point { x = food.available[r2].x, y = food.available[r2].y });
            }
            else
            {
                GameOver();
            }
        }
        //сохранение с помощью BinaryFormatter
        public void SaveBinary()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("save.dat", FileMode.Create, FileAccess.Write);

            bf.Serialize(fs, instance);
            fs.Close();
        }
        //загрузка с помощью BinaryFormatter
        public void LoadBinary()
        {
            FileStream fs = new FileStream("save.dat", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            instance = bf.Deserialize(fs) as Game;
            fs.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2_hw.Models
{
    [Serializable]
    public class Game
    {
        public bool inGame;
        public int level;
        public Snake snake;
        public Wall wall;
        public Food food;
        public Border border;
        public Random rnd;
        public int score;
        public int totalScore;

        public Game()
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
        }
        //перерисовка
        public void ReDraw() {
            Console.Clear();
            snake.Draw();
            wall.Draw();
            food.Draw();
            border.Draw();
            DrawScoreLevel();
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
                        food.DeleteAvail(wallPoint, this);
                    }
                    col++;
                }
                row++;
            }
            fs.Close();
        }
        //Сохранить игру
        public void Save(Game game)
        {
            wall.Save(game);
            food.Save(game);
            snake.Save(game);
        }
        //Продолжить игру
        public void Resume(Game game)
        {
            game.wall.Resume(game);
            game.food.Resume(game);
            game.snake.Resume(game);
        }
        //Инициализация игры
        public void Init()
        {
            Point startPoint = new Point { x = 10, y = 10 };
            snake.body.Add(startPoint);
            food.DeleteAvail(startPoint, this);
            food.body.Add(new Point { x = 20, y = 10 });
        }
        //Конец игры
        public void GameOver()
        {
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
            Thread.Sleep(5000);
        }
        public void Win()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"Sounds/win.wav");
            simpleSound.Play();
            Console.Clear();
            Console.SetCursorPosition(25, 15);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Congratulations you WON!!!");
            //пауза чтобы музыка доиграла
            Thread.Sleep(5000);
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
                //опусташение тел змеи и еды и стены
                snake.body.Clear();
                food.body.Clear();
                wall.body.Clear();
                //создание новой еды, чтобы занаво пополнить список available
                food = new Food();

                //следующий уровень
                level++;
                LoadLevel(level);
                score = 0;

                int r1 = rnd.Next(food.available.Count);
                Point s = food.available[r1];
                snake.body.Add(s);
                food.DeleteAvail(s, this);
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
    }
}

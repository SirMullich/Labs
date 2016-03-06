using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_hw.Models
{
    [Serializable]
    public class Snake : Drawer
    {
        Point head = new Point();
        public int[] velocity = new int[2];
        public void Eat(Game game) 
        {
            //добавил к змейке новую точку. прирост
            body.Add(new Point { x = body[body.Count-1].x, y = body[body.Count-1].y });
            //перемещение еды на новое случайное место, без попадания на стену или змейку
            int r = game.rnd.Next(game.food.available.Count);
            game.food.body[0].x = game.food.available[r].x;
            game.food.body[0].y = game.food.available[r].y;

            //увеличение очков
            game.score++;
            game.totalScore++;
            game.DrawScoreLevel();
            if (game.score > 4)
            {
                //если последний уровень, то выигрыш
                if (game.level == 4)
                {
                    game.Win();
                }
                //в противном случае, переход на следующий уровень
                else
                {
                    game.NextLevel();
                }
            }
            game.food.Draw();
            game.DrawScoreLevel();
        }
        public Snake()
        {
            color = ConsoleColor.Yellow;
            sign = 'o';
            velocity[0] = 1;
            velocity[1] = 0;
        }

        public void Move(Game game)
        {
            //выход из функции, если вышли за границы игрового поля
            if (body[0].x + velocity[0] > 47 || body[0].x + velocity[0] < 0 || body[0].y + velocity[1] > 47 || body[0].y + velocity[1] < 0)
            {
                return;
            }
            //последнюю точку тела змеи добавляем в возможные точки для еды ДО ДВИЖЕНИЯ
            Point tail = new Point { x = body[body.Count - 1].x, y = body[body.Count - 1].y };
            if (!game.food.available.Contains(body[body.Count - 1])) 
            {
                if (!(body.Count > 1 && body[body.Count-1].Equals(body[body.Count-2])))
                {
                    game.food.available.Add(tail);
                }
            }
                

            //двигаем каждую точку тела
            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            // Двигаем голову
            body[0].x = body[0].x + velocity[0];
            body[0].y = body[0].y + velocity[1];

            // Рисование головы
            Console.ForegroundColor = color;
            Console.SetCursorPosition(body[0].x, body[0].y);
            Console.Write(sign);

            // Рисование хвоста
            Console.SetCursorPosition(tail.x, tail.y);
            Console.Write(" ");

            //новое положение головы убирается из возможных точек для еды, если оно там есть
            game.food.DeleteAvail(body[0], Game.GetInstance);
            //проверка, есть ли столкновение со стеной
            for (int i = 0; i < game.wall.body.Count; ++i)
            {
                if (game.snake.body[0].x == game.wall.body[i].x && game.snake.body[0].y == game.wall.body[i].y)
                {
                    game.GameOver();
                }
            }
            //проверка, на удар змеи в своё тело
            for (int i = 1; i < game.snake.body.Count; ++i)
            {
                //если положение головы равно положению любой из точек тела (кроме головы)
                if (game.snake.body[0].Equals(game.snake.body[i]))
                {
                    game.GameOver();
                }
            }
            //проверка, можем ли скушать
            if (body[0].x == game.food.body[0].x && body[0].y == game.food.body[0].y)
            {
                Eat(game);
            }
        }
    }
}
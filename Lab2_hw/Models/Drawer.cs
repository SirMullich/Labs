using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab2_hw.Models
{
    [Serializable]
    public class Drawer
    {
        public ConsoleColor color;
        public char sign;
        public List<Point> body = new List<Point>();
        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }
        public Drawer()
        {

        }
        public void Save(Game game)
        {
            string fileName = "";
            switch (sign)
            {
                case '#':
                    fileName = "wall.xml";
                    break;
                case '$':
                    fileName = "food.xml";
                    break;
                case 'o':
                    fileName = "snake.xml";
                    break;
            }
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(this.GetType());
            xs.Serialize(fs, this);
            fs.Close();
        }
        public void Resume(Game game)
        {
            string fileName = "";
            switch (sign)
            {
                case '#':
                    fileName = "wall.xml";
                    break;
                case '$':
                    fileName = "food.xml";
                    break;
                case 'o':
                    fileName = "snake.xml";
                    break;
            }
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(this.GetType());

            switch (sign)
            {
                case '#':
                    game.wall.body.Clear();
                    game.wall = xs.Deserialize(fs) as Wall;
                    break;
                case '$':
                    game.food.body.Clear();
                    game.food = xs.Deserialize(fs) as Food;
                    break;
                case 'o':
                    game.snake.body.Clear();
                    game.snake = xs.Deserialize(fs) as Snake;
                    break;
            }
            fs.Close();
        }
    }
}

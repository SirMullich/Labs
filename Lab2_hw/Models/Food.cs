using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_hw.Models
{
    [Serializable]
    public class Food : Drawer
    {
        public List<Point> available = new List<Point>();
        public Food()
        {
            color = ConsoleColor.Green;
            sign = '$';
            for (int i = 0; i < 48; ++i)
            {
                for (int j = 0; j < 48; ++j)
                {
                    available.Add(new Point { x = i, y = j });
                }
            }
            //Console.WriteLine("Food created");
            //Console.ReadKey();
        }
        //equals
        //Icomparable
        public void DeleteAvail(Point p, Game game)
        {
            for (int i = 0; i < available.Count; ++i)
            {
                if (available[i].x == p.x && available[i].y == p.y)
                {
                    game.food.available.RemoveAt(i);
                }
            }
        }
    }
}

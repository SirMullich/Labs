using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spaceship.Models
{
    class Game
    {
        List<MovableSpaceObject> movableObjects = new List<MovableSpaceObject>();
        public Bitmap bmp;
        Random rnd = new Random();
        public int w;
        public int h;
        Graphics gfx;

        public Game(int w, int h)
        {

            this.h = h;
            this.w = w;
            bmp = new Bitmap(w, h);
            gfx = Graphics.FromImage(bmp);

            int[] d1 = new int[] { -1, 1 };

            int x1 = rnd.Next(0, w - 10);
            int y1 = rnd.Next(0, h - 10);

            int dx1 = d1[rnd.Next(0, 2)];
            int dy1 = d1[rnd.Next(0, 2)];

            int speed1 = rnd.Next(1, 4);

            BattleCruiser bs = new BattleCruiser(
                10, 10,
                new Point(x1, y1),
                dx1, dy1,
                speed1,
                Color.Yellow,
                new Rectangle(0, 0, 624, 384)
                );


            movableObjects.Add(bs);

            for (int i = 0; i < 10; ++i)
            {
                int x = rnd.Next(0, w - 10);
                int y = rnd.Next(0, h - 10);

                int dx = d1[rnd.Next(0, 2)];
                int dy = d1[rnd.Next(0, 2)];

                int speed = rnd.Next(1, 4);

                Asteroid a = new Asteroid(
                    10, 10, 
                    new Point(x, y), 
                    dx, dy, 
                    speed, 
                    Color.Red,
                    new Rectangle(0, 0, 624, 384)
                    );

                movableObjects.Add(a);
            }
        }

        public void ChangeState()
        {
            foreach (MovableSpaceObject movableObject in movableObjects)
            {
                movableObject.Move();
                movableObject.UpdateGP();
            }
        }


        public void Repaint()
        {
            gfx.Clear(Color.DarkBlue);

            foreach (MovableSpaceObject movableObject in movableObjects)
            {
                gfx.FillPath(new SolidBrush(movableObject.color), movableObject.gp);
            }
        }

    }
}

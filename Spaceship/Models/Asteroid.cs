using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaceship.Models
{
    class Asteroid : MovableSpaceObject
    {
        //

        public Asteroid(
            int ow, int oh,
            Point location, 
            int dx, int dy, 
            int speed,
            Color color,
            Rectangle gameArena):base(ow,oh,location,dx,dy,speed,color,gameArena)
        {
        }

        public override void UpdateGP()
        {
            //Asteroids
            //SolidBrush solidBrush2 = new SolidBrush(Color.Red);
            //Point[] tri1 = new Point[3];
            //Point[] tri2 = new Point[3];
            //int len = 80;
            //for (int i = 0; i < 5; i++)
            //{
            //    pos1 = rnd.Next(0, 750);
            //    pos2 = rnd.Next(0, 550);
            //    tri1[0].X = pos1;
            //    tri1[0].Y = pos2;

            //    tri1[1].X = pos1 + len;
            //    tri1[1].Y = pos2;

            //    tri1[2].X = pos1 + len / 2;
            //    tri1[2].Y = pos2 - len;

            //    // 2 triangle
            //    tri2[0].X = pos1;
            //    tri2[0].Y = pos2 - len / 2 - len / 10;

            //    tri2[1].X = pos1 + len;
            //    tri2[1].Y = pos2 - len / 2 - len / 10;

            //    tri2[2].X = pos1 + len / 2;
            //    tri2[2].Y = pos2 + len / 2 - len / 10;

            //    gfx.FillPolygon(solidBrush2, tri1);
            //    gfx.FillPolygon(solidBrush2, tri2);
            //}
            this.gp.Reset();
            this.gp.AddLine(new PointF(location.X, location.Y), new PointF(location.X + 40, location.Y));
            this.gp.AddLine(new PointF(location.X + 40, location.Y), new PointF(location.X + 20, location.Y - 40));
            this.gp.AddLine(new PointF(location.X + 20, location.Y - 40), new PointF(location.X, location.Y));

            this.gp.AddLine(new PointF(location.X, location.Y - 2 * 12), new PointF(location.X + 2 * 20, location.Y - 2 * 12));
            this.gp.AddLine(new PointF(location.X + 2 * 20, location.Y - 2 * 12), new PointF(location.X + 2 * 10, location.Y + 2 * 8));
            this.gp.AddLine(new PointF(location.X + 2*10, location.Y + 2*8), new PointF(location.X, location.Y - 2*12));
        }
    }
}

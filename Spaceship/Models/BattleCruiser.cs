using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaceship.Models
{
    class BattleCruiser : MovableSpaceObject
    {
        public BattleCruiser(
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
            this.gp.Reset();
            this.gp.AddLine(new PointF(location.X, location.Y), new PointF(location.X, location.Y + 10));
            this.gp.AddLine(new PointF(location.X, location.Y + 10), new PointF(location.X + 10, location.Y + 10));
            this.gp.AddLine(new PointF(location.X + 10, location.Y + 10), new PointF(location.X + 10, location.Y));
            this.gp.AddLine(new PointF(location.X + 10, location.Y), new PointF(location.X, location.Y));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaceship.Models
{
    abstract class MovableSpaceObject : BaseSpaceObject
    {
        public int speedX;
        public int speedY;
        public int dx;
        public int dy;  

        public MovableSpaceObject(
            int ow, int oh,
            Point location,
            int dx, int dy,
            int speed,
            Color color,
            Rectangle gameArena)
        {
            this.boundingBox = new Rectangle(location, new Size(ow, oh));
            this.gameArena = gameArena;

            this.speedX = speed;
            this.speedY = speed;
            this.dx = dx;
            this.dy = dy;
            this.gp = new GraphicsPath();

            this.location = location;
            this.color = color;
        }

        public void Move()
        {

            if (location.X + boundingBox.Width + dx * speedX > gameArena.Width)
            {
                dx = -1;
            }
            else if (location.X + dx * speedX <= 0)
            {
                dx = 1;
            }

            if (location.Y + dy * speedY + boundingBox.Height > gameArena.Height)
            {
                dy = -1;
            }
            else if (location.Y + speedY * dy <= 0)
            {
                dy = 1;
            }

            location.X += dx * speedX;
            location.Y += dy * speedY;
        }

        public virtual void UpdateGP() { }
        
    }
}

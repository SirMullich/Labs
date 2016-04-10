using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaceship.Models
{
    abstract class BaseSpaceObject
    {
        public Rectangle boundingBox;
        public Rectangle gameArena;
        public GraphicsPath gp;
        public Color color;
        public Point location;
    }
}

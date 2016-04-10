using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example2.Model
{
    public enum Shape
    {
        Line,
        Circle,
        Rectangle,
        Pencil,
        Eraser,
        Triangle,
        Fill
    }
    public enum DrawTool
    {
        Pen,
        Brush
    }

    public class DrawerState
    {
        public Pen pen = new Pen(Color.Red);
        public Bitmap bmp;
        Graphics g;
        GraphicsPath path;
        private PictureBox pictureBox1;

        public Point prevPoint;

        public DrawTool DrawTool { get; set; }
        public Shape Shape { get; set; }

        public void FixPath()
        {
            if (path != null)
            {
                g.DrawPath(pen, path);
                path = null;
            }
        }

        public DrawerState(PictureBox pictureBox1)
        {
            this.pictureBox1 = pictureBox1;
            
            Load("");

            DrawTool = DrawTool.Pen;
            Shape = Shape.Pencil;

            pictureBox1.Paint += PictureBox1_Paint;
            pictureBox1.MouseClick += PictureBox1_MouseClick;
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Shape == Shape.Fill)
            {
                FloodFill(e.Location);
                g = Graphics.FromImage(bmp);
                pictureBox1.Image = bmp;
            }
        }

        private void FloodFill(Point p)
        {
            SimplePaint.MapFill m = new SimplePaint.MapFill();
            m.Fill(g, p, pen.Color, ref bmp);
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (path != null)
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        public void Draw(Point currentPoint)
        {
            switch (Shape)
            {
                case Shape.Line:
                    path = new GraphicsPath();
                    path.AddLine(prevPoint, currentPoint);
                    break;
                case Shape.Circle:
                    path = new GraphicsPath();
                    path.AddEllipse(new Rectangle(Math.Min(prevPoint.X, currentPoint.X), Math.Min(prevPoint.Y, currentPoint.Y), Math.Abs(currentPoint.X - prevPoint.X), Math.Abs(currentPoint.Y - prevPoint.Y)));
                    break;
                case Shape.Rectangle:
                    path = new GraphicsPath();
                    path.AddRectangle(new Rectangle(Math.Min(prevPoint.X, currentPoint.X), Math.Min(prevPoint.Y, currentPoint.Y), Math.Abs(currentPoint.X - prevPoint.X), Math.Abs(currentPoint.Y - prevPoint.Y)));                        
                    break;
                case Shape.Pencil:
                    g.DrawLine(pen, prevPoint, currentPoint);

                    prevPoint = currentPoint;
                    break;
                case Shape.Eraser:
                    g.DrawLine(new Pen(Color.White, pen.Width + 5), prevPoint, currentPoint);
                    prevPoint = currentPoint;
                    break;
                case Shape.Fill:
                    
                    break;
                case Shape.Triangle:
                    path = new GraphicsPath();

                    //Точка где прямой угол
                    Point trgl = new Point();

                    trgl.X = currentPoint.X - (currentPoint.X - prevPoint.X);
                    trgl.Y = currentPoint.Y;
                    Point[] Points = {trgl, prevPoint, currentPoint};
                    path.AddPolygon(Points); 
                    break;
                default:
                    break;
            }
            pictureBox1.Refresh();
        }

        public void Save(string fileName)
        {
            bmp.Save(fileName);
        }

        public void Load(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                bmp = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
                g = Graphics.FromImage(bmp);
                g.Clear(Color.White);
            }
            else {
                bmp = new Bitmap(fileName);
                g = Graphics.FromImage(bmp);
            }
            pictureBox1.Image = bmp;
        }
    }
}

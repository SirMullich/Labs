using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week7_Sinusoid_Graph
{
    public partial class Form1 : Form
    {
        Pen p = new Pen(Color.Blue, 2);
        Timer timer = new Timer();
        float coord_x;
        float coord_y;
        GraphicsPath gp;
        public Bitmap bmp;
        Graphics gfx;

        public Form1()
        {
            InitializeComponent();
            timer.Interval = 10;
            timer.Tick += MoveEllipse;
            timer.Start();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gfx = Graphics.FromImage(bmp);
            
            coord_x = 0.0F;
            coord_y = 0.0F;
            gp = new GraphicsPath();

            gfx.DrawLine(new Pen(Color.Red, 2), new Point() { X = 0, Y = 150 }, new Point() { X = this.Width, Y = 150});
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MoveEllipse(object sender, EventArgs e)
        {
            if (8 * coord_x < this.Width)
            {
                //gp.AddLine(new PointF(8 * coord_x, 150 + 100 * coord_y), new PointF(8 * (coord_x + 0.1F), 150 + 100 * coord_y));
                
                //Refresh();

                gfx.DrawLine(p, new PointF(8 * coord_x, 150 + 100 * coord_y), new PointF(8 * (coord_x + 0.05F), 150 + 100 * (float)(Math.Sin(coord_x + 0.05))));
                coord_x += 0.05F;
                coord_y = (float)(Math.Sin(coord_x));
                pictureBox1.Image = bmp;
                
            }
            else
            {
                timer.Stop();
            }
            
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //e.Graphics.DrawPath(p, gp);
        }
    }
}

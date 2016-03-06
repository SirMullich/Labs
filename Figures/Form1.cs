using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figures
{
    public partial class Form1 : Form
    {
        Bitmap bmp = new Bitmap(800, 600);
        Random rnd = new Random();
        int pos1;
        int pos2;

        public Form1()
        {
            InitializeComponent();
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.Clear(Color.Blue);
            SolidBrush solidBrush1 = new SolidBrush(Color.White);
            
            //stars
            for (int i = 0; i < 10; i++)
            {
                pos1 = rnd.Next(0, 750);
                pos2 = rnd.Next(0,550);
                gfx.FillEllipse(solidBrush1, pos1, pos2, 40, 40);
            }
            //Asteroids
            SolidBrush solidBrush2 = new SolidBrush(Color.Red);
            Point[] tri1 = new Point[3];
            Point[] tri2 = new Point[3]; 
            int len = 80;
            for (int i = 0; i < 5; i++)
            {
                pos1 = rnd.Next(0, 750);
                pos2 = rnd.Next(0,550);
                tri1[0].X = pos1;
                tri1[0].Y = pos2;

                tri1[1].X = pos1 + len;
                tri1[1].Y = pos2;

                tri1[2].X = pos1 + len / 2;
                tri1[2].Y = pos2 - len;

                // 2 triangle
                tri2[0].X = pos1;
                tri2[0].Y = pos2 - len/2 - len/10;

                tri2[1].X = pos1 + len;
                tri2[1].Y = pos2 - len / 2 - len / 10;

                tri2[2].X = pos1 + len / 2;
                tri2[2].Y = pos2 + len / 2 - len / 10;

                gfx.FillPolygon(solidBrush2, tri1);
                gfx.FillPolygon(solidBrush2, tri2);
            }
            //Ship
            SolidBrush solidBrush3 = new SolidBrush(Color.Yellow);
            Point[] ship = new Point[6];
            pos1 = 400 - len / 2;
            pos2 = 300 - len / 2;
            len = 120;
            ship[0].X = pos1;
            ship[0].Y = pos2;

            ship[1].X = pos1 + len/2;
            ship[1].Y = pos2 - len / 2 + len/10; ;

            ship[2].X = pos1 + len;
            ship[2].Y = pos2;

            ship[3].X = pos1 + len;
            ship[3].Y = pos2 + len / 2 - len / 10; ;

            ship[4].X = pos1 + len/2;
            ship[4].Y = pos2 + len / 2 + len / 4;

            ship[5].X = pos1;
            ship[5].Y = pos2 + len/2 - len/10;

            gfx.FillPolygon(solidBrush3, ship);

            //Gun
            Point[] gun = new Point[7];
            gun[0].X = pos1 + 40;
            gun[0].Y = pos2 + 50;

            gun[1].X = gun[0].X;
            gun[1].Y = gun[0].Y - 40;

            gun[2].X = gun[1].X - 20;
            gun[2].Y = gun[1].Y;

            gun[3].X = gun[2].X + 40;
            gun[3].Y = gun[2].Y - 30;

            gun[4].X = gun[3].X + 40;
            gun[4].Y = gun[3].Y + 30;

            gun[5].X = gun[4].X - 20;
            gun[5].Y = gun[4].Y;

            gun[6].X = gun[5].X;
            gun[6].Y = gun[5].Y + 40;



            gfx.FillPolygon(new SolidBrush(Color.Green), gun);
            
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 10, 10);
        }
    }
}

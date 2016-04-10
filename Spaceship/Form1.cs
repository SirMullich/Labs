using Spaceship.Models;
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

namespace Spaceship
{
    public partial class Form1 : Form
    {
        Timer timer;
        Game g;

        public Form1()
        {
            InitializeComponent();

            g = new Game(pictureBox1.Width, pictureBox1.Height);

            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
          //    label1.Text = pictureBox1.Width + " " + pictureBox1.Height;
            g.ChangeState();
            g.Repaint();
            pictureBox1.Image = g.bmp;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           // e.Graphics.DrawImage(bmp, 10, 10);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            label1.Text = e.KeyChar.ToString();
        }
    }
}

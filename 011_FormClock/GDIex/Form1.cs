using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDIex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Red);
            g.DrawLine(p, new Point(10, 10), new Point(200, 200));

            Font f = new Font("굴림", 40, FontStyle.Bold | FontStyle.Italic);

            g.DrawString("Hello C#", f, Brushes.Red, new Point(60, 10));

            Brush b = new SolidBrush(Color.Blue);
            Rectangle rect = new Rectangle(50, 10, 150, 110);
            Rectangle rect1 = new Rectangle(50, 50, 150, 150);

            Pen gp = new Pen(Color.LightSteelBlue, 30);
            g.DrawEllipse(gp, rect1);

            g.RotateTransform(45);
            g.FillRectangle(b, rect);



        }
    }
}

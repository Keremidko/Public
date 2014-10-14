using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Threading_Demo
{

    public partial class DemoForm : Form
    {
        private List<Circle> doodles;

        private static int NUMBER_OF_CIRCLES = 6;
        private static int RADIUS_OF_CIRCLES = 7;

        public DemoForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            generateDoodles();
            this.timer.Start();
        }

        private void generateDoodles()
        {
            doodles = new List<Circle>();
            int panelWidth = panel.Width;
            int panelHeight = panel.Height;
            Random rnd = new Random();

            CircleEnvironment env = new CircleEnvironment
            {
                envSize = panel.Bounds,
                otherCircles = doodles
            };

            for (int i = 0; i < NUMBER_OF_CIRCLES; i++)
            {
                CircleConstructParams cParams = new CircleConstructParams
                {
                    x = rnd.NextDouble() * panelWidth,
                    y = rnd.NextDouble() * panelHeight,
                    dirX = rnd.NextDouble() * 2 - 1,
                    dirY = rnd.NextDouble() * 2 - 1,
                    speed = rnd.Next(5,5),
                    rad = RADIUS_OF_CIRCLES
                };
                Circle circle = new Circle( cParams, env );
                doodles.Add(circle);
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            if (doodles != null)
            {
                e.Graphics.Clear(Color.White);
                foreach (Circle circle in doodles)
                {
                    //e.Graphics.FillEllipse(new SolidBrush(Color.Red) , (float)circle.x, (float)circle.y, (float)circle.rad * 2, (float)circle.rad * 2);
                    e.Graphics.DrawEllipse(new Pen(Color.Red, 2.0f), (float)circle.x, (float)circle.y, (float)circle.rad*2, (float)circle.rad*2);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.panel.Refresh();
        }

        private void DemoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Console.WriteLine("Logging out");
            Application.Exit();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            foreach (Circle circle in doodles)
                circle.pauseMovement();
            timer.Stop();
        }

        private void resumeButton_Click(object sender, EventArgs e)
        {
            foreach (Circle circle in doodles)
                circle.resumeMovement();
            timer.Start();
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threading_Demo
{
    public class Circle
    {

        private static int circlesCreated = 0;

        //Physical properties
        public double x { get; set; }
        public double y { get; set; }
        public double dirX { get; set; }
        public double dirY { get; set; }
        public int rad { get; set; }
        public int speed { get; set; }

        //Meta Properties
        private int id { get; set; }
        private CircleEnvironment env { get; set; }


        private Thread moveThread;

        public Circle(CircleConstructParams cParams, CircleEnvironment env)
        {
            circlesCreated++;

            this.x = cParams.x;
            this.y = cParams.y;
            this.rad = cParams.rad;
            this.dirX = cParams.dirX;
            this.dirY = cParams.dirY;
            this.speed = cParams.speed;

            if (x + rad > env.envSize.Width)
                x = env.envSize.Width - 2 * rad;
            if (x - rad < 0)
                x = rad + 1;
            if (y + rad > env.envSize.Height)
                y = env.envSize.Height - 2 * rad;
            if (y - rad < 0)
                y = rad + 1;

            this.id = circlesCreated;
            this.env = env;

            moveThread = new Thread(move);
            moveThread.IsBackground = true;
            moveThread.Start();
        }

        private void move()
        {
            while (true)
            {
                if (x + 2 * rad > env.envSize.Width || x + rad < rad)
                    changeXDirection();

                if (y + 2 * rad > env.envSize.Height || y + rad < rad)
                    changeYDirection();

                if (collidesWithEnvCircles())
                {
                    changeXDirection();
                    x += dirX * speed;
                    changeYDirection();
                    y += dirY * speed;
                }

                x += dirX * speed;
                y += dirY * speed;

                Thread.Sleep(40);
            }
        }

        public void pauseMovement()
        {
            this.moveThread.Suspend();
        }

        public void resumeMovement()
        {
            this.moveThread.Resume();
        }

        private bool collidesWithEnvCircles()
        {
            lock (env.otherCircles)
            {
                foreach (Circle circle in env.otherCircles)
                {
                    if (circle.id == this.id)
                        continue;
                    else
                    {
                        double oDist = Math.Sqrt(Math.Pow((x - circle.x), 2.0d) + Math.Pow((y - circle.y), 2.0d));
                        if (oDist < (rad + circle.rad))
                            return true;
                    }
                }
            }
            return false;
        }

        private void changeXDirection()
        {
            dirX *= -1;
        }

        private void changeYDirection()
        {
            dirY *= -1;
        }

    }

    public class ForceVector
    {
        public double dirX { get; set; }
        public double dirY { get; set; }
    }

    public class CircleConstructParams
    {
        public double x { get; set; }
        public double y { get; set; }
        public double dirX { get; set; }
        public double dirY { get; set; }
        public int speed { get; set; }
        public int rad { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Threading_Demo
{
    public class CircleEnvironment
    {
        public Rectangle envSize { get; set; }
        public List<Circle> otherCircles { get; set; }
    }
}

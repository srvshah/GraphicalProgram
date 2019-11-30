using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgram
{
    public class Line : IShape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int toX { get; set; }
        public int toY { get; set; }

        public void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black);
            g.DrawLine(p ,X, Y, toX, toY);
            p.Dispose();
        }

        public void set(params int[] list)
        {
            X = list[0];
            Y = list[1];
            toX = list[2];
            toY = list[3];
        }
    }
}

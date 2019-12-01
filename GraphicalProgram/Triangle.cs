using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgram
{
    public class Triangle : IShape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point[] point = new Point[3];

        /// <summary>
        /// draws Triangle
        /// </summary>
        /// <param name="g"></param>
        public void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black);
            g.DrawPolygon(p, point);
            p.Dispose();
        }

        /// <summary>
        /// sets the parameter 
        /// </summary>
        /// <param name="list"></param>
        public void set(params int[] list)
        {
            X = list[0];
            Y = list[1];
            point[0].X = X;
            point[0].Y = Y + list[2];
            point[1].X = X + list[3];
            point[1].Y = Y;
            point[2].X = X + list[3];
            point[2].Y = Y + list[4];
            
        }
    }
}

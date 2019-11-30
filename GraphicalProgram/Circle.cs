using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgram
{
    public class Circle : IShape
    {
        public int Radius { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        
        

        public void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black);
            g.DrawEllipse(p, X, Y, Radius * 2, Radius * 2);
            p.Dispose();
        }

        public void set(params int[] list)
        {
            X = list[0];
            Y = list[1];
            Radius = list[2];
        }

     
    }
}

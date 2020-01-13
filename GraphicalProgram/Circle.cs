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
        
        /// <summary>
        /// takes Graphics object and draws and ellipse with provided parameters
        /// </summary>
        /// <param name="g"></param>
        public void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black);
            g.DrawEllipse(p, X, Y, Radius * 2, Radius * 2);
            p.Dispose();
        }

        /// <summary>
        /// takes integer array as argument, sets the provided arguments to the variables
        /// </summary>
        /// <param name="list"></param>
        public void set(int x, int y, params int[] list)
        {
            X = x;
            Y = y;
            Radius = list[0];
        }

     
    }
}

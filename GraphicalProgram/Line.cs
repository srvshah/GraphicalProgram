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
        #region Singleton
        private Line() { }

        private static Line instance;

        public static Line Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Line();
                }
                return instance;
            }
        }
        #endregion

        public int X { get; set; }
        public int Y { get; set; }
        public int toX { get; set; }
        public int toY { get; set; }

        /// <summary>
        /// Draws an Ellipse
        /// </summary>
        /// <param name="g"></param>
        public void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black);
            g.DrawLine(p ,X, Y, toX, toY);
            p.Dispose();
        }

        /// <summary>
        /// sets the parameter
        /// </summary>
        /// <param name="list"></param>
        public void set(int x, int y, params int[] list)
        {
            X = x;
            Y = y;
            toX = list[0];
            toY = list[1];
        }
    }
}

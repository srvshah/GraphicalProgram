using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgram
{
    public class Polygon : IShape
    {
        #region Singleton
        private Polygon() { }

        private static Polygon instance;

        public static Polygon Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Polygon();
                }
                return instance;
            }
        }
        #endregion

        public int X { get; set; }
        public int Y { get; set; }
        public List<Point> points = new List<Point>();

        /// <summary>
        /// Draws rectangle
        /// </summary>
        /// <param name="g"></param>
        public void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black);


            Point[] ps = new Point[] { new Point(30, 50), new Point(120, 200), new Point(60,300) };


            g.DrawPolygon(p, points.ToArray());
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

            for (int i = 0; i < list.Length; i++)
            {
                int a = list[i];
                int b = list[i];

                if (i % 2 == 0)
                {
                    a *= 2;
                    b *= 3;
                }
                else
                {
                    a *= 3;
                    b *= 2;
                }
               
                points.Add(new Point(a, b));
            }

        }

    }
}

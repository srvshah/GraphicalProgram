﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgram
{
    public class Rectangle : IShape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        /// <summary>
        /// Draws rectangle
        /// </summary>
        /// <param name="g"></param>
        public void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black);
            g.DrawRectangle(p, X, Y, Width, Height);
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
            Width = list[0];
            Height = list[1];
        }
    }
}

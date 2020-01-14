using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgram
{
    /// <summary>
    /// Interface inherited by all types of shapes
    /// </summary>
    interface IShape
    {
        void draw(Graphics g);
        void set(int x, int y, params int[] list);
    }
}

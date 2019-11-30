using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgram
{
    interface IShape
    {
        void draw(Graphics g);
        void set(params int[] list);
    }
}

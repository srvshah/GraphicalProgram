using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicalProgram.Tests
{
    [TestClass()]
    public class TriangleTests
    {
        Triangle t = new Triangle();
        
        [TestMethod()]
        public void setTest()
        {

            //arrange            
            int X = 50;
            int Y = 60;
            
            Point[] point = new Point[3];
            point[0].X = X;
            point[0].Y = Y + 70;
            point[1].X = X + 80;
            point[1].Y = Y;
            point[2].X = X + 80;
            point[2].Y = Y + 90;

            //act
            t.set(50, 60, 70, 80, 90);

            //assert
            Assert.AreEqual(t.X, X);
            Assert.AreEqual(t.Y, Y);

            for(int i=0; i < point.Length; i++)
            {
                Assert.AreEqual(t.point[i], point[i]);
            }

        }
    }
}
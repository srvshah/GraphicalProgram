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
    public class PolygonTests
    {
        /// <summary>
        /// checks whether the values assigned reflect on the actual value of instance
        /// </summary>
        [TestMethod()]
        public void setTest()
        {
            //arrange
            Polygon p = Polygon.Instance;
            int givenX = 3;
            int givenY = 4;
            int[]  givenArr = new[] { 1, 2, 3 };

            //act
            p.set(givenX, givenY, givenArr);

            //assert
            Assert.AreEqual(givenX, p.X);
            Assert.AreEqual(givenY, p.Y);
            Assert.AreEqual(new Point(2,3), p.points.First());  // x = 1*2, y = 1*3
            
        }
    }
}
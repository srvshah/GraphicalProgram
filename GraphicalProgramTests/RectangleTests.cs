using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgram.Tests
{
    [TestClass()]
    public class RectangleTests
    {
        Rectangle r = new Rectangle();
        [TestMethod()]
        public void setTest()
        {
            //arrange            
            int expectedX = 50;
            int expectedY = 60;
            int expectedWidth = 70;
            int expectedHeight = 80;

            //act
            r.set(50, 60, 70,80);

            //assert
            Assert.AreEqual(expectedX, r.X);
            Assert.AreEqual(expectedY, r.Y);
            Assert.AreEqual(expectedWidth, r.Width);
            Assert.AreEqual(expectedHeight, r.Height);
        }
    }
}
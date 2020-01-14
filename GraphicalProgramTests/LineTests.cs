using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgram.Tests
{
    /// <summary>
    /// Tests the Line Class
    /// </summary>
    [TestClass()]
    public class LineTests
    {
        Line ln = Line.Instance;

        /// <summary>
        /// Tests whether the value passed to the set method sets the variables to the given value
        /// </summary>
        [TestMethod()]
        public void setTest()
        {
            //arrange            
            int expectedX = 50;
            int expectedY = 60;
            int expectedtoX = 70;
            int expectedtoY = 80;

            //act
            ln.set(50, 60, 70, 80);

            //assert
            Assert.AreEqual(expectedX, ln.X);
            Assert.AreEqual(expectedY, ln.Y);
            Assert.AreEqual(expectedtoX, ln.toX);
            Assert.AreEqual(expectedtoY, ln.toY);
        }
    }
}
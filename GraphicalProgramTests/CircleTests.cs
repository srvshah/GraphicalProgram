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
    /// Tests the Circle Class
    /// </summary>
    [TestClass()]
    public class CircleTests
    {
        Circle c = new Circle();

        /// <summary>
        /// Tests whether the value passed to the set method sets the variables to the given value
        /// </summary>
        [TestMethod()]
        public void setTest()
        {
            //arrange            
            int X = 50;
            int Y = 60;
            int Radius = 70;

            //act
            c.set(50, 60, 70);

            //assert
            Assert.AreEqual(c.X, X);
            Assert.AreEqual(c.Y, Y);
            Assert.AreEqual(c.Radius, Radius);


        }
    }
}
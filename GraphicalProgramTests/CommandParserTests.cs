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
    public class CommandParserTests
    {
        CommandParser cp = new CommandParser();
        Form1 form = new Form1();

        [TestMethod()]
        public void validateCommandTest()
        {
            //arrange
            string[] userInputs = { "moveto 50,50", "circle 50", "drawto 50,50", "rectangle 100,50", "triangle 50,80,90" };
            bool expected = true;

            //act
            foreach (var input in userInputs)
            {
                bool actual = cp.validateCommand(input, out string error);

                //assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void executeCommandTest()
        {
            //arrange
            cp.validateCommand("moveto 50,60", out _);
            int expectedX = 50;
            int expectedY = 60;

            //act
            cp.executeCommand(form.g);

            //assert
            Assert.AreEqual(expectedX, cp.X);
            Assert.AreEqual(expectedY, cp.Y);
        }

        [TestMethod()]
        public void resetPenTest()
        {
            //arrange
            cp.moveTo(50, 50);
            Point expected = new Point(0, 0);

            //act
            Point actual = cp.resetPen();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void moveToTest()
        {
            //arrange
            int x = 20; int y = 50;

            //act
            cp.moveTo(x, y);
            int expectedX = cp.X;
            int expectedY = cp.Y;

            //assert
            Assert.AreEqual(expectedX, x);
            Assert.AreEqual(expectedY, y);
        }

     
    }
}
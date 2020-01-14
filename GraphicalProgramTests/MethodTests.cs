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
    public class MethodTests
    {
        /// <summary>
        /// checks whether the method constructors are working properly
        /// </summary>
        [TestMethod()]
        public void MethodTest()
        {
            //arrange
            List<string> commands = new List<string>() { "circle 90", "drawto 4,4"};
            string name = "test()";
            
            //act
            Method m = new Method(name, commands);

            //assert
            Assert.AreEqual("test()", m.Name);
            Assert.AreEqual("circle 90", m.Commands.First());
            Assert.AreEqual("drawto 4,4", m.Commands.Last());
        }

    }
}
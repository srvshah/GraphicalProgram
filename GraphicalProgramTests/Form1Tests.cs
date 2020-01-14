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
    public class Form1Tests
    {
        Form1 form = new Form1();
        CommandParser cp = CommandParser.Instance;

       
        /// <summary>
        /// Checks whether a method definition can be created or not
        /// </summary>
        [TestMethod()]
        public void DefineMethodTest()
        {
            //arrange
            string[] sample = new[] { "method my()", "circle 23", "endmethod" };
            
            //act
            foreach (var cmd in sample)
            {
                bool status = form.DefineMethod(cmd);
                //assert
                Assert.IsTrue(status);
            }
        }

        /// <summary>
        /// Checks whether the a command can be processed or not, returns null if it can be processed
        /// and error if it cannot be processed
        /// </summary>
        [TestMethod()]
        public void processCommandsTest()
        {
            // arrange , act
            string status = form.processCommands("circle 90");

            //assert
            Assert.AreEqual(null, status);
        }
    }
}
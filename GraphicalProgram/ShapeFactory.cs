using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgram
{
    class ShapeFactory
    {
        /// <summary>
        /// returns an object of Shape type according to user input
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns>Shape Object</returns>
        public IShape getShape(String shapeType)
        {
            // for case insensitivity
            shapeType = shapeType.ToUpper().Trim();

            if (shapeType.Equals("LINE"))
            {
                return new Line();
            }
            else if (shapeType.Equals("CIRCLE"))
            {
                return new Circle();

            }
            else if (shapeType.Equals("RECTANGLE"))
            {
                return new Rectangle();

            }       
            else if (shapeType.Equals("TRIANGLE"))
            {
                return new Triangle();
            }        
            else if (shapeType.Equals("POLYGON"))
            {
                return new Polygon();
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgram
{
    class ShapeFactory
    {
        public IShape getShape(String shapeType)
        {
            shapeType = shapeType.ToUpper().Trim();

            if(shapeType == null)
            {
                return null;
            }
            else if (shapeType.Equals("LINE"))
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
            return null;

            //else
            //{

            //    //If this is reached then what has been passed is not recognised. A user friendly exception was thrown.
            //    System.ArgumentException argEx = new System.ArgumentException("Shape Factory error: " + shapeType + " does not exist");
            //    throw argEx;
            //}
        }
    }
}

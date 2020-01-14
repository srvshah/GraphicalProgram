using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgram
{
    class ShapeFactory
    {
        #region Singleton
        private ShapeFactory() { }

        private static ShapeFactory instance;

        public static ShapeFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ShapeFactory();
                }
                return instance;
            }
        }
        #endregion

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
                return Line.Instance;
            }
            else if (shapeType.Equals("CIRCLE"))
            {
                return Circle.Instance;

            }
            else if (shapeType.Equals("RECTANGLE"))
            {
                return Rectangle.Instance;

            }       
            else if (shapeType.Equals("TRIANGLE"))
            {
                return Triangle.Instance;
            }        
            else if (shapeType.Equals("POLYGON"))
            {
                return Polygon.Instance;
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgram
{
    public class CommandParser
    {
        ShapeFactory sf = new ShapeFactory();
        private string[] validCommands = { "circle", "rectangle", "triangle", "moveto", "drawto","radius"};
        private string command;
        private string[] parameters;

        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// takes a string, checks if it is a valid command
        /// </summary>
        /// <param name="userInput"></param>
        /// <param name="message"></param>
        /// <returns>returns a boolean value, and message as output parameter</returns>
        public bool validateCommand(string userInput, out string message)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                message = "Command field is empty!";
                return false;
            }

            string[] input = userInput.Trim().ToLower().Split(' ');

            // should support 
            //if (input.Length != 2)
            //{
            //    message = "Invalid syntax. Use this: \"command <params>\" where parameters are separated by comma. Only Single spaced commands are supported currently";
            //    return false;
            //}

            command = input[0];

            if (!validCommands.Contains(command))
            {
                message = "No such command available";
                return false;
            }

            else if (command.Equals("moveto") || command.Equals("drawto") || command.Equals("rectangle"))
            {

                if (!CheckInputLength(input,2))
                {
                    message = $"{command} takes exactly 2 inputs on the same line";
                    return false;
                }

                parameters = input[1].Split(',');

                if (parameters.Length != 2)
                {
                    message = $"{command} takes 2 parameters";
                    return false;
                }

                else
                {
                    if (!validParameters())
                    {
                        message = $"Invalid parameter. Use this format: \"{command} x,x\" where x is an integer";
                        return false;
                    }

                }
            }

            else if (command.Equals("triangle"))
            {

                if (!CheckInputLength(input, 2))
                {
                    message = $"{command} takes exactly 2 inputs on the same line";
                    return false;
                }

                parameters = input[1].Split(',');

                if (parameters.Length != 3)
                {
                    message = $"{command} takes 3 parameters";
                    return false;
                }

                else
                {
                    if (!validParameters())
                    {
                        message = $"Invalid parameter. Use this format: \"{command} x,x,x\" where x is an integer";
                        return false;
                    }

                }
            }

            else if (command.Equals("circle"))
            {
                if (!CheckInputLength(input, 2))
                {
                    message = $"{command} takes exactly 2 inputs on the same line";
                    return false;
                }

                parameters = input[1].Split(',');

                if (parameters.Length != 1)
                {
                    message = $"{command} takes 1 parameter";
                    return false;
                }

                else
                {
                    if (!validParameters())
                    {
                        message = $"Invalid parameter. Use this format: \"{command} x\" where x is an integer";
                        return false;
                    }

                }
            }
            else if (command.Equals("radius"))
            {
                if (!CheckInputLength(input, 3))
                {
                    message = $"{command} takes exactly 3 inputs on the same line";
                    return false;
                }

                if(!input[1].Equals("="))
                {
                    message = "Invalid Syntax";
                    return false;
                }

                parameters = input[2].Split(',');

                if (parameters.Length != 1)
                {
                    message = $"{command} takes 1 assignment";
                    return false;
                }

                else
                {
                    if (!validParameters())
                    {
                        message = $"Invalid parameter. Use this format: \"{command} x\" where x is an integer";
                        return false;
                    }

                }
            }

            message = null;
            return true;
        }

        /// <summary>
        /// iterates through parameters array and checks if they are integers
        /// </summary>
        /// <returns>boolean</returns>
        private bool validParameters()
        {
            foreach (var p in parameters)
            {
                if (!Int32.TryParse(p, out _))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// executes what is stored in the command variable using the parameters stored in parameters array
        /// </summary>
        /// <param name="g"></param>
        /// <returns>co-ordinate of the current pen position as a Point</returns>
        public Point executeCommand(Graphics g)
        {
            Pen p = new Pen(Color.Black);
            int[] paramArr = parameters.Select(int.Parse).ToArray();

            switch (command)
            {

                case "moveto":
                    moveTo(paramArr[0], paramArr[1]);
                    break;

                case "drawto":
                    IShape line = sf.getShape("line");
                    line.set(X, Y, paramArr[0], paramArr[1]);
                    line.draw(g);
                    X = paramArr[0];
                    Y = paramArr[1];
                    break;

                case "circle":
                    IShape circle = sf.getShape("circle");
                    circle.set(X, Y, paramArr[0]);
                    circle.draw(g);
                    break;

                case "rectangle":
                    IShape rect = sf.getShape("rectangle");
                    rect.set(X, Y, paramArr[0], paramArr[1]);
                    rect.draw(g);
                    X += paramArr[0];
                    Y += paramArr[1];
                    break;

                case "triangle":
                    IShape triangle = sf.getShape("triangle");
                    triangle.set(X, Y, paramArr[0], paramArr[1], paramArr[2]);
                    triangle.draw(g);
                    break;
                case "radius":
                    int radius = paramArr[0];
                    break;

            }
            p.Dispose();
            return new Point(X, Y);
        }

        /// <summary>
        /// resets the Pen co-ordinates to (0,0)
        /// </summary>
        /// <returns>value of X and Y as a Point</returns>
        public Point resetPen()
        {
            return new Point(X = 0, Y = 0);
        }

        public bool CheckInputLength(string[] arr, int requiredLength)
        {
            return arr.Length == requiredLength;
        }

        public void moveTo(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

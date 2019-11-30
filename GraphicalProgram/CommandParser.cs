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
        private string[] validCommands = { "circle", "rectangle", "triangle", "moveto", "drawto" };
        private string command;
        private string[] parameters;

        public int X { get; set; }
        public int Y { get; set; }


        public bool validateCommand(string userInput, out string message)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                message = "Command field is empty!";
                return false;
            }

            string[] input = userInput.Trim().ToLower().Split(' ');

            if (input.Length != 2)
            {
                message = "Invalid syntax. Use this: \"command <params>\" where parameters are separated by comma. Only Single spaced commands are supported currently";
                return false;
            }

            command = input[0];
            parameters = input[1].Split(',');

            if (!validCommands.Contains(command))
            {
                message = "No such command available";
                return false;
            }

            else if (command.Equals("moveto") || command.Equals("drawto") || command.Equals("rectangle"))
            {
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

            message = null;
            return true;
        }


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

            }
            p.Dispose();
            return new Point(X, Y);
        }

        public Point resetPen()
        {
            X = 0;
            Y = 0;
            return new Point(X, Y);
        }

        public void moveTo(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

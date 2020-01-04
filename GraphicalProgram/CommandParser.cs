using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicalProgram
{
    public class CommandParser
    {
        ShapeFactory sf = new ShapeFactory();
        private string[] validCommands = 
        { 
            "circle", 
            "rectangle", 
            "triangle", 
            "moveto", 
            "drawto", 
            "radius",
            "width",
            "height",
            "var",
            "if",
            "loop",
        };  
        private string command;
        private string[] input;
        private string[] parameters;
        private Dictionary<string, int> variables = new Dictionary<string, int>();
        private string variableKey;
        private string[] comparisonOperators = { "=", ">", "<", ">=", "<=" };
        private string myOperator;

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

            command = userInput.Trim().ToLower().Split(' ')[0];

            if (!validCommands.Contains(command))
            {
                message = "No such command available";
                return false;
            }

            else if (command.Equals("moveto") || command.Equals("drawto") || command.Equals("rectangle"))
            {
                input = userInput.Trim().ToLower().Split(' ');

                if (!CheckInputLength(input, 2))
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
                    if (!validateInteger())
                    {

                        if (!MapVariablesToParameters(out string error))
                        {
                            message = error;
                            return false;
                        }
                        //message = $"Invalid parameter. Use this format: \"{command} x,x\" where x is an integer";
                        //return false;
                    }

                }
            }

            else if (command.Equals("triangle"))
            {
                input = userInput.Trim().ToLower().Split(' ');
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
                    if (!validateInteger())
                    {
                        message = $"Invalid parameter. Use this format: \"{command} x,x,x\" where x is an integer";
                        return false;
                    }

                }
            }

            else if (command.Equals("circle"))
            {
                input = userInput.Trim().ToLower().Split(' ');
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
                    if (!validateInteger())  // check if the parameters are integers
                    {
                        // if not interger then try to look for their values in the variables list
                        if (!MapVariablesToParameters(out string error))
                        {
                            message = error;
                            return false;
                        }
                        //message = $"Invalid parameter. Use this format: \"{command} x\" where x is an integer";
                        //return false;
                    }
                }
            }

            else if (command.Equals("var"))
            {
                input = userInput.Trim().ToLower().Split(' ');
                if (!CheckInputLength(input, 4))
                {
                    message = $"{command} takes exactly 4 inputs on the same line";
                    return false;
                }

                if (!input[2].Equals("="))
                {
                    message = "Invalid Syntax: User '=' operator to assign a variable";
                    return false;
                }

                parameters = input[3].Split(',');

                if (parameters.Length != 1)
                {
                    message = $"{command} takes 1 assignment";
                    return false;
                }

                else
                {
                    if (!validateInteger())
                    {
                        message = $"Invalid parameter. Use this format: \"{command} x\" where x is an integer";
                        return false;
                    }

                }
                variableKey = input[1];
            }

            else if (command.Equals("if"))
            {
                
                string condition = "false";

                var conditionString = userInput.Trim().ToLower().Split(' ');

                if (conditionString.Length != 2 && conditionString.Length != 4)
                {
                    message = "if condition has errors.";
                    return false;
                }
               

                if (conditionString[1].Equals("true")) condition = "true";                 
                else if (conditionString[1].Equals("false")) condition = "false";
                else
                {
                    if(conditionString.Length == 2)
                    {
                        message = "Error on if statement. The condition can only be true, false or a comparison";
                        return false;
                    }
                    
                    parameters = new string[] { conditionString[1], conditionString[3] };
                    

                    myOperator = conditionString[2];
                    if (!comparisonOperators.Contains(myOperator))
                    {
                        message = "Error: Invalid Operator";
                        return false;
                    }
                    
                         
                    if (!validateInteger())
                    {
                        if (!MapVariablesToParameters(out string error))
                        {
                            message = error;
                            return false;
                        }
                    }


                    switch (myOperator)
                    {
                        case "=":
                            condition = int.Parse(parameters[0]) == int.Parse(parameters[1]) ? "true" : "false";
                            break;
                        case "<":
                            condition = int.Parse(parameters[0]) < int.Parse(parameters[1]) ? "true" : "false";
                            break;
                        case ">":
                            condition = int.Parse(parameters[0]) > int.Parse(parameters[1]) ? "true" : "false";
                            break;
                        case "<=":
                            condition = int.Parse(parameters[0]) <= int.Parse(parameters[1]) ? "true" : "false";
                            break;
                        case ">=":
                            condition = int.Parse(parameters[0]) >= int.Parse(parameters[1]) ? "true" : "false";
                            break;
                    }

                }
                message = condition;
                return true;

               
            }
            else if (command.Equals("loop"))
            {

                var input = userInput.Trim().ToLower().Split(' ');

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


                if (!validateInteger()) 
                {
                    if (!MapVariablesToParameters(out string error))
                    {
                        message = error;
                        return false;
                    }
                }

                message = parameters[0];
                return true;
                //bool isInt = int.TryParse(cmd.Split(' ')[1], out counter);

                //if (!isInt)
                //{

                //    Console.WriteLine("requires integer value");


                //}
                //else
                //{
                //    insideLoop = true;
                //}

            }



            message = null;
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
            //int[] paramArr = parameters.Select(x => { int.TryParse(x, out int i); return i; }).ToArray();
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
                case "var":
                    // if it exists on the list
                    if (variables.ContainsKey(variableKey))
                    {
                        // replace it
                        variables[variableKey] = paramArr[0];
                    }
                    // if not
                    else
                    {
                        // add it
                        variables.Add(variableKey, paramArr[0]);
                    }
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

        public void moveTo(int x, int y)
        {
            X = x;
            Y = y;
        }


        /// <summary>
        /// iterates through parameters array and checks if they are integers
        /// </summary>
        /// <returns>boolean</returns>
        private bool validateInteger()
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

        public bool CheckInputLength(string[] arr, int requiredLength)
        {
            return arr.Length == requiredLength;
        }

        private bool MapVariablesToParameters(out string message)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                if (int.TryParse(parameters[i], out int isInt))
                {
                    parameters[i] = isInt.ToString();
                }
                else if (variables.ContainsKey(parameters[i]))
                {
                    parameters[i] = variables[parameters[i]].ToString();
                }
                else
                {
                    message = $"{parameters[i]} is not defined";
                    return false;
                }
            }
            message = null;
            return true;
        }

    }
}

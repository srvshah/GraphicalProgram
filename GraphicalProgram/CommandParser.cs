using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicalProgram
{
    /// <summary>
    /// Takes the given command checks its validity and executes commands
    /// </summary>
    public class CommandParser
    {
        #region Singleton
        private CommandParser() { }

        private static CommandParser instance;

        public static CommandParser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommandParser();
                }
                return instance;
            }
        }
        #endregion

        #region Instance Variables
        public string[] validCommands = 
        { 
            "circle", 
            "rectangle", 
            "triangle",
            "polygon",
            "moveto", 
            "drawto",
            "var",
            "if",
            "endif",
            "endloop",
            "endmethod",
            "loop",
            "method" ,
            "then"
        };  
        private string command;
        private string[] input;
        private string[] parameters;
        private string variableKey;
        private string[] comparisonOperators = { "=", ">", "<", ">=", "<=" };
        private string[] operationOperators = { "+", "-", "*", "/" };
        private string myOperator;

        public Dictionary<string, int> variables = new Dictionary<string, int>();
        public List<Method> DefinedMethods = new List<Method>();
        public int X { get; set; }
        public int Y { get; set; }
        #endregion

        /// <summary>
        /// takes a string, checks if it is a valid command
        /// </summary>
        /// <param name="userInput"></param>
        /// <param name="message"></param>
        /// <returns>returns a boolean value, and message as output parameter</returns>
        public bool validateCommand(string userInput, out string message)
        {

            command = userInput.Trim().ToLower().Split(' ')[0];

            if (!validCommands.Contains(command) && !variables.ContainsKey(command))
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
                        if (!MapVariablesToParameters(out string error))
                        {
                            message = error;
                            return false;
                        }
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

            else if (command.Equals("polygon"))
            {
                input = userInput.Trim().ToLower().Split(' ');
                if (!CheckInputLength(input, 2))
                {
                    message = $"{command} takes exactly 2 inputs on the same line";
                    return false;
                }

                parameters = input[1].Split(',');

                if (parameters.Length < 3)
                {
                    message = $"{command} takes minimum 3 parameters";
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
                    if (!variables.ContainsKey(parameters[0]))
                    {
                        message = $"{parameters[0]} is not defined";
                        return false;
                    }
                }

                message = parameters[0];
                return true;

            }

            else if (variables.ContainsKey(command))
            {
                string[] input = userInput.Trim().ToLower().Split(' ');
                if(!CheckInputLength(input, 3))
                {
                    message = "variable operation takes three inputs i.e variable, operator, operand";
                    return false;
                }
                string variable = input[0];
                string myOperator = input[1]; 
                string myOperand = input[2]; 
                if(!myOperator.Equals("=") && !operationOperators.Contains(myOperator))
                {
                    message = "invalid operator";
                    return false;
                }

                if(!int.TryParse(myOperand, out int _))
                {
                    message = "variable operation requires an integer";
                    return false;
                }

                parameters = new string[] { variable, myOperator, myOperand };

            }

            else if (command.Contains("method"))
            {
                string[] input = userInput.Trim().ToLower().Split(' ');
                if (!CheckInputLength(input, 2))
                {
                    message = "Method definition takes two inputs i.e keyword, methodName(<parameters>)";
                    return false;
                }

                var mName = input[1].Replace(")", null).Split('(')[0];
                var parms = input[1].Replace(")", null).Split('(')[1].Split(',');

                if(parms.Distinct().Count() != parms.Count())
                {
                    message = "method parameters must be unique";
                    return false;
                }

                if (string.IsNullOrEmpty(mName))
                {
                    message = "method name required";
                    return false;
                }

                if(DefinedMethods.Find(x=>x.Name.StartsWith(mName)) != null)
                {
                    message = $"The method with the name {mName} is already defined";
                    return false;
                }


                if (int.TryParse(mName, out _))
                {
                    message = "method name must be a string";
                    return false;
                }

                if(parms != null && parms.Length != 0)
                {
                    foreach (var p in parms)
                    {
                        if (int.TryParse(p, out _))
                        {
                            message = "method parameter must be a string";
                            return false;
                        }
                    }
                }
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
            if (parameters == null || parameters.Length == 0) return new Point(X,Y);

            if (variables.ContainsKey(parameters[0]))
            {
                string variable = parameters[0];
                string myOperator = parameters[1];
                string myOperand = parameters[2];

                switch (myOperator)
                {
                    case "=":
                        variables[variable] = int.Parse(myOperand);
                        break;                                    
                    case "-":
                        variables[variable] -= int.Parse(myOperand);
                        break;                                    
                    case "+":
                        variables[variable] += int.Parse(myOperand);
                        break;                                    
                    case "*":
                        variables[variable] *= int.Parse(myOperand);
                        break;                                    
                    case "/":
                        variables[variable] /= int.Parse(myOperand);
                        break;
                }
            }
            else
            {
                Pen p = new Pen(Color.Black);
                int[] paramArr = parameters.Select(int.Parse).ToArray();
                switch (command)
                {
                    case "moveto":
                        moveTo(paramArr[0], paramArr[1]);
                        break;

                    case "drawto":
                        IShape line = ShapeFactory.Instance.getShape("line");
                        line.set(X, Y, paramArr);
                        line.draw(g);
                        X = paramArr[0];
                        Y = paramArr[1];
                        break;

                    case "circle":
                        IShape circle = ShapeFactory.Instance.getShape("circle");
                        circle.set(X, Y, paramArr);
                        circle.draw(g);
                        break;

                    case "rectangle":
                        IShape rect = ShapeFactory.Instance.getShape("rectangle");
                        rect.set(X, Y, paramArr);
                        rect.draw(g);
                        X += paramArr[0];
                        Y += paramArr[1];
                        break;

                    case "triangle":
                        IShape triangle = ShapeFactory.Instance.getShape("triangle");
                        triangle.set(X, Y, paramArr);
                        triangle.draw(g);
                        break;

                    case "polygon":
                        IShape polygon = ShapeFactory.Instance.getShape("polygon");
                        polygon.set(X, Y, paramArr);
                        polygon.draw(g);
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
            }
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

        /// <summary>
        /// compares the length of the given array with the required length of array
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="requiredLength"></param>
        /// <returns></returns>
        public bool CheckInputLength(string[] arr, int requiredLength)
        {
            return arr.Length == requiredLength;
        }

        /// <summary>
        /// if parameters array contain a string that has a value in variable dictionary, it is 
        /// swapped with that value
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
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

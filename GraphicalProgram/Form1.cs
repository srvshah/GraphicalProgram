using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicalProgram
{
    public partial class Form1 : Form
    {
        public Graphics g { get; }
        CommandParser cp = new CommandParser();
        public Point penPosition = new Point(0, 0);
        bool processingIf = false;
        bool processingLoop = false;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            txtPenPosition.Text = penPosition.ToString();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCommand.Text))
            {
                rtxtLogs.Text = "Command field is empty!";
                return;
            }

            string error = processCommands(txtCommand.Text);

            if (!string.IsNullOrEmpty(error))
            {
                rtxtLogs.Text = error;
            }
            else
            {
                rtxtLogs.Text = string.Empty;
            }
            txtPenPosition.Text = penPosition.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCommand.Clear();
            txtMultiCommand.Clear();
            rtxtLogs.Clear();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            List<string> MultiCommands = new List<string>();
            

            foreach (var command in txtMultiCommand.Lines)
            {
                if (!string.IsNullOrEmpty(command))
                {
                    MultiCommands.Add(command);
                }
            }
            
            int lineCount = MultiCommands.Count();

            if (lineCount == 0)
            {
                rtxtLogs.Text = "Nothing to execute";
                return;
            }

           
            for (int i = 0; i < lineCount; i++)
            {
                string cmd = MultiCommands[i];


                if(cmd.Split(' ')[0].Equals("if") || processingIf)
                {
                    if(!processIfCommands(cmd)) break;
                }
                else if(cmd.Split(' ')[0].Equals("loop") || processingLoop)
                {
                    if (!processLoopCommands(cmd)) break;
                }
                else
                {
                    string error = processCommands(cmd);

                    if (!string.IsNullOrEmpty(error))
                    {
                        rtxtLogs.Text = $"Error at  Line {i + 1} \n {error}";
                        break;
                    }
                    else
                    {
                        rtxtLogs.Text = string.Empty;
                    }
                }

                                                                                                   
            }
            txtPenPosition.Text = penPosition.ToString();
        }

        private void btnClearCanvas_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            penPosition = cp.resetPen();
            txtPenPosition.Text = penPosition.ToString();
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sf = new SaveFileDialog()
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            })
            {
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    using (Stream s = File.Open(sf.FileName, FileMode.CreateNew))
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        sw.Write(txtMultiCommand.Text);
                    }
                }
            }
           
            
            
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                // add open file dialog filter
                if (of.ShowDialog() == DialogResult.OK)
                {
                    var fileName = of.FileName;
                    var fileContent = File.ReadAllText(fileName);
                    txtMultiCommand.Text = fileContent;
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult dialog = MessageBox.Show("Do you want to close?", "Alert!", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A Graphical Programming Application which allows a user to draw shapes using programming language concepts including encapsulation, conditionals and iteration. \n\n Copyright (c) 2019. All rights Reserved. \n\n Saurab Bikram Shah");
        }


        public string processCommands(string input)
        {
            if (cp.validateCommand(input, out string error))
            {
                penPosition = cp.executeCommand(g);
                return null;
            }

            return error;
        }

        string condition = string.Empty;
        private bool processIfCommands(string cmd)
        {
            if (cmd.StartsWith("if"))
            {
                processingIf = true;
                if (!cp.validateCommand(cmd, out condition))
                {
                    rtxtLogs.Text = $"Error {condition}";
                    return false;
                }

            }
            else if (cmd.StartsWith("end"))
            {
                processingIf = false;
            }

            else 
            {

                if (condition.Equals("true"))
                {
                    string error = processCommands(cmd);

                    if (!string.IsNullOrEmpty(error))
                    {
                        rtxtLogs.Text = $"Error  {error}";
                        return false;
                    }
                    else
                    {
                        rtxtLogs.Text = string.Empty;
                    }
                }
            }
            return true;
            
        }


        private bool processLoopCommands(string cmd)
        {
            processingLoop = true;


            return true;
        }

    }
}

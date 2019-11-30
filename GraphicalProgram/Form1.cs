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
        Point penPosition = new Point(0, 0);

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            txtPenPosition.Text = penPosition.ToString();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string error = processCommands(txtCommand.Text);

            if (!string.IsNullOrEmpty(error))
            {
                rtxtLogs.Text = error;
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
            int lineCount = txtMultiCommand.Lines.Count();

            if (lineCount == 0)
            {
                //MessageBox.Show("Nothing to execute");
                rtxtLogs.Text = "Nothing to execute";
            }

            for (int i = 0; i < lineCount; i++)
            {
                string error = processCommands(txtMultiCommand.Lines[i]);

                if (!string.IsNullOrEmpty(error))
                {
                    //MessageBox.Show($"Error at  Line {i + 1} \n {error}");
                    rtxtLogs.Text = $"Error at  Line {i + 1} \n {error}";
                    break;
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


        private string processCommands(string input)
        {
            if (cp.validateCommand(input, out string error))
            {
                penPosition = cp.executeCommand(g);
                return null;
            }

            return error;
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
    }
}

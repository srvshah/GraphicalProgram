namespace GraphicalProgram
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtPenPosition = new System.Windows.Forms.TextBox();
            this.btnClearCanvas = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMultiCommand = new System.Windows.Forms.RichTextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtxtLogs = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(396, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 490);
            this.panel1.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1037, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(823, 579);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(199, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtPenPosition
            // 
            this.txtPenPosition.Location = new System.Drawing.Point(692, 579);
            this.txtPenPosition.Name = "txtPenPosition";
            this.txtPenPosition.ReadOnly = true;
            this.txtPenPosition.Size = new System.Drawing.Size(100, 20);
            this.txtPenPosition.TabIndex = 8;
            // 
            // btnClearCanvas
            // 
            this.btnClearCanvas.Location = new System.Drawing.Point(396, 579);
            this.btnClearCanvas.Name = "btnClearCanvas";
            this.btnClearCanvas.Size = new System.Drawing.Size(201, 23);
            this.btnClearCanvas.TabIndex = 9;
            this.btnClearCanvas.Text = "Clear Canvas";
            this.btnClearCanvas.UseVisualStyleBackColor = true;
            this.btnClearCanvas.Click += new System.EventHandler(this.btnClearCanvas_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(620, 582);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Pen Position";
            // 
            // txtMultiCommand
            // 
            this.txtMultiCommand.Font = new System.Drawing.Font("Fira Mono", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMultiCommand.Location = new System.Drawing.Point(12, 69);
            this.txtMultiCommand.Name = "txtMultiCommand";
            this.txtMultiCommand.Size = new System.Drawing.Size(358, 286);
            this.txtMultiCommand.TabIndex = 11;
            this.txtMultiCommand.Text = "";
            this.txtMultiCommand.TextChanged += new System.EventHandler(this.txtMultiCommand_TextChanged);
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(12, 375);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(358, 23);
            this.btnExecute.TabIndex = 1;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 404);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(358, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtCommand
            // 
            this.txtCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommand.Location = new System.Drawing.Point(462, 30);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(479, 22);
            this.txtCommand.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(393, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Command";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(947, 29);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 442);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Error Logs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Multi Line Command";
            // 
            // rtxtLogs
            // 
            this.rtxtLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtLogs.ForeColor = System.Drawing.Color.Red;
            this.rtxtLogs.Location = new System.Drawing.Point(12, 458);
            this.rtxtLogs.Name = "rtxtLogs";
            this.rtxtLogs.Size = new System.Drawing.Size(358, 144);
            this.rtxtLogs.TabIndex = 0;
            this.rtxtLogs.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1037, 629);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPenPosition);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtxtLogs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMultiCommand);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClearCanvas);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Graphical Program";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtPenPosition;
        private System.Windows.Forms.Button btnClearCanvas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.RichTextBox txtMultiCommand;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtxtLogs;
    }
}


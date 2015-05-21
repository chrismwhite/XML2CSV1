namespace XMLElementsToCSV
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnChooseRoot = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnChooseOutput = new System.Windows.Forms.Button();
            this.txtChooseOutput = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.numWriteEvery = new System.Windows.Forms.NumericUpDown();
            this.lblWriteOutput = new System.Windows.Forms.Label();
            this.lblInputFiles = new System.Windows.Forms.Label();
            this.pbOverallProgress = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.txtChooseRoot = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.numWriteEvery)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChooseRoot
            // 
            this.btnChooseRoot.Location = new System.Drawing.Point(15, 22);
            this.btnChooseRoot.Name = "btnChooseRoot";
            this.btnChooseRoot.Size = new System.Drawing.Size(119, 36);
            this.btnChooseRoot.TabIndex = 1;
            this.btnChooseRoot.Text = "Choose root directory of XML Files:";
            this.btnChooseRoot.UseVisualStyleBackColor = true;
            this.btnChooseRoot.Click += new System.EventHandler(this.btnChooseRoot_Click);
            // 
            // btnChooseOutput
            // 
            this.btnChooseOutput.Location = new System.Drawing.Point(15, 78);
            this.btnChooseOutput.Name = "btnChooseOutput";
            this.btnChooseOutput.Size = new System.Drawing.Size(119, 23);
            this.btnChooseOutput.TabIndex = 2;
            this.btnChooseOutput.Text = "Choose output file";
            this.btnChooseOutput.UseVisualStyleBackColor = true;
            this.btnChooseOutput.Click += new System.EventHandler(this.btnChooseOutput_Click);
            // 
            // txtChooseOutput
            // 
            this.txtChooseOutput.BackColor = System.Drawing.SystemColors.Control;
            this.txtChooseOutput.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtChooseOutput.Location = new System.Drawing.Point(144, 80);
            this.txtChooseOutput.Name = "txtChooseOutput";
            this.txtChooseOutput.ReadOnly = true;
            this.txtChooseOutput.Size = new System.Drawing.Size(152, 20);
            this.txtChooseOutput.TabIndex = 3;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(125, 233);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // numWriteEvery
            // 
            this.numWriteEvery.Location = new System.Drawing.Point(144, 136);
            this.numWriteEvery.Name = "numWriteEvery";
            this.numWriteEvery.Size = new System.Drawing.Size(120, 20);
            this.numWriteEvery.TabIndex = 5;
            // 
            // lblWriteOutput
            // 
            this.lblWriteOutput.AutoSize = true;
            this.lblWriteOutput.Location = new System.Drawing.Point(12, 138);
            this.lblWriteOutput.Name = "lblWriteOutput";
            this.lblWriteOutput.Size = new System.Drawing.Size(122, 13);
            this.lblWriteOutput.TabIndex = 6;
            this.lblWriteOutput.Text = "Write to output file every";
            // 
            // lblInputFiles
            // 
            this.lblInputFiles.AutoSize = true;
            this.lblInputFiles.Location = new System.Drawing.Point(270, 138);
            this.lblInputFiles.Name = "lblInputFiles";
            this.lblInputFiles.Size = new System.Drawing.Size(51, 13);
            this.lblInputFiles.TabIndex = 7;
            this.lblInputFiles.Text = "input files";
            // 
            // pbOverallProgress
            // 
            this.pbOverallProgress.Location = new System.Drawing.Point(-1, 284);
            this.pbOverallProgress.Name = "pbOverallProgress";
            this.pbOverallProgress.Size = new System.Drawing.Size(343, 23);
            this.pbOverallProgress.TabIndex = 8;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(74, 268);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(51, 13);
            this.lblProgress.TabIndex = 9;
            this.lblProgress.Text = "Progress:";
            // 
            // txtChooseRoot
            // 
            this.txtChooseRoot.Location = new System.Drawing.Point(144, 31);
            this.txtChooseRoot.Name = "txtChooseRoot";
            this.txtChooseRoot.ReadOnly = true;
            this.txtChooseRoot.Size = new System.Drawing.Size(152, 20);
            this.txtChooseRoot.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 303);
            this.Controls.Add(this.txtChooseRoot);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.pbOverallProgress);
            this.Controls.Add(this.lblInputFiles);
            this.Controls.Add(this.lblWriteOutput);
            this.Controls.Add(this.numWriteEvery);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtChooseOutput);
            this.Controls.Add(this.btnChooseOutput);
            this.Controls.Add(this.btnChooseRoot);
            this.Name = "Form1";
            this.Text = "Convert XML Elements to CSV";
            ((System.ComponentModel.ISupportInitialize)(this.numWriteEvery)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnChooseRoot;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnChooseOutput;
        private System.Windows.Forms.TextBox txtChooseOutput;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.NumericUpDown numWriteEvery;
        private System.Windows.Forms.Label lblWriteOutput;
        private System.Windows.Forms.Label lblInputFiles;
        private System.Windows.Forms.ProgressBar pbOverallProgress;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.TextBox txtChooseRoot;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}


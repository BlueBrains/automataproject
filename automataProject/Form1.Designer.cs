﻿namespace automataProject
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Specification = new System.Windows.Forms.TextBox();
            this.fromTextBox = new System.Windows.Forms.RadioButton();
            this.fromFile = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Read Specification";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(338, 221);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Circuit Correctness";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(338, 250);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(127, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Draw Automata";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(338, 279);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(127, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Calculate Resistances";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Specification
            // 
            this.Specification.Location = new System.Drawing.Point(26, 34);
            this.Specification.Multiline = true;
            this.Specification.Name = "Specification";
            this.Specification.Size = new System.Drawing.Size(218, 111);
            this.Specification.TabIndex = 4;
            // 
            // fromTextBox
            // 
            this.fromTextBox.AutoSize = true;
            this.fromTextBox.Location = new System.Drawing.Point(6, 103);
            this.fromTextBox.Name = "fromTextBox";
            this.fromTextBox.Size = new System.Drawing.Size(113, 17);
            this.fromTextBox.TabIndex = 5;
            this.fromTextBox.TabStop = true;
            this.fromTextBox.Text = "read from textBox";
            this.fromTextBox.UseVisualStyleBackColor = true;
            // 
            // fromFile
            // 
            this.fromFile.AutoSize = true;
            this.fromFile.Checked = true;
            this.fromFile.Location = new System.Drawing.Point(6, 80);
            this.fromFile.Name = "fromFile";
            this.fromFile.Size = new System.Drawing.Size(92, 17);
            this.fromFile.TabIndex = 6;
            this.fromFile.TabStop = true;
            this.fromFile.Text = "Read from file";
            this.fromFile.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.fromTextBox);
            this.groupBox1.Controls.Add(this.fromFile);
            this.groupBox1.Location = new System.Drawing.Point(332, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 138);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Read Options";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 326);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Specification);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.Text = "Automata Project";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox Specification;
        private System.Windows.Forms.RadioButton fromTextBox;
        private System.Windows.Forms.RadioButton fromFile;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

namespace SimilarZ
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richTextBox1 = new RichTextBox();
            openFileDialog1 = new OpenFileDialog();
            richTextBox2 = new RichTextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            progressBar1 = new ProgressBar();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(26, 43);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(392, 287);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "TXT files|*.txt";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(449, 43);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(392, 287);
            richTextBox2.TabIndex = 1;
            richTextBox2.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(26, 336);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Load";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(449, 336);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Load";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(26, 365);
            button3.Name = "button3";
            button3.Size = new Size(815, 23);
            button3.TabIndex = 4;
            button3.Text = "Check";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(89, 410);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(701, 23);
            progressBar1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(803, 415);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 6;
            label1.Text = "0.00%";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 414);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 7;
            label2.Text = "SImilarity";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 25);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 8;
            label3.Text = "Content";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(449, 25);
            label4.Name = "label4";
            label4.Size = new Size(79, 15);
            label4.TabIndex = 9;
            label4.Text = "To check with";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(progressBar1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "SimilarZ Version 1.0.0";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private OpenFileDialog openFileDialog1;
        private RichTextBox richTextBox2;
        private Button button1;
        private Button button2;
        private Button button3;
        private ProgressBar progressBar1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}

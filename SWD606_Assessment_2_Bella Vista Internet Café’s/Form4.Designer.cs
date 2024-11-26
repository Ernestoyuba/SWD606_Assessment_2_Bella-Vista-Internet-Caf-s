namespace SWD606_Assessment_2_Bella_Vista_Internet_Café_s
{
    partial class Form4
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
            label1 = new Label();
            button3 = new Button();
            button2 = new Button();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            button1 = new Button();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(310, 57);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 0;
            label1.Click += label1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(397, 381);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 18;
            button3.Text = "Exit";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(154, 381);
            button2.Name = "button2";
            button2.Size = new Size(174, 34);
            button2.TabIndex = 17;
            button2.Text = "Back to Shopping";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(217, 245);
            label3.Name = "label3";
            label3.Size = new Size(50, 25);
            label3.TabIndex = 16;
            label3.Text = "CVV ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(134, 189);
            label2.Name = "label2";
            label2.Size = new Size(198, 25);
            label2.TabIndex = 15;
            label2.Text = "MM/DD/YY Expire Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(191, 125);
            label4.Name = "label4";
            label4.Size = new Size(119, 25);
            label4.TabIndex = 14;
            label4.Text = "Card Number";
            // 
            // button1
            // 
            button1.Location = new Point(310, 318);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 13;
            button1.Text = "Pay Now";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(454, 239);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(53, 31);
            textBox3.TabIndex = 12;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(395, 183);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(199, 31);
            textBox2.TabIndex = 11;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(397, 119);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(270, 31);
            textBox1.TabIndex = 10;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form4";
            Text = "Form4";
            Load += Form4_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button3;
        private Button button2;
        private Label label3;
        private Label label2;
        private Label label4;
        private Button button1;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}
namespace Lab6
{
    partial class AddTeam
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
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            numericUpDown1 = new NumericUpDown();
            textBox2 = new TextBox();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label6 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(95, 118);
            label1.Name = "label1";
            label1.Size = new Size(98, 25);
            label1.TabIndex = 0;
            label1.Text = "Denumirea";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(242, 169);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(281, 31);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(95, 175);
            label2.Name = "label2";
            label2.Size = new Size(132, 25);
            label2.TabIndex = 0;
            label2.Text = "Nume antrenor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(95, 236);
            label3.Name = "label3";
            label3.Size = new Size(140, 25);
            label3.TabIndex = 0;
            label3.Text = "Anul de fondare";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(95, 292);
            label4.Name = "label4";
            label4.Size = new Size(44, 25);
            label4.TabIndex = 0;
            label4.Text = "Liga";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(95, 341);
            label5.Name = "label5";
            label5.Size = new Size(72, 25);
            label5.TabIndex = 0;
            label5.Text = "Stadion";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(242, 230);
            numericUpDown1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(281, 31);
            numericUpDown1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(242, 112);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(281, 31);
            textBox2.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(242, 284);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(281, 33);
            comboBox1.TabIndex = 3;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(242, 333);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(281, 33);
            comboBox2.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(139, 48);
            label6.Name = "label6";
            label6.Size = new Size(321, 32);
            label6.TabIndex = 0;
            label6.Text = "Introdu datele despre echipă";
            // 
            // button1
            // 
            button1.Location = new Point(411, 388);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 5;
            button1.Text = "Adaugă";
            button1.UseVisualStyleBackColor = true;
            // 
            // AddTeam
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(619, 463);
            Controls.Add(button1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label6);
            Controls.Add(label1);
            Name = "AddTeam";
            Text = "AddTeam";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private NumericUpDown numericUpDown1;
        private TextBox textBox2;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label6;
        private Button button1;
    }
}
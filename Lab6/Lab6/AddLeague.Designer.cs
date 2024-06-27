namespace Lab6
{
    partial class AddLeague
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
            textBox2 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 126);
            label1.Name = "label1";
            label1.Size = new Size(98, 25);
            label1.TabIndex = 0;
            label1.Text = "Denumirea";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(174, 120);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(297, 31);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 177);
            label2.Name = "label2";
            label2.Size = new Size(45, 25);
            label2.TabIndex = 2;
            label2.Text = "Țara";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(174, 171);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(297, 31);
            textBox2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 229);
            label3.Name = "label3";
            label3.Size = new Size(114, 25);
            label3.TabIndex = 2;
            label3.Text = "Data de start";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 287);
            label4.Name = "label4";
            label4.Size = new Size(126, 25);
            label4.TabIndex = 2;
            label4.Text = "Data de sfârșit";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(97, 44);
            label5.Name = "label5";
            label5.Size = new Size(270, 32);
            label5.TabIndex = 0;
            label5.Text = "Introdu date despre ligă";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(174, 229);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(297, 31);
            dateTimePicker1.TabIndex = 3;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(174, 281);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(297, 31);
            dateTimePicker2.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(359, 355);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 4;
            button1.Text = "Adaugă";
            button1.UseVisualStyleBackColor = true;
            // 
            // AddLeague
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 439);
            Controls.Add(button1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label1);
            Name = "AddLeague";
            Text = "AddLeague";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Button button1;
    }
}
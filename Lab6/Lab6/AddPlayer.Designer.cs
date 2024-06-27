namespace Lab6.Models
{
    partial class AddPlayer
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
            dateTimePicker1 = new DateTimePicker();
            label5 = new Label();
            button1 = new Button();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(156, 34);
            label1.Name = "label1";
            label1.Size = new Size(285, 32);
            label1.TabIndex = 0;
            label1.Text = "Introdu datele jucătorului";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(173, 97);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(300, 31);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 157);
            label2.Name = "label2";
            label2.Size = new Size(63, 25);
            label2.TabIndex = 2;
            label2.Text = "Poziția";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(173, 154);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(300, 31);
            textBox2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 203);
            label3.Name = "label3";
            label3.Size = new Size(113, 25);
            label3.TabIndex = 2;
            label3.Text = "Data Nașterii";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 103);
            label4.Name = "label4";
            label4.Size = new Size(73, 25);
            label4.TabIndex = 2;
            label4.Text = "Numele";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(173, 203);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(300, 31);
            dateTimePicker1.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(40, 257);
            label5.Name = "label5";
            label5.Size = new Size(63, 25);
            label5.TabIndex = 5;
            label5.Text = "Echipa";
            // 
            // button1
            // 
            button1.Location = new Point(361, 311);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 6;
            button1.Text = "Adaugă";
            button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(173, 254);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(300, 33);
            comboBox1.TabIndex = 7;
            // 
            // AddPlayer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 409);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(dateTimePicker1);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "AddPlayer";
            Text = "AddPlayer";
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
        private DateTimePicker dateTimePicker1;
        private Label label5;
        private Button button1;
        private ComboBox comboBox1;
    }
}
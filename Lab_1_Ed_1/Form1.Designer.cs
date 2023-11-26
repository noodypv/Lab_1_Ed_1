namespace Lab_1_Ed_1
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
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button3 = new Button();
            label6 = new Label();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(1398, 97);
            textBox1.MaxLength = 2;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(217, 68);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1383, 46);
            label1.Name = "label1";
            label1.Size = new Size(253, 32);
            label1.TabIndex = 1;
            label1.Text = "Процессорное время";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1211, 89);
            button1.Name = "button1";
            button1.Size = new Size(166, 81);
            button1.TabIndex = 2;
            button1.Text = "Добавить процесс";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1211, 190);
            button2.Name = "button2";
            button2.Size = new Size(404, 76);
            button2.TabIndex = 3;
            button2.Text = "Сбросить процессы";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(13, 15);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.RowTemplate.Height = 41;
            dataGridView1.Size = new Size(1170, 609);
            dataGridView1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1211, 315);
            label2.Name = "label2";
            label2.Size = new Size(303, 32);
            label2.TabIndex = 5;
            label2.Text = "Среднее время ожидания";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1515, 315);
            label3.Name = "label3";
            label3.Size = new Size(0, 32);
            label3.TabIndex = 6;
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1211, 369);
            label4.Name = "label4";
            label4.Size = new Size(330, 32);
            label4.TabIndex = 7;
            label4.Text = "Среднее время выполнения";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1581, 369);
            label5.Name = "label5";
            label5.Size = new Size(0, 32);
            label5.TabIndex = 8;
            label5.Click += label5_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1211, 431);
            button3.Name = "button3";
            button3.Size = new Size(404, 71);
            button3.TabIndex = 9;
            button3.Text = "Вычислить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1211, 535);
            label6.Name = "label6";
            label6.Size = new Size(125, 32);
            label6.TabIndex = 10;
            label6.Text = "Алгоритм:";
            label6.Click += label6_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1357, 537);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(242, 40);
            comboBox1.TabIndex = 11;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1648, 650);
            Controls.Add(comboBox1);
            Controls.Add(label6);
            Controls.Add(button3);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Button button2;
        private DataGridView dataGridView1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button3;
        private Label label6;
        private ComboBox comboBox1;
    }
}
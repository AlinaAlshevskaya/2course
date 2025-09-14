namespace lab1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Button();
            this.TypeOfValue = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Value1 = new System.Windows.Forms.TextBox();
            this.SizeOfvalue1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SizeOfvalue2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Calculate = new System.Windows.Forms.Button();
            this.Resalt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 1;
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(671, 402);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 2;
            this.Exit.Text = "exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.button1_Click);
            // 
            // TypeOfValue
            // 
            this.TypeOfValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeOfValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TypeOfValue.ForeColor = System.Drawing.Color.Black;
            this.TypeOfValue.FormattingEnabled = true;
            this.TypeOfValue.Items.AddRange(new object[] {
            "Weight",
            "Lenght",
            "Square",
            "Volume",
            "Speed",
            "Time",
            "Temperature"});
            this.TypeOfValue.Location = new System.Drawing.Point(436, 36);
            this.TypeOfValue.Name = "TypeOfValue";
            this.TypeOfValue.Size = new System.Drawing.Size(310, 33);
            this.TypeOfValue.TabIndex = 4;
            this.TypeOfValue.SelectedIndexChanged += new System.EventHandler(this.TypeOfValue_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(29, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(328, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Выберете велечину для перевода";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(29, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Исходная велечина";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Value1
            // 
            this.Value1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Value1.Location = new System.Drawing.Point(275, 222);
            this.Value1.Name = "Value1";
            this.Value1.Size = new System.Drawing.Size(471, 30);
            this.Value1.TabIndex = 7;
            this.Value1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // SizeOfvalue1
            // 
            this.SizeOfvalue1.Location = new System.Drawing.Point(104, 136);
            this.SizeOfvalue1.Name = "SizeOfvalue1";
            this.SizeOfvalue1.Size = new System.Drawing.Size(185, 24);
            this.SizeOfvalue1.TabIndex = 4;
            this.SizeOfvalue1.SelectedIndexChanged += new System.EventHandler(this.SizeOfvalue1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 3;
            // 
            // SizeOfvalue2
            // 
            this.SizeOfvalue2.Location = new System.Drawing.Point(519, 136);
            this.SizeOfvalue2.Name = "SizeOfvalue2";
            this.SizeOfvalue2.Size = new System.Drawing.Size(177, 24);
            this.SizeOfvalue2.TabIndex = 1;
            this.SizeOfvalue2.SelectedIndexChanged += new System.EventHandler(this.Sizeofvalue2_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(476, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(40, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(304, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Ед. измерения исходной величины";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(475, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(257, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Ед. измерения для перевода";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(395, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "-->";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(29, 294);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 25);
            this.label10.TabIndex = 11;
            this.label10.Text = "Результат";
            // 
            // Calculate
            // 
            this.Calculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Calculate.Location = new System.Drawing.Point(196, 356);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(334, 68);
            this.Calculate.TabIndex = 12;
            this.Calculate.Text = "Посчитать";
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // Resalt
            // 
            this.Resalt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Resalt.Location = new System.Drawing.Point(275, 282);
            this.Resalt.Name = "Resalt";
            this.Resalt.Size = new System.Drawing.Size(470, 30);
            this.Resalt.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Resalt);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SizeOfvalue2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SizeOfvalue1);
            this.Controls.Add(this.Value1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TypeOfValue);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.ComboBox TypeOfValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Value1;
        private System.Windows.Forms.ComboBox SizeOfvalue1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox SizeOfvalue2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.TextBox Resalt;
    }
}


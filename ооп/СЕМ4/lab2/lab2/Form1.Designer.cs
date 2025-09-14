namespace lab2
{
    partial class Student
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
            System.Windows.Forms.Label Lastname;
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.Firstname = new System.Windows.Forms.Label();
            this.FistnameTextbox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.Name = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            Lastname = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lastname
            // 
            Lastname.AutoSize = true;
            Lastname.Location = new System.Drawing.Point(15, 170);
            Lastname.Name = "Lastname";
            Lastname.Size = new System.Drawing.Size(70, 16);
            Lastname.TabIndex = 4;
            Lastname.Text = "Отчество";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(14, 201);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(272, 22);
            this.textBox3.TabIndex = 5;
            // 
            // Firstname
            // 
            this.Firstname.AutoSize = true;
            this.Firstname.Location = new System.Drawing.Point(15, 24);
            this.Firstname.Name = "Firstname";
            this.Firstname.Size = new System.Drawing.Size(66, 16);
            this.Firstname.TabIndex = 0;
            this.Firstname.Text = "Фамилия";
            // 
            // FistnameTextbox
            // 
            this.FistnameTextbox.Location = new System.Drawing.Point(14, 55);
            this.FistnameTextbox.Name = "FistnameTextbox";
            this.FistnameTextbox.Size = new System.Drawing.Size(272, 22);
            this.FistnameTextbox.TabIndex = 1;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(14, 126);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(272, 22);
            this.NameTextBox.TabIndex = 3;
            // 
            // Name
            // 
            this.Name.AutoSize = true;
            this.Name.Location = new System.Drawing.Point(15, 95);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(33, 16);
            this.Name.TabIndex = 2;
            this.Name.Text = "Имя";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 29;
            this.listBox1.Items.AddRange(new object[] {
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40"});
            this.listBox1.Location = new System.Drawing.Point(226, 254);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(60, 33);
            this.listBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Возраст";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(18, 324);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(192, 20);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Программная инженерия";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(18, 350);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(293, 20);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Информационные системы и технология";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(18, 376);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(147, 20);
            this.radioButton3.TabIndex = 10;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Цифровой дизайн";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Выберите специальность";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(119, 422);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 12;
            // 
            // Student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 665);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(Lastname);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.Name);
            this.Controls.Add(this.FistnameTextbox);
            this.Controls.Add(this.Firstname);
            this.Name = "Student";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Firstname;
        private System.Windows.Forms.TextBox FistnameTextbox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label Name;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}


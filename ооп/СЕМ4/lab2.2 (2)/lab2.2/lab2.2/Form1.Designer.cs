namespace lab2._2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.FIOtext = new System.Windows.Forms.TextBox();
            this.Age = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Birthday = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.Course = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Speciality = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.AvarageScore = new System.Windows.Forms.TextBox();
            this.GenderM = new System.Windows.Forms.RadioButton();
            this.GenderF = new System.Windows.Forms.RadioButton();
            this.Group = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Adres = new System.Windows.Forms.TextBox();
            this.Work = new System.Windows.Forms.Button();
            this.WorkInf = new System.Windows.Forms.RichTextBox();
            this.AddStudent = new System.Windows.Forms.Button();
            this.VisiableAge = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.сохраниитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сортировкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поГруппеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поКурсуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поВозрастуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Age)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FIOtext
            // 
            this.FIOtext.Location = new System.Drawing.Point(92, 96);
            this.FIOtext.Name = "FIOtext";
            this.FIOtext.Size = new System.Drawing.Size(333, 22);
            this.FIOtext.TabIndex = 1;
            this.FIOtext.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Age
            // 
            this.Age.Location = new System.Drawing.Point(549, 96);
            this.Age.Maximum = 40;
            this.Age.Minimum = 16;
            this.Age.Name = "Age";
            this.Age.Size = new System.Drawing.Size(333, 56);
            this.Age.TabIndex = 2;
            this.Age.Value = 16;
            this.Age.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(474, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Возраст";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(421, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Группа";
            // 
            // Birthday
            // 
            this.Birthday.Location = new System.Drawing.Point(125, 212);
            this.Birthday.Name = "Birthday";
            this.Birthday.Size = new System.Drawing.Size(300, 22);
            this.Birthday.TabIndex = 8;
            this.Birthday.ValueChanged += new System.EventHandler(this.Birthday_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Дата рождения";
            // 
            // Course
            // 
            this.Course.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Course.FormattingEnabled = true;
            this.Course.ItemHeight = 36;
            this.Course.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.Course.Location = new System.Drawing.Point(321, 155);
            this.Course.Name = "Course";
            this.Course.Size = new System.Drawing.Size(44, 40);
            this.Course.TabIndex = 10;
            this.Course.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(327, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Курс";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Speciality
            // 
            this.Speciality.CheckOnClick = true;
            this.Speciality.FormattingEnabled = true;
            this.Speciality.Items.AddRange(new object[] {
            "ПИ",
            "ИСиТ",
            "ЦД"});
            this.Speciality.Location = new System.Drawing.Point(170, 140);
            this.Speciality.Name = "Speciality";
            this.Speciality.Size = new System.Drawing.Size(109, 55);
            this.Speciality.TabIndex = 12;
            this.Speciality.SelectedIndexChanged += new System.EventHandler(this.Speciality_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Специальность";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Средний балл";
            // 
            // AvarageScore
            // 
            this.AvarageScore.Location = new System.Drawing.Point(125, 250);
            this.AvarageScore.Name = "AvarageScore";
            this.AvarageScore.Size = new System.Drawing.Size(73, 22);
            this.AvarageScore.TabIndex = 15;
            this.AvarageScore.TextChanged += new System.EventHandler(this.AvarageScore_TextChanged);
            // 
            // GenderM
            // 
            this.GenderM.AutoSize = true;
            this.GenderM.Checked = true;
            this.GenderM.Location = new System.Drawing.Point(776, 215);
            this.GenderM.Name = "GenderM";
            this.GenderM.Size = new System.Drawing.Size(86, 20);
            this.GenderM.TabIndex = 16;
            this.GenderM.TabStop = true;
            this.GenderM.Text = "Мужской";
            this.GenderM.UseVisualStyleBackColor = true;
            this.GenderM.CheckedChanged += new System.EventHandler(this.GenderM_CheckedChanged);
            // 
            // GenderF
            // 
            this.GenderF.AutoSize = true;
            this.GenderF.Location = new System.Drawing.Point(775, 249);
            this.GenderF.Name = "GenderF";
            this.GenderF.Size = new System.Drawing.Size(87, 20);
            this.GenderF.TabIndex = 17;
            this.GenderF.Text = "Женский";
            this.GenderF.UseVisualStyleBackColor = true;
            this.GenderF.CheckedChanged += new System.EventHandler(this.GenderF_CheckedChanged);
            // 
            // Group
            // 
            this.Group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Group.FormattingEnabled = true;
            this.Group.Location = new System.Drawing.Point(424, 171);
            this.Group.Name = "Group";
            this.Group.Size = new System.Drawing.Size(331, 24);
            this.Group.TabIndex = 18;
            this.Group.Tag = "";
            this.Group.SelectedIndexChanged += new System.EventHandler(this.Group_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(783, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Пол";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(251, 253);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "Адрес";
            // 
            // Adres
            // 
            this.Adres.Location = new System.Drawing.Point(351, 253);
            this.Adres.Name = "Adres";
            this.Adres.Size = new System.Drawing.Size(298, 22);
            this.Adres.TabIndex = 21;
            this.Adres.TextChanged += new System.EventHandler(this.Adres_TextChanged);
            // 
            // Work
            // 
            this.Work.Location = new System.Drawing.Point(470, 290);
            this.Work.Name = "Work";
            this.Work.Size = new System.Drawing.Size(382, 45);
            this.Work.TabIndex = 22;
            this.Work.Text = "Добавить место работы";
            this.Work.UseVisualStyleBackColor = true;
            this.Work.Click += new System.EventHandler(this.button1_Click);
            // 
            // WorkInf
            // 
            this.WorkInf.Location = new System.Drawing.Point(905, 76);
            this.WorkInf.Name = "WorkInf";
            this.WorkInf.Size = new System.Drawing.Size(538, 307);
            this.WorkInf.TabIndex = 23;
            this.WorkInf.Text = "";
            // 
            // AddStudent
            // 
            this.AddStudent.Location = new System.Drawing.Point(12, 290);
            this.AddStudent.Name = "AddStudent";
            this.AddStudent.Size = new System.Drawing.Size(382, 45);
            this.AddStudent.TabIndex = 24;
            this.AddStudent.Text = "Добавить студента";
            this.AddStudent.UseVisualStyleBackColor = true;
            this.AddStudent.Click += new System.EventHandler(this.AddStudent_Click);
            // 
            // VisiableAge
            // 
            this.VisiableAge.AutoSize = true;
            this.VisiableAge.Location = new System.Drawing.Point(474, 16);
            this.VisiableAge.Name = "VisiableAge";
            this.VisiableAge.Size = new System.Drawing.Size(0, 16);
            this.VisiableAge.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 353);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(382, 45);
            this.button1.TabIndex = 26;
            this.button1.Text = "Рассчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(470, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(381, 45);
            this.button2.TabIndex = 27;
            this.button2.Text = "Вывод информации";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ФИО";
            // 
            // сохраниитьToolStripMenuItem
            // 
            this.сохраниитьToolStripMenuItem.Name = "сохраниитьToolStripMenuItem";
            this.сохраниитьToolStripMenuItem.Size = new System.Drawing.Size(106, 26);
            this.сохраниитьToolStripMenuItem.Text = "Сохраниить";
            this.сохраниитьToolStripMenuItem.Click += new System.EventHandler(this.сохраниитьToolStripMenuItem_Click);
            // 
            // сортировкаToolStripMenuItem
            // 
            this.сортировкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поГруппеToolStripMenuItem,
            this.поКурсуToolStripMenuItem,
            this.поВозрастуToolStripMenuItem});
            this.сортировкаToolStripMenuItem.Name = "сортировкаToolStripMenuItem";
            this.сортировкаToolStripMenuItem.Size = new System.Drawing.Size(106, 26);
            this.сортировкаToolStripMenuItem.Text = "Сортировка";
            // 
            // поГруппеToolStripMenuItem
            // 
            this.поГруппеToolStripMenuItem.Name = "поГруппеToolStripMenuItem";
            this.поГруппеToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.поГруппеToolStripMenuItem.Text = "По группе";
            this.поГруппеToolStripMenuItem.Click += new System.EventHandler(this.поГруппеToolStripMenuItem_Click);
            // 
            // поКурсуToolStripMenuItem
            // 
            this.поКурсуToolStripMenuItem.Name = "поКурсуToolStripMenuItem";
            this.поКурсуToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.поКурсуToolStripMenuItem.Text = "По курсу";
            this.поКурсуToolStripMenuItem.Click += new System.EventHandler(this.поКурсуToolStripMenuItem_Click);
            // 
            // поВозрастуToolStripMenuItem
            // 
            this.поВозрастуToolStripMenuItem.Name = "поВозрастуToolStripMenuItem";
            this.поВозрастуToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.поВозрастуToolStripMenuItem.Text = "По возрасту";
            this.поВозрастуToolStripMenuItem.Click += new System.EventHandler(this.поВозрастуToolStripMenuItem_Click);
            // 
            // поискToolStripMenuItem
            // 
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(66, 26);
            this.поискToolStripMenuItem.Text = "Поиск";
            this.поискToolStripMenuItem.Click += new System.EventHandler(this.поискToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(118, 26);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохраниитьToolStripMenuItem,
            this.сортировкаToolStripMenuItem,
            this.поискToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1471, 30);
            this.menuStrip1.TabIndex = 28;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1471, 31);
            this.toolStrip1.TabIndex = 29;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(63, 28);
            this.toolStripButton1.Text = "вперед";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(53, 28);
            this.toolStripButton2.Text = "назад";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(474, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 16);
            this.label10.TabIndex = 30;
            this.label10.Text = " ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1471, 410);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.VisiableAge);
            this.Controls.Add(this.AddStudent);
            this.Controls.Add(this.WorkInf);
            this.Controls.Add(this.Work);
            this.Controls.Add(this.Adres);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Group);
            this.Controls.Add(this.GenderF);
            this.Controls.Add(this.GenderM);
            this.Controls.Add(this.AvarageScore);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Speciality);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Course);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Birthday);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Age);
            this.Controls.Add(this.FIOtext);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Age)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox FIOtext;
        private System.Windows.Forms.TrackBar Age;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker Birthday;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox Course;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox Speciality;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox AvarageScore;
        private System.Windows.Forms.RadioButton GenderM;
        private System.Windows.Forms.RadioButton GenderF;
        private System.Windows.Forms.ComboBox Group;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Adres;
        private System.Windows.Forms.Button Work;
        private System.Windows.Forms.Button AddStudent;
        private System.Windows.Forms.Label VisiableAge;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.RichTextBox WorkInf;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem сохраниитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сортировкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поГруппеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поКурсуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поВозрастуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Label label10;
    }
}


namespace lab2._2
{
    partial class Form3
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Poisk_text = new System.Windows.Forms.TextBox();
            this.Resalt = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Группа",
            "Курс",
            "Специальность",
            "ФИО"});
            this.comboBox1.Location = new System.Drawing.Point(503, 57);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(264, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Poisk_text
            // 
            this.Poisk_text.Location = new System.Drawing.Point(26, 57);
            this.Poisk_text.Name = "Poisk_text";
            this.Poisk_text.Size = new System.Drawing.Size(367, 22);
            this.Poisk_text.TabIndex = 1;
            // 
            // Resalt
            // 
            this.Resalt.Location = new System.Drawing.Point(26, 116);
            this.Resalt.Name = "Resalt";
            this.Resalt.Size = new System.Drawing.Size(741, 256);
            this.Resalt.TabIndex = 2;
            this.Resalt.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(513, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(244, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "Поиск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Resalt);
            this.Controls.Add(this.Poisk_text);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox Poisk_text;
        private System.Windows.Forms.RichTextBox Resalt;
        private System.Windows.Forms.Button button1;
    }
}
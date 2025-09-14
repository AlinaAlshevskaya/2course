using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2._2
{
    public partial class Form2: Form
    {
        public string _company;
        public string _position;
        public int _experiense;
        public double _salary;
        public string _workadres;
        public Form2()
        {
            InitializeComponent();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
           label6.Text = hScrollBar1.Value.ToString();
            _experiense = hScrollBar1.Value;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _company = textBox1.Text;
        }

       

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.Text = "Выбрана опция Удалённо";
            }
            _workadres = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            _position = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text == string.Empty) { _salary= -1; }
                else
                {
                    _salary = Convert.ToDouble(textBox4.Text);
                }
            }
            catch (Exception ex)
            {

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            try
            {
                //if (textBox1.Text == "" || textBox1.Text == "Заполните пустые поля" || textBox2.Text == "" || textBox2.Text == "Заполните пустые поля" || textBox3.Text == "" || textBox3.Text == "Заполните пустые поля" || textBox4.Text == "" || textBox4.Text == "Заполните пустые поля")
                //{ throw new Exception("Заполните пустые поля"); }

                Work work = new Work(_company, _position, _experiense, _salary, _workadres);
                var validationContext = new ValidationContext(work);
                var validationResult = new List<ValidationResult>();
                bool validated = Validator.TryValidateObject(work, validationContext, validationResult);
                if (validationResult.Count != 0)
                {
                    throw new Exception($"{validationResult[0].ErrorMessage}");
                }

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                isValid = false;
                if (textBox1.Text == "" || textBox1.Text == "Введите место работы") { textBox1.Text = ex.Message; }
                if (textBox2.Text == "" || textBox2.Text == "Введите адрес работы") { textBox2.Text = ex.Message; }
                if (textBox3.Text == "" || textBox3.Text == "Введите должность") { textBox3.Text = ex.Message; }
                if (textBox4.Text == "" || textBox4.Text == "Введите зарплату") { textBox4.Text = ex.Message; }

            }
            if (isValid)
            {
              
                Form1.instance.students[Form1.instance.counter - 1].workplace = new Work();
                Form1.instance.students[Form1.instance.counter - 1].workplace.company = _company;
                Form1.instance.students[Form1.instance.counter - 1].workplace.workadres = _workadres;
                Form1.instance.students[Form1.instance.counter - 1].workplace.position = _position;
                Form1.instance.students[Form1.instance.counter - 1].workplace.salary = _salary;
                Form1.instance.students[Form1.instance.counter - 1].workplace.experiense = _experiense;

                Form1.instance.WorkInf.Text = $"Студенту {Form1.instance.students[Form1.instance.counter - 1].FIO} добавлена работа\n";
                Form1.instance.history.Add(Form1.instance.WorkInf.Text);
                Form1.instance.state++;
                Form1.instance.actionstate++;
                this.Close();
            }
            
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.Text = "Выбрана опция Удаленно";
                _workadres = "Удаленно";
            }
            if (checkBox1.Checked==false) { _workadres = null; }
        }
    }
}

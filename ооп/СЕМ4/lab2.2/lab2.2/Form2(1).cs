using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        string _company;
        string _position;
        int _experiense;
        double _salary;
        string _workadres;
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
            Form1.instance.students[Form1.instance.counter-1].Workplace = new Work(_company, _position, _experiense, _salary, _workadres);
            Form1.instance.WorkInf.Text += $"Студенту {Form1.instance.students[Form1.instance.counter - 1].FIO} добавлена работа\n";
            this.Close();
            
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

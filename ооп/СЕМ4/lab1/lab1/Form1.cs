using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1: Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TypeOfValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                lab1.Calculator.typeOfvalue = TypeOfValue.SelectedItem.ToString();
                SizeOfvalue1.Items.Clear();
                SizeOfvalue1.Items.AddRange(lab1.Values.sizes[TypeOfValue.SelectedIndex]);
                SizeOfvalue2.Items.Clear();
                SizeOfvalue2.Items.AddRange(lab1.Values.sizes[TypeOfValue.SelectedIndex]);
                Calculator.sizeOfvalue1 = null;
                Calculator.sizeOfvalue2 = null;
                SizeOfvalue1.Text = String.Empty;
                SizeOfvalue2.Text = String.Empty;
            }
            catch (Exception ex)
            {
                Resalt.Text = ex.Message;
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Value1.Text == string.Empty) { Calculator.value1 = -1; }
                else
                {
                    Calculator.value1 = Convert.ToDouble(Value1.Text);
                }
            }
            catch(Exception ex)
            {
                Resalt.Text = ex.Message;
            }
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Sizeofvalue2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lab1.Calculator.sizeOfvalue2 = SizeOfvalue2.SelectedItem.ToString();
        }

        private void SizeOfvalue1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lab1.Calculator.sizeOfvalue1 = SizeOfvalue1.SelectedItem.ToString();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            try
            {
                lab1.Calculator.caltulate(TypeOfValue.SelectedIndex, SizeOfvalue1.SelectedIndex, SizeOfvalue2.SelectedIndex);
                Resalt.Text = Convert.ToString(Calculator.value2);

            }
            catch (Exception ex)
            {
                Resalt.Text = ex.Message;
            }
        }
    }
}

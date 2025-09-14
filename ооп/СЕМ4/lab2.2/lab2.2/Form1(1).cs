using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2._2
{
    public partial class Form1: Form
    {
        public List<Student> students = new List<Student>();
        public int counter=0;
        string _fio;
        int _age;
        string _adres;
        string _bthd;
        double _avch;
        string _spesh;
        int _course;
        int _gr;
        

        public static Form1 instance;

        public Form1()
        {
            InitializeComponent();
            instance= this;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (students.Count == 0) { WorkInf.Text = "Сначала добавте студента"; }
            else
            {
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          _fio  = FIOtext.Text;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           
            VisiableAge.Text = Convert.ToString(Age.Value);
            _age = Age.Value;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _course = Convert.ToInt32(Course.SelectedItems.ToString());
        }

        private void GenderM_CheckedChanged(object sender, EventArgs e)
        {
        
        }

        private void GenderF_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void Adres_TextChanged(object sender, EventArgs e)
        {
            _adres = Adres.Text;
           
        }

        private void Birthday_ValueChanged(object sender, EventArgs e)
        {
             _bthd = Birthday.Value.ToString();
        }

        private void AddStudent_Click(object sender, EventArgs e)
        {
            students.Add(new Student(_fio,_age, _spesh, _bthd, _course,_gr,_avch, _adres));
            if (GenderM.Checked) students[counter].Gender = "Мужской";
            if (GenderF.Checked) students[counter].Gender = "Женский";
            WorkInf.Text = WorkInf.Text + "Добавлен студент " + students[counter].FIO+"\n";
            counter++;
           
        }

        private void AvarageScore_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (AvarageScore.Text == string.Empty) { _avch = -1; }
                else
                {
                    _avch = Convert.ToDouble(AvarageScore.Text);
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void Speciality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Speciality.SelectedItem.ToString() == "ПИ")
            {
                for (int i = 0; i < Speciality.Items.Count; i++)
                {
                    if (Speciality.Items[i].ToString() != "ПИ")
                    {
                        Speciality.SetItemChecked(i, false);
                    }

                }
                Group.Text = "";
                Group.Items.Clear(); 
                string[] PIgroup = { "6", "7", "8", "9", "10" };
                Group.Items.AddRange(PIgroup);
            }
            else if (Speciality.SelectedItem.ToString() == "ИСиТ")
            {
                for (int i = 0; i < Speciality.Items.Count; i++)
                {
                    if (Speciality.Items[i].ToString() != "ИСиТ")
                    {
                        Speciality.SetItemChecked(i, false);
                    }
                }
                Group.Text = "";
                Group.Items.Clear(); 
                string[] ISITgroup = { "1", "2", "3" }; 
                Group.Items.AddRange(ISITgroup);
            }
            else if (Speciality.SelectedItem.ToString() == "ЦД")
            {
                for (int i = 0; i < Speciality.Items.Count; i++)
                {
                    if (Speciality.Items[i].ToString() != "ЦД")
                    {   
                        Speciality.SetItemChecked(i, false);
                    }
                }
                Group.Text = "";
                Group.Items.Clear(); 
                string[] CDgroup = { "4", "5" }; 
                Group.Items.AddRange(CDgroup);
            }
            _spesh = Speciality.SelectedItem.ToString();

          
        }

        private void Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Group.Text == string.Empty) { _gr = -1; }
                else
                {
                    _gr = Convert.ToInt32(Group.SelectedIndex.ToString());
                }
            }
            catch (Exception ex)
            {

            }
            
        }

        private void WorkInf_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int sum = 0;
            for( int i = 0; i < counter; i++)
            {
                if (students[i].Average >= 5 && students[i].Average < 6) { sum +=120; }
                if (students[i].Average >= 6 && students[i].Average < 7) { sum +=140; }
                if (students[i].Average >= 7 && students[i].Average <9) { sum += 165; }
                if (students[i].Average >= 9 && students[i].Average < 10) { sum += 196; }
            }
            WorkInf.Text += $"Бюджет университета = {sum}\n";

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //lab2._2.SerializerXML<Student> studentsXML = new SerializerXML<Student>($"student.xml");
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(students,options);
            File.WriteAllText("Students.json", jsonString);

            for (int i=0; i < counter; i++)
            {
                //studentsXML.path=$"student{i+1}.xml";
                //studentsXML.Serialize(students[i]);
                //Formatter.ToJsonFile<Student>(students[i]);
                //WorkInf.Text += $"\n{Formatter.serializedString}";
                WorkInf.Text += students[i].ToString();
                WorkInf.Text += $"Студент {i +1}\n";
               WorkInf.Text += students[i].ToString()+"\n";
                if (students[i].Workplace != null) { WorkInf.Text += students[i].Workplace.ToString() + "\n";  } else WorkInf.Text += "У студента нет работы\n";
               

            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace lab2._2
{
    public partial class Form1: Form
    {
        private string version = Application.ProductVersion;
        private string developer = "";
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

        public List<string> history= new List<string>();
        public int state = 0;
        public int actionstate=0;
        

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
            try
            {
                
            }
            catch(Exception ex)
            {

            }
          _fio  = FIOtext.Text;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           
            label10.Text = Convert.ToString(Age.Value);
            _age = Age.Value;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _course =Course.SelectedIndex+1;
            
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
            bool isValid = true;
            try
            {
                if (this.FIOtext.Text.ToString() == ""||this.Age.Value==0||this.Speciality.Text==null||this.Group.SelectedIndex==-1||this.Adres.Text==""||this.Birthday.Value==null||AvarageScore.Text==""||(GenderF.Checked==false && GenderM.Checked==false))
                {
                    throw new Exception("Заполние пустые поля!!!");
                }
            }
            catch(Exception ex)
            {
                isValid = false;
                this.WorkInf.Text = "";
                this.WorkInf.Text += ex.Message + '\n';
            }
            if (isValid)
            {
                students.Add(new Student(_fio, _age, _spesh, _bthd, _course, _gr, _avch, _adres));
                if (GenderM.Checked) students[counter].Gender = "Мужской";
                if (GenderF.Checked) students[counter].Gender = "Женский";
                WorkInf.Text =$"Добавлен студент {students[counter].FIO} ";
                history.Add(WorkInf.Text);
                state++;
                actionstate++;
                counter++;
            }
           
           
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
            _spesh = this.Speciality.SelectedItem.ToString();
            
        }

        private void Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            Group.Text= "Сначала выберите специальность.";
            try
            {
                if (Group.Items.Count == 0) { this.WorkInf.Text += "Сначала выберите специальность."; }
                if (Group.Text == string.Empty) { _gr = -1;this.WorkInf.Text += "Сначала выберите специальность."; }
                else
                {
                    _gr = Convert.ToInt32(Group.SelectedIndex.ToString());
                }
            }
            catch (Exception ex)
            {

            }
            
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

            WorkInf.Text = $"Бюджет университета = {sum}\n";
            history.Add(WorkInf.Text);
            state++;
            actionstate++;


        }

        private void button2_Click(object sender, EventArgs e)
        {

            //lab2._2.SerializerXML<Student> studentsXML = new SerializerXML<Student>($"student.xml");

            WorkInf.Text = "";
            for (int i=0; i < counter; i++)
            {
                //studentsXML.path=$"student{i+1}.xml";
                //studentsXML.Serialize(students[i]);
                //Formatter.ToJsonFile<Student>(students[i]);
                //WorkInf.Text += $"\n{Formatter.serializedString}";
                //WorkInf.Text += students[i].ToString();
                
                WorkInf.Text += $"Студент {i +1}\n";
               WorkInf.Text += students[i].ToString()+"\n";
                if (students[i].workplace != null) { WorkInf.Text += students[i].workplace.ToString() + "\n";  } else WorkInf.Text += "У студента нет работы\n";
               

            }
            history.Add(WorkInf.Text);
            state++;
            actionstate++;


        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
            
            
        }

        private void сохраниитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var options = new JsonSerializerOptions { Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic), WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(students, options);
            File.WriteAllText("Students.json", jsonString);

            XmlSerializer xml = new XmlSerializer(typeof(List<Student>));
            using (StreamWriter writer = new StreamWriter("students.xml"))
            {
                xml.Serialize(writer, students);
            }
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void поГруппеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WorkInf.Text = "";
            this.students.OrderBy(s => s.Group);
            foreach(var item in students)
            {
                this.WorkInf.Text += item.ToString() + '\n';
            }
            history.Add(WorkInf.Text);
            state++;
            actionstate++;

        }

        private void поКурсуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WorkInf.Text = "";
            this.students.OrderBy(s => s.Course);
            foreach (var item in students)
            {
                this.WorkInf.Text += item.ToString() + '\n';
            }
            history.Add(WorkInf.Text);
            state++;
            actionstate++;
        }

        private void поВозрастуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WorkInf.Text = "";
            this.students.OrderBy(s => s.Age);
            foreach (var item in students)
            {
                this.WorkInf.Text += item.ToString() + '\n';
            }
            history.Add(WorkInf.Text);
            state++;
            actionstate++;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            try
            {
                if (actionstate >= state) throw new Exception("Невозможно перейти вперед");
                actionstate++;
                WorkInf.Text = history[actionstate];
            }
            catch(Exception ex)
            {
                WorkInf.Text += ex.Message + "\n";
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (actionstate <=0) throw new Exception("Невозможно перейти назад");
                actionstate--;
                WorkInf.Text = history[actionstate];
            }
            catch (Exception ex)
            {
                WorkInf.Text += ex.Message + "\n";
            }
        }
    }
}

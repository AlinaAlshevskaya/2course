using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace lab2._2
{
    public partial class Form3 : Form
    {
        private Regex _fiorg = new Regex(@"^[а-яА-ЯёЁ\s]+");
        private Regex _adresrg = new Regex(@"^[А-Яа-яЁё0-9\s]{2,}$");
        private Regex _avdrg = new Regex(@"^[0-9]+\.[0-9]{1,}$");
        private Regex _courserg = new Regex(@"^[1-4]{1}");
        private Regex _speshrg = new Regex(@"^[А-Яа-яЁё]{2,}$");
        private Regex _gruprg = new Regex(@"^[0-9]{1,}$");

        public string poisk_field;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string poisktext = Poisk_text.Text;
            try
            {
                if (comboBox1.SelectedItem == null) { throw new Exception("Сначала выберите критерий для поиска.\n"); }
                if (poisk_field == "corse")
                {
                    if (_courserg.IsMatch(poisktext))
                    {

                        var filtered = Form1.instance.students.Where(s => s.Course == Convert.ToInt32(poisktext)).ToList();

                        if (filtered.Count == 0)
                        {

                            this.Resalt.Text = "Ничего не найдено!\n";
                        }
                        foreach (var item in filtered)
                        {
                            this.Resalt.Text += item.ToString() + '\n';
                        }
                    }

                    else
                    {
                        throw new Exception("Неверно введено значение\n");
                    }
                }
                else if (poisk_field == "spesh")
                {
                    if (_speshrg.IsMatch(poisktext))
                    {
                        var filtered = Form1.instance.students.Where(s => s.Speciality == poisktext).ToList();
                        if (filtered.Count == 0)
                        {

                            //this.Resalt.Text = "Ничего не найдено!\n";
                        }
                        foreach (var item in filtered)
                        {
                            this.Resalt.Text += item.ToString() + '\n';
                        }

                    }

                    else
                    {
                        throw new Exception("Неверно введено значение\n");
                    }
                }
                else if (poisk_field == "grup")
                {
                    if (_gruprg.IsMatch(poisktext))
                    {
                        var filtered = Form1.instance.students.Where(s => s.Group == Convert.ToInt32(poisktext)).ToList();
                        if (filtered.Count == 0)
                        {
                            this.Resalt.Text = "";
                            //this.Resalt.Text = "Ничего не найдено!\n";
                        }
                        foreach (var item in filtered)
                        {
                            this.Resalt.Text += item.ToString() + '\n';
                        }

                    }

                    else
                    {
                        throw new Exception("Неверно введено значение\n");
                    }
                }
                else if (poisk_field == "fio")
                {
                    
                    if (_fiorg.IsMatch(poisktext))
                    {
                        var filteredfio = Form1.instance.students.Where(s => s.FIO.Contains(poisktext)).ToList();
                        this.Resalt.Text = "Пиоск по полным данным\n";
                       
                        //if (filtered.Count == 0)
                        //{

                        //    this.Resalt.Text += "Ничего не найдено!\n";
                        //}
                       
                        foreach (var item in filteredfio)
                        {


                            this.Resalt.Text += item.ToString() + '\n';
                        }
                        //this.Resalt.Text += "Поиск по первым трём буквам фамилии\n";
                        //string firstThreeFIO = $"{poisktext[0]}{poisktext[1]}{poisktext[2]}";
                        //foreach (var item in Form1.instance.students)
                        //{
                        //    if (Regex.IsMatch(item.FIO, $"^{firstThreeFIO}"))
                        //    {

                        //        this.Resalt.Text += item.ToString();
                        //    }
                        //    //else
                        //    //{

                        //    //    this.Resalt.Text += "Ничего не найдено!\n";
                        //    //}
                        //}

                        //this.Resalt.Text += "Поиск по вервым буквам ФИО\n";
                        //string firstletersFIO = $"{poisktext[0]}";
                        //for (int i = 0; i < poisktext.Length; i++)
                        //{
                        //    if (poisktext[i] == ' ') { firstletersFIO += poisktext[i + 1]; i++; }
                        //}
                        //foreach (var item in Form1.instance.students)
                        //{
                        //    string studentsFIO = $"{item.FIO[0]}";
                        //    for (int i = 0; i < item.FIO.Length; i++)
                        //    {
                        //        if (item.FIO[i] == ' ') { studentsFIO += item.FIO[i + 1]; i++; }
                        //    }

                        //    if (Regex.IsMatch(studentsFIO, $"^{firstletersFIO}"))
                        //    {
                        //        this.Resalt.Text += item.ToString();
                        //    }
                        //    //else
                        //    //{
                        //    //    this.Resalt.Text += "Ничего не найдено!\n";
                        //    //}
                        //}

                    }

                    else
                    {
                        throw new Exception("Неверно введено значение\n");
                    }
                }
            }
            catch (Exception ex)
            {

                Resalt.Text = ex.Message + "\n";
            }
            if (this.Resalt.Text.ToString().Length == 0)
            {
                this.Resalt.Text += "Ничего не найдено!\n";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem.ToString() == "Курс") { poisk_field = "corse"; }
                else if (comboBox1.SelectedItem.ToString() == "ФИО") { poisk_field = "fio"; }
                else if (comboBox1.SelectedItem.ToString() == "Группа") { poisk_field = "grup"; }
                else if (comboBox1.SelectedItem.ToString() == "Специальность") { poisk_field = "spesh"; }
                else throw new Exception("Нету такого варианта для поиска, выберите из предложенных.");

            }
            catch (Exception ex)
            {
                this.Resalt.Text = "";
                Resalt.Text += ex.Message + "\n";
            }

        }
    }
}

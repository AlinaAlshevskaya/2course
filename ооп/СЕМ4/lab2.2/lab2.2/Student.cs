using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace lab2._2
{
    public class Student
    {
        public  string FIO;
        public  int age;
        public  string speciality;
        public  string birthday;
        public  int course;
        public  int group;
        public  double avarageB;
        public  string gender;
        public  string adres;
        public Work workplase;
        public Student(string fio,int age, string speciality, string birthday, int course, int group,double avarage, string adres) 
        {
            this.FIO = fio;
            this.age = age;
            this.speciality = speciality;
            this.birthday = birthday;
            this.course = course;
            this.group = group;
            this.avarageB = avarage;
            this.adres = adres;
        }
        public Student() { }

        public  void addworkplace()
        {

        }

        public override string ToString()
        {
            return $"ФИО: {FIO},\nВозраст:{age},\nДень Рождения: {birthday},\nКурс:{course},\nСпециальность: {speciality},\nГруппа: {group},\nСредний балл: {avarageB},\nАдрес: {adres}";
        }
    }
}

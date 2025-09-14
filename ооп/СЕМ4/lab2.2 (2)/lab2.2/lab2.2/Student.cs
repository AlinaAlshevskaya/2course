using lab2._2;
using System;
using System.ComponentModel.DataAnnotations;

[Serializable]
public class Student
{

    public string FIO { get; set; }
    public int Age { get; set; }
    public string Speciality { get; set; }
    public string Birthday { get; set; }
    public int Course { get; set; }
    public int Group { get; set; }
    public double Average { get; set; }
    public string Gender { get; set; }
    public string Address { get; set; }
    public Work workplace { get; set; }

    
    public Student(string fio, int age, string speciality, string birthday,
                  int course, int group, double average, string address)
    {
        FIO = fio;
        Age = age;
        Speciality = speciality;
        Birthday = birthday;
        Course = course;
        Group = group;
        Average = average;
        Address = address;
       
     
    }

    public Student() { }


    public override string ToString()
    {
        return $"ФИО: {FIO},\nВозраст:{Age},\nДень Рождения: {Birthday},\nКурс:{Course},\nСпециальность: {Speciality},\nГруппа: {Group},\nСредний балл: {Average},\nПол: {Gender},\nАдрес: {Address}";
    }
}
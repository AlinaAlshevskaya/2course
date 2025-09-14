using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2._2
{
   
   public class Work
    {
        [Required(ErrorMessage ="Введите название компании")]
       
        public string company { get; set; }
        [Required(ErrorMessage = "Введите должность")]
        [RegularExpression(@"[a-zA-Z]+$", ErrorMessage = "Должность должна состоять только из букв")]
        public string position { get; set; }
        [Required(ErrorMessage = "Введите опыт")]
        public  int experiense { get; set; }
        [Required(ErrorMessage = "Введите зарплату")]
        [RegularExpression("\\$?\\s?\\d{1,3}(,\\d{3})*(\\.\\d{2})?\r\n")]
        public double salary { get; set; }
        [Required(ErrorMessage = "Введите адрес")]
        public string workadres { get; set; }

        public Work(string company, string position, int experiense, double salary, string workadres)
        {
            this.company = company;
            this.position = position;
            this.experiense = experiense;
            this.salary = salary;
            this.workadres = workadres;
        }
        public Work() { }

        public override string ToString()
        {
            return $"Компания:{company},\nДолжность: {position},\nОпыт: {experiense},\nЗарплата: {salary},\nАдрес: {workadres}\n";
        }
    }
}

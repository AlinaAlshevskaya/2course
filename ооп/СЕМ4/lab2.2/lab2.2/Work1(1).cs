using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2._2
{
    [Serializable]
   public class Work
    {
        string company;
        string position;
        int experiense;
        double salary;
        string workadres;

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

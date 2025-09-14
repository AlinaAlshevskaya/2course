using Lab8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    public delegate void replace(int id);
    public class Class1
    {
        public Class1() { }
       
        public event replace? someevent;
        public void replacenew(int id)
        {
            someevent?.Invoke(id);
        }
    }
    public class Class2
    {
        public void onevenet(int id)
        {
            Console.WriteLine($"event{id}");
        }
        public Class2(Class1 class1)
        {
            class1.someevent += onevenet;
        }
    }
}

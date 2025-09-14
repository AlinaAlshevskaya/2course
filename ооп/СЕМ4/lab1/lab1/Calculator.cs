using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public static class Calculator
    {
         public static string typeOfvalue { get; set; }
        public static string sizeOfvalue1;
        public static string sizeOfvalue2;
        public static double value1;
        public static double value2;
        public static double caltulate(int index1, int index2, int index3)
        {
            if (value1 <= 0) throw new Exception("wrong value");
            if (typeOfvalue == "Speed")
            {
                value2 = value1 / lab1.Values.diff[index1][index2] * lab1.Values.diff[index1][index3];
            }
            else
            {
                value2 = value1 * lab1.Values.diff[index1][index2] / lab1.Values.diff[index1][index3];
            }
            return value2;
        }
         

       
    }
}

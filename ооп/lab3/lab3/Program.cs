using System;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace lab3
{

    interface IOperations<T>
    {
        void AddElement(T obj);
        void Remove(T obj);
        T Get(int el);
    }

    public class Array<T>:IOperations<T> where T:class
    {
        private T[] array;
        private int size;
        private int counter;
        private const int maxsize = 50;
        private Production production;
        private Developer developer;

        public Array(int size)
        {
            if (size < 0 || size > maxsize) throw new Exception("Нельзя создать массив такого размера");
            this.size = size;
            this.array = new T[size];
            counter = 0;
            production = new Production();
            developer=new Developer();
        }
        public Array(T[] array)
        {
            if (array.Length > maxsize || array.Length < 0)
            {
                throw new Exception("Слишком большой размер массива");
            }
            this.array = array;
            size = array.Length;
            counter = size;
            production = new Production();
            developer = new Developer();
        }

        public T[] GetArray { get { return array; } }
        public int Size { get { return size; } }
        public  string  DetDeveloper{get{ return developer.Dev; }}
        public string ID { get { return production.ID; } }
        public T element(int position)
        {
            return this.array[position];
        }
        public void AddElement(T value)
        {
            if (counter >= size) throw new IndexOutOfRangeException("Нельзя ввести элемент, массив переполнен");
            else this.array[counter++] = value;
        }
        public void DeleteElement(T value) { }

        public void PrintArray()
        {
            Console.Write("{ ");
            for (int i = 0; i < size; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.Write("}");

        }
        public static Array operator *(Array array1, Array array2)
        {
            if (array1.size != array2.size) throw new Exception("Массивы не одного размера, их нельзя перемножить");
            int[] result = new int[array1.size];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = array1.element(i) * array2.element(i);
            }
            return new Array(result);
        }
        public static bool operator true(Array array)
        {
            for (int i = 0; i < array.size; i++)
            {
                if (array.array[i] <= 0) return false;
            }
            return true;
        }

        public static bool operator false(Array array)
        {
            for (int i = 0; i < array.size; i++)
            {
                if (array.element(i) >= 0) return true;
            }
            return false;
        }

        public static explicit operator int(Array arr)
        {

            return arr.size;
        }

        public bool Equals(Array array2)
        {
            if (array2.size == size)
            {
                for (int i = 0; i < size; i++)
                {
                    if (array2.element(i) != array[i]) return false;
                }
                return true;

            }
            else
                return false;
        }

        public void Remove(T obj)
        {
            throw new NotImplementedException();
        }

        public T Get(int el)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Array array1, Array array2)
        {
            return (array1.Equals(array2));
        }
        public static bool operator !=(Array array1, Array array2)
        {
            return !(array1.Equals(array2));
        }

        public static bool operator >(Array array1, Array array2)
        {
            if (array1.size > array2.size) return true;
            else
            {
                if (array1.size == array2.size)
                {
                    for (int i = 0; i < array1.size; i++)
                    {
                        if(array1.element(i)>array2.element(i)) return true;
                        if(array1.element(i)<array2.element(i)) return false;
                    }
                    return false;
                }
                return false;
            }
        }
        public static bool operator <(Array array1, Array array2)
        {
            if (array1.size < array2.size) return true;
            else
            {
                if (array1.size == array2.size)
                {
                    for (int i = 0; i < array1.size; i++)
                    {
                        if (array1.element(i) < array2.element(i)) return true;
                        if (array1.element(i) > array2.element(i)) return false;
                    }
                    return false;
                }
                return false;
            }
        }
        public class Production
        {
            private string id;

            public string ID
            {
                get { return id; }
                set { id = value; }
            }

            public Production(string id="001AAM")
            {
                this.id = id;
            }
        }

        public class Developer
        {
            private string developer;
            private string id;
            private string otd;

            public string Dev
            {
                get { return developer; }
                set { developer = value; }
            }
            public string ID
            {
                get { return id; }
                set { id = value; }
            }
            public string OTD
            {
                get { return otd; }
                set { otd = value; }
            }
            public Developer(string dev="Альшевская А.М", string id="001AAM", string otd="")
            {
                developer = dev;
                ID = id;
                OTD = otd;
            }
        }



    }
    public static class StaticOperation
    {
        public static void Printarray(int[] ints)
        {
            for (int i = 0; i < ints.Length; i++)
            {
                Console.Write(ints[i] + " ");
            }
        }
        public static int Sum(Array array)
        {
            int sum = 0;
            for (int i = 0; i < array.Size; i++)
            {
                sum += array.element(i);
            }
            return sum;
        }
        public  static int Max_Min(Array array)
        {
            int max = 0;
            int min = 99999999;
            for(int i = 0;i < array.Size; i++)
            {
                if (array.element(i) < min) min = array.element(i);
                if (array.element(i) > max) max = array.element(i);
            }
            return max-min;
        }

        public static int NumberOfElement(Array array) 
        {
            int counter = 0;
            for(int i = 0; i < array.Size; i++)
            {
                counter++;
            }
            return counter;
        }
        public static bool IsLetter(this String str, char a)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == a) return true;
            }
            return false;
        }

        public static Array DeleteNegElements(this Array array)
        {
            int negcounter = 0;
            for (int i = 0; i < array.Size; i++)
            {
                if (array.element(i) < 0) negcounter++;
            }
            Array result = new Array(array.Size - negcounter);
            
            for (int i = 0; i < array.Size; i++)
            {
                if (array.element(i) >= 0)
                {
                    result.AddElement(array.element(i));
                }
            }
            return result;
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Array Arr1 = new Array(4);
            Arr1.AddElement(4);
            Arr1.AddElement(5); 
            Arr1.AddElement(6);
            Arr1.AddElement(7);
            int[] newarr = { 1, -2, 3, -4 };
            Array Arr2=new Array(newarr);
            int[] newarr2 = { 4, 5, 6, 7 };
            Array Arr3=new Array(newarr2);
            Console.Write("Arr1*Arr2= ");
            Array Arr4 = Arr1 * Arr2;
            Arr4.PrintArray();
            Console.Write("\nЕсть ли в Arr1 отпрацательные элементы?");
            if (Arr1) Console.WriteLine(" -Нет.");
            else Console.WriteLine(" -Да.");
            Console.Write("Есть ли в Arr2 отпрацательные элементы?");
            if (Arr2) Console.WriteLine(" -Нет.");
            else Console.WriteLine(" -Да.");
            if (Arr2 == Arr1) Console.WriteLine("Массивы Arr1 и Arr2 равны");
            if (Arr3 == Arr1) Console.WriteLine("Массивы Arr1 и Arr3 равны");
            if (Arr4 > Arr2) Console.WriteLine("Массив Arr4>Arr2");
            else if (Arr4 < Arr2) Console.WriteLine("Массив Arr2>Arr4");
            else Console.WriteLine("Массивы Arr2 и Arr4 равны");
            int size = (int)Arr2;
            Console.WriteLine("Размер массива Arr2 = " + size);
            string str = "Есть ли буква 'е' в строке ?";
            if (str.IsLetter('е')) Console.WriteLine(str + " - Да.");
            else Console.WriteLine(str + " - Нет.");
            Array Arr5 = Arr2.DeleteNegElements();
            Console.Write("Maссив Arr2 без отприцательных элементов = ");
            Arr5.PrintArray();







            ;


        }
    }
}
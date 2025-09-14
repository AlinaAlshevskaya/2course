using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace lab7
{
    interface IOperaruins<T>
    {
        void AddElement(T element);
        T[] DeleteElement(T element);
        T GetByID(int position);
    }
    public class Array<T> : IOperaruins<T> where T : class
    {
        private T[] array;
        private int size;
        private int counter;
        private const int maxsize = 50;
        private Production production;
        private Developer developer;

        public Array(int size)
        {
            if (size < 0 || size > maxsize) throw new IndexOutOfRangeException("Нельзя создать массив такого размера");
            this.size = size;
            this.array = new T[size];
            counter = 0;
            production = new Production();
            developer = new Developer();
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
        public string DetDeveloper { get { return developer.Dev; } }
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
        public T[] DeleteElement(T value)
        {
            int position=0;
            bool check = false;

            for (int i = 0; i < size; i++)
            {
                if (array[i] == value)
                {
                    position = i; check = true;
                    T[] newarray = new T[size - 1];
                    for (int j = 0; j < position; j++) { newarray[j] = array[j]; }
                    for (int k = position; k < size-1; k++) { newarray[k] = array[k + 1]; }
                    this.array = newarray;
                    this.size = size = size - 1;
                    return array;
                   
                } 
            }
            throw new NotValidElement("Такого элемента в массиве нет");
            
        }
        public T GetByID(int position)
        {

            for (int i = 0; i < size; i++)
            {
                if (i==position) { return array[i]; }
            }
            throw new NotValidElement("Нет такого элемента");

        }

        public void PrintArray()
        {
            Console.Write("{ \n");
            for (int i = 0; i < size; i++)
            {
                Console.Write(array[i].ToString() + "\n");
            }
            Console.Write("}\n");

        }

        public bool Equals(Array<T> array2)
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
        public static bool operator ==(Array<T> array1, Array<T> array2)
        {
            return (array1.Equals(array2));
        }
        public static bool operator !=(Array<T> array1, Array<T> array2)
        {
            return !(array1.Equals(array2));
        }

   
        
        public class Production
        {
            private string id;

            public string ID
            {
                get { return id; }
                set { id = value; }
            }

            public Production(string id = "001AAM")
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
            public Developer(string dev = "Альшевская А.М", string id = "001AAM", string otd = "")
            {
                developer = dev;
                ID = id;
                OTD = otd;
            }
        }
        public void PushToFile()
        {
            using StreamWriter sw = new("Set.json");
            var str = JsonSerializer.Serialize(array);
            sw.WriteLine(str);

        }

        public void ReadFromFile()
        {
            try
            {
                using StreamReader sr = new("Set.json");
                var str = sr.ReadToEnd();
                array = JsonSerializer.Deserialize<T[]>(str);
                this.size = array.Length;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Чтение с файла успешно!");
            }
        }



    }
    

    internal class Program
    {
        static void Main(string[] args)
        {
            Minesweerer game1 = new Minesweerer("MSG11");
            Minesweerer game3 = new Minesweerer("VFC34");
            Minesweerer game2 = new Minesweerer("yy7");
            Hangman game4 = new Hangman("FFRt6");
            Hangman game5 = new Hangman("TTR55");
            Array<Minesweerer> array1 = new Array<Minesweerer>(3);
            array1.AddElement(game1);
            array1.AddElement(game2);
            array1.AddElement(game3);
            Array<string> arraystr = new Array<string>(3);
            arraystr.AddElement("1el");
            arraystr.AddElement("2el");
            arraystr.AddElement("3el");
            Array<Hangman>array2= new Array<Hangman>([game4,game5]);
            array1.DeleteElement(game2);
            array1.PrintArray();
            array1.element(1).Execute();
            array1.PrintArray();
            arraystr.PushToFile();
            arraystr.ReadFromFile();


            try
            {
                Array<Minesweerer> arraytest = new Array<Minesweerer>(2);
                arraytest.AddElement(game1);
                arraytest.AddElement(game2);
                arraytest.AddElement(game3);
            }
            catch (IndexOutOfRangeException ex)
            {
                Exceptions.Handle(ex);
            }
            finally { Console.WriteLine("Инсключение обработано."); }






            ;


        }
    }
}
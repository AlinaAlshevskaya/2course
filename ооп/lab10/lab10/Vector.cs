using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{

    public class Vector : IEnumerable
    {
        private string name = "Vec";
        private int[] massiv;
        private int size;
        private string sostoyanie = "";
        private static int NumOfElements = 0;
        private const int maxSize = 50;
        public readonly int id;
        public int modul;
        private int feelmodul()
        {
            for (int i = 0; i < size; i++)
            {
                modul += massiv[i];
            }
            return modul;
        }
        

        List<Vector> elements;
        public void Add(Vector vec)
        {
            elements.Add(vec);
        }
        public bool HasNegative()
        {
            for (int i = 0; i < size; ++i)
            {
                if (massiv[i] <0) return true;
            }
            return false;
        }
       
        public void PrintNumandMaxsize()
        {
            Console.WriteLine(NumOfElements);
            Console.WriteLine(maxSize);
        }

        public Vector(int size = 2)
        {
            this.size = size;
            massiv = new int[size];
            id = 100 / size + size * 2;
            NumOfElements++;
            name = name + NumOfElements.ToString();
            feelmodul();

        }
        public Vector(int[] arr)
        {
            size = arr.Length;
            massiv = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                massiv[i] = arr[i];
            }
            id = 100 / size + size * 2;
            NumOfElements++;
            name = name + NumOfElements.ToString();
            feelmodul();
        }
        public Vector()
        {
            size = 5;
            int[] arr = { 0, 1, 2, 3, 4 };
            massiv = arr;
            id = 100 / size + size * 2;
            NumOfElements++;
            name = name + NumOfElements.ToString();

        }
        static Vector()
        {

        }

        private Vector(int[] massiv, int size)
        {
            this.size = size;
            this.massiv = massiv;
            NumOfElements++;
            feelmodul();
        }
        public Vector(int[] array1, int[] array2)
        {
            this.size = array1.Length+array2.Length;
            int[] array3 = new int[array1.Length + array2.Length];

            for (int i = 0; i < array1.Length; ++i)
            {
                array3[i] = array1[i];
            }
            for (int j = array1.Length; j < array1.Length + array2.Length; ++j)
            {
                array3[j] = array2[j - array1.Length];
            }
            this.massiv = array3;
            NumOfElements++;
            feelmodul();
        }
        public void PrConstr(int[] arr, int size) { new Vector(arr, size); }
        public int Size
        {
            get { return size; }
            set
            {
                if (value > maxSize)
                { sostoyanie = sostoyanie + "\nСлишком большой размер масива"; }
                else if (value < size)
                {
                    massiv = massiv.SkipLast(size - value).ToArray();
                    size = value;
                }
                else
                {
                    int[] arr = massiv;
                    massiv = new int[value];
                    for (int i = 0; i < size; i++)
                    {
                        massiv[i] = arr[i];
                    }
                    for (int i = size; i < value; i++)
                    {
                        massiv[i] = 0;
                    }
                    size = value;


                }
            }
        }
        public string Sostoyanie { get { if (sostoyanie == "") return "Ошибок нет"; else return sostoyanie; } }

        public int[] Array { get { return massiv; } set { massiv = value; } }

        public int ID { get { return id; } }
        public string Name { get { return name; } set { name = value; } }

        public void AddElemet(int position, int value) { if (position >= size) { sostoyanie = "Taкого элемента нет"; return; } massiv[position] = value; }
        public int Element(int position) { return massiv[position]; }
        public void PrintArray()
        {
            Console.WriteLine("----");
            for (int i = 0; i < size; i++)
            {
                Console.Write(massiv[i] + " ");
            }
            Console.WriteLine("\n----");
        }
        public string AllElements()
        {
            string str="{";
            for (int i = 0; i < size; i++)
            {
                str += massiv[i]+" ";
            }
            str += "}"; 
            return str;
        }
        public int Modul()
        {
             int sum = 0;
            for (int j = 0; j < size; j++)
            {
                sum += massiv[j];
            }
            return sum;
        }
        public override string ToString()
        {
            string forarr = "";
            for (int i = 0; i < size; i++)
            {
                forarr += massiv[i] + " ";
            }
            string forsost = "";

            if (sostoyanie == "") forsost = "Ошибок нет";
            else forsost = sostoyanie;
            return $"\n------------Inf-------------\nSize = {size}\nArray: {forarr}\nState : {forsost}\nID = {id}\n----------------------------";

        }
        public int Sum(int position, int number, out int sumstart)
        {
            sumstart = 0;
            sumstart = massiv[position] + number;
            return sumstart;
        }
        public int Multiply(ref int position, int number)
        {
            int product = massiv[position] * number;
            return product;
        }
        public override int GetHashCode()
        {
            return id * 8 + size * 4 / 3 * id;
        }

        public static void InfAboutClass()
        {
            Console.WriteLine($"Класс Vector:\n" +
                $"Методы: GetHashCode(), Multiply(,), Sum(,), ToString(), PrintArray(), AddElement(,), Equals(), Element()\n" +
                $"Свойсва: Size, Sostoyanie, Array, ID\n" +
                $"Количесство конструкторов: 5\n Количество обьектов на данный момент: {NumOfElements}");

        }
        public bool Equals(Vector vector)
        {
            if (size == vector.Size)

            {
                bool allelements = true;
                for (int i = 0; i < size; i++)
                {
                    if (massiv[i] != vector.Element(i)) allelements = false;
                }
                if (allelements) return true;
            }
            return false;
        }
        public bool HasZero()
        {
            for(int i = 0; i < size; ++i)
            {
                if (massiv[i] == 0) return true;
            }
            return false;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)elements).GetEnumerator();
        }

       

    }
}

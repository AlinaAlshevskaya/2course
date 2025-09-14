using System;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace lab2
{
    public partial class Vector
    {
        private string name = "Vec";
        private int[] massiv;
        private int size;
        private string sostoyanie = "";
        private static int NumOfElements = 0;
        private const int maxSize = 50;
        public readonly int id;

        public  void PrintNumandMaxsize()
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
        } 
        public void PrConstr(int[] arr, int size) { new Vector(arr, size); }
        public int Size {get { return size; } set { 
                if (value > maxSize) 
                { sostoyanie = sostoyanie+"\nСлишком большой размер масива"; }
                else if (value < size)
                {
                    massiv=massiv.SkipLast(size-value).ToArray();
                    size= value;
                }
                else
                {
                    int[]arr = massiv;
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
            } }
        public string Sostoyanie { get { if (sostoyanie == "") return "Ошибок нет"; else return sostoyanie; } }

        public int[] Array { get { return massiv; } set { massiv = value; }  }

        public int ID {  get { return id; } }
        public string Name { get { return name; } set {  name = value; } }

        public void AddElemet(int position, int value) { if (position >= size) { sostoyanie = "Taкого элемента нет"; return; } massiv[position] = value; }
        public int Element(int position) { return massiv[position];}
        public void PrintArray()
        {
            Console.WriteLine("----");
            for(int i = 0; i < size; i++)
            {
                Console.Write(massiv[i]+" ");
            }
            Console.WriteLine("\n----");
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
        public int Sum(int position,int number, out int sumstart)
        {
            sumstart = 0;
            sumstart=massiv[position]+number;
            return sumstart;
        }
        public int Multiply(ref int position, int number)
        {
            int product = massiv[position] * number;
            return product;
        }
        public override int  GetHashCode()
        {
            return id*8+size*4/3*id;
        }
        
        public static void InfAboutClass()
        {
            Console.WriteLine($"Класс Vector:\n" +
                $"Методы: GetHashCode(), Multiply(,), Sum(,), ToString(), PrintArray(), AddElement(,), Equals(), Element()\n" +
                $"Свойсва: Size, Sostoyanie, Array, ID\n" +
                $"Количесство конструкторов: 5\n Количество обьектов на данный момент: {NumOfElements}") ;
               
        }
         public bool Equals(Vector vector) 
        {
            if (size == vector.Size)

            {
                bool allelements = true;
                for (int i = 0;i < size; i++)
                {
                    if (massiv[i] != vector.Element(i))  allelements = false ;    
                }
                if (allelements) return true ;
            }
                return false;
        }

        public class Objects
        {
            Vector[] vectors;
            public Objects(Vector[] vector)=>vectors= vector;   
            public Vector this[int index]
            {
                get => vectors[index];
                set => vectors[index] = value;  
            }
        }



    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector Vec1 = new Vector();
            Vec1.AddElemet(0, 5);
            Vector Vec2 = new Vector(3);
           
            Vec2.AddElemet(0, 9);
            Vec2.AddElemet(1, 0);
            Vec2.AddElemet(2, 3);
            Vec2.AddElemet(3, 7);
            int[] NewArray= new int[3] { 9, 0, 3 };
            
            Vector Vec3= new Vector(NewArray);
            Vector PrVec = new Vector();
            PrVec.PrConstr(NewArray,3);
            Vec1.PrintArray();
            int sum3 = 0;
            Console.WriteLine(Vec1.Sum(3, 4, out sum3));
            Console.WriteLine(Vec2.ToString());
            int position = 0;
            Console.WriteLine(Vec3.Multiply(ref position, 3));
            Console.WriteLine(Vec2.Equals(Vec3));
            Console.WriteLine(Vec3.Size);
            Console.WriteLine(Vec1.Sostoyanie);
            Vec3.PrintNumandMaxsize();

            var VectorArray=new Vector[3] { Vec1, Vec2, Vec3 };
            Console.Write("Вектора содержащие ноль: ");
            for(int i = 0;i<VectorArray.Length;i++)
            {
                bool has0 = false;
                for(int j = 0; j < VectorArray[i].Size; j++)
                {
                    if (VectorArray[i].Element(j) == 0) has0 = true;
                }
                if (has0) Console.Write(VectorArray[i].Name + " ");
            }

            Console.Write("\nВектор с наибольшим модулем: ");
            int[] sum = new int[VectorArray.Length];
            for (int i=0;i<VectorArray.Length; i++)
            {
                sum[i] = 0; 
                for(int j = 0;j < VectorArray[i].Size; j++)
                {
                    sum[i]+= VectorArray[i].Element(j);
                }
            }
            int max = 0;
            string maxName = "";
            for(int i=0; i<sum.Length; i++)
            {
                if (sum[i] > max) { max = sum[i]; maxName = VectorArray[i].Name; }
            }
            Console.WriteLine(maxName);

        }
    }
}

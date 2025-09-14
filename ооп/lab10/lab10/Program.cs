using System;
using System.Collections.Specialized;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace lab10
{
    class LAB10
    {


        public static void Main(string[] args)
        {
            string[] month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int n = 4;
            IEnumerable<string> rezult1 = from m in month where m.Length == n select m;
            var rezult2 = month.Where(n => n == "June" || n == "July" || n == "August" || n == "December" || n == "January" || n == "February").Select(n => n);
            var rezult3=month.OrderBy(n => n).Select(n => n);
            var rezult4=month.Where(n=>n.Length>=4&&n.Contains('u')).Select(n => n);
            foreach(string rezult in rezult1) { Console.Write(rezult+" "); }
            Console.WriteLine();
            foreach (string rezult in rezult2) { Console.Write(rezult + " "); }
            Console.WriteLine();
            foreach (string rezult in rezult3) { Console.Write(rezult + " "); }
            Console.WriteLine();
            foreach (string rezult in rezult4) { Console.Write(rezult + " "); }
            Console.WriteLine();

            List<Vector> vectors = new List<Vector>();
            List<Vector> vectors2= new List<Vector>();   
            Vector vector1 = new Vector([3,8,2,0]);
            Vector vector2 = new Vector([4,6,2,3,-9,4]);
            Vector vector3 = new Vector([0,1,1,1,3,5,2]);
            Vector vector4 = new Vector([6,5,-4]);
            Vector vector5 = new Vector([14,-2,45,23,0]);
            Vector vector6 = new Vector([12,45,23,67,43]);
            Vector vector7 = new Vector([6, 23, 4, 612, 435,23,45,23,42,76,0,8]);
            Vector vector8 = new Vector([6,3,6,123,62,5,1,-3]);
            Vector vector9 = new Vector([6,69,0,-2,47,66]);
            Vector vector10 = new Vector([7,0,42,35,12]);

            vectors.Add(vector1);
            vectors.Add(vector2);   
            vectors.Add(vector3);   
            vectors.Add(vector4);
            vectors.Add(vector5);
            vectors.Add(vector6);

            vectors2.Add(vector7);
            vectors2.Add(vector8);
            vectors2.Add(vector9);
            vectors2.Add(vector10);
            vectors2.Add(vector1);

            var rezult5=vectors.Where(v=>v.HasZero()).ToList();
            var minmodul = vectors.Min(v =>v.modul) ;
            var rezult6 = vectors.Where(v => v.modul == minmodul).ToList();
            var rezult7=vectors.Where(v=>v.Array.Length==3|| v.Array.Length == 5|| v.Array.Length == 7).ToList();
            var maxmodul=vectors.Max(v=>v.modul) ;
            var rezult8=vectors.Where(v=>v.modul== maxmodul).ToList();
            var rezult9 = vectors.FirstOrDefault(v => v.HasNegative());
            var rezult10 = vectors.OrderBy(v=>v.Array.Length).ToList();
            foreach (Vector rezult in rezult5) { Console.Write(rezult.AllElements() + " "); }
            Console.WriteLine();
            foreach (Vector rezult in rezult6) { Console.Write(rezult.AllElements() + " "); }
            Console.WriteLine();
            foreach (Vector rezult in rezult7) { Console.Write(rezult.AllElements() + " "); }
            Console.WriteLine();
            foreach (Vector rezult in rezult8) { Console.Write(rezult.AllElements() + " "); }
            Console.WriteLine();
            Console.WriteLine(rezult9.AllElements());
            foreach (Vector rezult in rezult10) { Console.Write(rezult.AllElements() + " "); }
            Console.WriteLine();
            var rezult11 = vectors.Skip(2).Where(v=>v.HasNegative()).Join(vectors2.Where(n => !n.HasZero()), v => v.Element(0),n=>n.Element(0), (v, c) => new Vector(v.Array, c.Array))
                 .OrderBy(p => p.Array.Length).ToList();
            foreach (Vector rezult in rezult11){ Console.Write(rezult.AllElements() + " "); }
        }
    }
}
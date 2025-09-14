namespace kontr
{
    public class Class1
    {
        public enum Month
        {
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }


        public class Computer : IComparable<Computer>
        {
            static int ram;
            public int Ram { get { return ram; } set { ram = value; } }
            static readonly int memory = 500;
            String name;
            public String Name { get { return name; } set { name = value; } }


            public Computer(String name) { this.name = name; }
            public int CompareTo(Computer comp)
            {
                if (comp.Name.Length == this.name.Length) return 0;
                if (comp.Name.Length > this.name.Length) return -1;
                if (comp.Name.Length < this.name.Length) return 1;
                else throw new ArgumentException();
            }


        }
        interface IGood
        {
            void Fine();
        }
        public abstract class Something
        {
            public abstract void ItsOk();
        }
        public class Case : Something, IGood
        {
            public Case() { }
            public override void ItsOk() { Console.WriteLine("It's OK"); }
            public void Fine()
            {
                Console.WriteLine("Fine");
            }
        }

        static void Main(string[] args)
        {
            foreach (Month month in Enum.GetValues(typeof(Month)))
            {
                Console.WriteLine(month);

            }
            string stroka = "123.456.789";
            string[] srt1= stroka.Split('.');
            for(int i = 0;i< srt1.Length; i++)
            {
                Console.WriteLine(srt1[i]);
            }
            Computer comp = new Computer("name1");
            Computer comp2 = new Computer("naaaame");
            Console.WriteLine(comp2.CompareTo(comp));
            Case case1 = new Case();
            case1.Fine();
            case1.ItsOk();
        }
    }

    
}
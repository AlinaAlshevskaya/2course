using System.Buffers;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Linq.Expressions;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;
using System.Diagnostics;

namespace lab4
{


     public enum Games
    {
        Minesweeper,
        Race,
        Hangman,
        Snake
    }
     public interface ISW
    {
        void Execute() { }
    }
    public abstract class SW
    {
        private string version = "0.0";
        public string Version { get { return version; } set { version = value; } }
        public override string ToString()
        {
            return version;
        }
        protected bool checkNameVersion(string name)
        {
            if (name =="") return false;
            for (int i = 0; i < name.Length; i++)
            {
                bool check = false;
                if ((name[i] < 91 && name[i] > 64) || (name[i] < 123 && name[i] > 96) || (name[i] < 255 && name[i] > 191) || (name[i] < 57 && name[i] > 47)) check = true;
                if (check == false) return false;
            }
            return true;
        }
        public abstract void Execute();
        public static bool operator >(SW sw1, SW sw2)
        {
            
                for (int i = 0; i < sw1.Version.Length; i++)
                {
                    if (sw1.Version[i] > sw2.Version[i]) return true;
                    if (sw1.Version[i] < sw2.Version[i]) return false;

                }
            if (sw1.Version.Length == sw2.Version.Length) return false;
            return false;

        }
        public static bool operator <(SW sw1, SW sw2)
        {
    
                for (int i = 0; i < sw1.Version.Length; i++)
                {
                    if (sw1.Version[i] < sw2.Version[i]) return true;
                    if (sw1.Version[i] > sw2.Version[i]) return false;

                }
            if (sw1.Version.Length == sw2.Version.Length) return false;
                return true;
        }
    }

    public class TextProcessor : SW
    {
        
        protected bool check = false;
        protected string text = null;
       

        public string Text { get { return text; } }
        public char Symbol { get; set; }

        public override void Execute()
        { check = true; }

        public void Check()
        {
            if (check) Console.WriteLine("Текстовый процессор запущен");
            else Console.WriteLine("Не запущино ни одно приложения использующее текстовый процессор");
        }
        public override string ToString()
        {
            string inf = "Это Тектовый процессор. ";
            if (check == true) inf+="Текстовый процессор запущен";
            else inf+="Не запущино ни одно приложения использующее текстовый процессор";
            return inf;
        }

    }

    public partial class Word : Operations
    {

    }
    public class Operations : TextProcessor
    {

         public void addText( string text)
        {
            if (check)
            { if (text.Length > 200) throw new NotValidTextLength("Недопустимая длина"); else base.text += text; }
            else throw new NotExecute("Word не запущен");
        }
         public string deleteSymbol(string text, int index)
        {
            string str = "";
            if (check)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (i != index - 1)
                    {
                        str += text[i];
                    }
                }
                return str;
            }
            else throw new NotExecute("Word не запущен");
         


        }
         public string GetWord(int index)
        {
            if (check)
            {

                if (text != null)
                {
                    if (index < 1) { throw new IndexOutOfRangeException("Такого слова нет"); return null; }
                    int counter = 0;
                    string word = "";
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (text[i] == ' ' && i != 0) counter++;
                        if (counter == index - 1)
                        {
                            word += text[i];
                        }
                    }
                    if (index > counter + 1) throw new IndexOutOfRangeException("Такого слова нет");
                    return word;
                }
                else throw new NullReferenceException("Нет текста");
            }
            else { throw new NotExecute("Word не запущен"); }
            
        }
         public string deleteText()
        {
            if (check)
            {
                text = null;
                return text;
            }
            else throw new NotExecute("Word не запущен");
            
        }
        public override int GetHashCode()
        {
            int hash = 0;
            try
            { 
                hash = text.Length * 6 % 3 - text.Length - 3; 
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Нет текста");
                throw ex;
            }
            return hash;
        }
        public bool Equals(Word word2)
        {
            if(word2.text!= text) return false;
            else return true;
        }
        public override string ToString()
        {
            string inf = "Это  процессор. ";
            if (check == true) inf += "Текстовый процессор запущен";
            else inf += "Не запущино ни одно приложения использующее текстовый процессор";
            inf += "Текс внутри:\n";
            inf += text;
            return inf;
        }
    }
    public abstract class Virus : SW
    {
        
        bool check = false;
        public override void Execute()
        { check = true; }
        public Virus() { }
        

        virtual public void Check()
        {
            if (check == true) Console.WriteLine(" Virus запущен");
            else Console.WriteLine("Virus  не запущен");
        }

        public override string ToString()
        {
            string inf = "";
            if (check == true)
            {
                inf += "Virus запущен. ";
            }
            else inf += "Virus не запущен.";
            return inf;
        }
    }
    public class Conficker : Virus,ISW
    {
        bool check = false;
        

        public Conficker(string SWversionname) { if (!checkNameVersion(SWversionname)) throw new NotValidVersionName("Такое имя версии не допустимо"); base.Version = SWversionname; }
        public override void Check()
        {
            base.Check();
        }
        void ISW.Execute() { Console.WriteLine("Интерфейс запущен"); }
        public override void Execute()
        {
            base.Execute();
            Console.WriteLine("Conficker запущен");
            check = true;
        }

        public override string ToString()
        {
            string inf = "";
            if (check == true)
            {
                inf += "Conficker запущен. ";
            }
            else inf += "Conficker не запущен.";
            return inf;
        }
        public void PumPum()
        {
            if (check) Console.WriteLine("pum pum pum ...");
            else throw new NotExecute("Conficker не запущен");
        }

    }
    abstract class Toy : SW
    {
        bool check = false;
        Games type;
        public  Games Type{get { return type; } set { type = value;}}
        public  string GetTypeGame() {
            switch (type)
            {
                case Games.Minesweeper: return "Minesweeper";
                case Games.Race: return "Race";
                case Games.Hangman: return "Hangman";
                case Games.Snake: return "Snake"; 
                default: throw new NotImplementedException();  
            }
             
        }
        public override void Execute()
        { check = true; }

        public void Check()
        {
            if (check == true) Console.WriteLine("Игры запущены");
            else Console.WriteLine("Ни одна игра не запущена");
        }
        public override string ToString()
        {
            string inf = "";
            if (check == true)
            {
                inf += "Игры запущены.Запущена игра ";
                inf += GetTypeGame();
            }
            else inf += "Игры не запущены";
            return inf;
        }


    }
    sealed class Minesweerer : Toy
    {
       
        
        bool check = false;
        int[,] playground = new int[9, 9];
        int bombs = 0;
        Random random = new Random();
        public Minesweerer(string SWversionName) {
            if (!checkNameVersion(SWversionName)) throw new NotValidVersionName("Такое имя версии не допустимо");
            base.Version = SWversionName;
            base.Type = Games.Minesweeper;
        }



        public override void Execute()
        {
            base.Execute();
            Console.WriteLine("Minesweerer запущен");
            check = true;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    playground[i, j] = 0;
                }
            }
            for (int i = 0; i < 9; i++)
            {
                int rand_number = random.Next(0, 13);
                if (rand_number < 9) { playground[i, rand_number] = 10; bombs++; }
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (playground[i, j] >9 && (i != 0) && (i != 8) && (j != 0) && (j != 8))
                    {
                        playground[i - 1, j - 1] += 1;
                        playground[i - 1, j] += 1;
                        playground[i - 1, j + 1] += 1;
                        playground[i, j - 1] += 1;
                        playground[i, j + 1] += 1;
                        playground[i + 1, j - 1] += 1;
                        playground[i + 1, j] += 1;
                        playground[i + 1, j + 1] += 1;
                    }
                    if (playground[i, j] == 10 && (i != 0) && (i != 8) && (j == 0))
                    {
                        playground[i - 1, j] += 1;
                        playground[i - 1, j + 1] += 1;
                        playground[i, j + 1] += 1;
                        playground[i + 1, j] += 1;
                        playground[i + 1, j + 1] += 1;
                    }
                    if (playground[i, j] == 10 && (i != 0) && (i != 8) && (j == 8))
                    {
                        playground[i - 1, j - 1] += 1;
                        playground[i - 1, j] += 1;
                        playground[i, j - 1] += 1;
                        playground[i + 1, j - 1] += 1;
                        playground[i + 1, j] += 1;
                    }
                    if (playground[i, j] == 10 && (i == 0) && (j != 0) && (j != 8))
                    {
                        playground[i, j - 1] += 1;
                        playground[i, j + 1] += 1;
                        playground[i + 1, j - 1] += 1;
                        playground[i + 1, j] += 1;
                        playground[i + 1, j + 1] += 1;

                    }
                    if (playground[i, j] == 10 && (i == 8) && (j != 0) && (j != 8))
                    {
                        playground[i - 1, j - 1] += 1;
                        playground[i - 1, j] += 1;
                        playground[i - 1, j + 1] += 1;
                        playground[i, j - 1] += 1;
                        playground[i, j + 1] += 1;
                    }
                    if (playground[i, j] == 10 && (i == 0) && (j == 0))
                    {

                        playground[i, j + 1] += 1;
                        playground[i + 1, j] += 1;
                        playground[i + 1, j + 1] += 1;

                    }
                    if (playground[i, j] == 10 && (i == 0) && (j == 8))
                    {

                        playground[i, j - 1] += 1;
                        playground[i + 1, j] += 1;
                        playground[i + 1, j - 1] += 1;

                    }
                    if (playground[i, j] == 10 && (i == 8) && (j != 0) && (j != 8))
                    {
                        playground[i - 1, j - 1] += 1;
                        playground[i - 1, j] += 1;
                        playground[i - 1, j + 1] += 1;
                        playground[i, j - 1] += 1;
                        playground[i, j + 1] += 1;
                    }
                    if (playground[i, j] == 10 && (i == 8) && (j == 0))
                    {
                        playground[i - 1, j] += 1;
                        playground[i - 1, j + 1] += 1;

                        playground[i, j + 1] += 1;
                    }
                    if (playground[i, j] == 10 && (i == 8) && (j == 8))
                    {
                        playground[i - 1, j - 1] += 1;
                        playground[i - 1, j] += 1;
                        playground[i, j - 1] += 1;

                    }
                }
            }
        }
        public void ShowPlayground()
        {
            if (check)
            {
                Console.WriteLine("-----------------");
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (playground[i, j] > 9) Console.Write("* ");
                        else Console.Write(playground[i, j] + " ");
                    }
                    Console.Write("\n");
                }
                Console.WriteLine("-----------------");
            }
            else { throw new NotExecute("Minesweeper не запущен."); }
        }

        public override string ToString()
        {
            string inf = "Это игра Сапер. ";
            if (check == true)
            {
                inf += "Она запущена. ";
                inf += "Количество бомб: ";
                inf += Convert.ToString(bombs);
            }
            else inf += "Игра не запущена";
            return inf;
        }
    }
    sealed class Hangman: Toy
    {
        bool check;
        public override void Execute()
        {
            base.Execute();
        }
        public Hangman( string SWversionName) {
            if (!checkNameVersion(SWversionName)) throw new NotValidVersionName("Такое имя версии не допустимо");
            base.Version = SWversionName;
            base.Type = Games.Hangman;
        }
        public override string ToString()
        {
            string inf = "Это игра Висельница. ";
            if (check == true)
            {
                inf += "Она запущена. ";
            }
            else inf += "Игра не запущена";
            return inf;
        }
        public void TryAssert(bool condition)
        {
            Debug.Assert(condition,"Условие должно быть правдой");
        }

    }

            

        
    
     abstract class Developer:SW
    {
        const string Name = "Alina Alshevskaya";
        void GetProject() { Console.WriteLine("Name: " + Name);
            Console.WriteLine("SoftWare version: " + base.Version);
        }
        public override string ToString() {
            string inf= Name;
            inf += "SoftWare version: " + base.Version;
            return inf;
        }

    }

    public class Printer
    {
        public static void IAmPrinting(SW obj)
        {
            if (obj != null)
            {
                Console.WriteLine(obj.ToString());
            }
        }
        public static void Print(SW obj)
        {
            Minesweerer game = obj as Minesweerer;
            if(game != null)
            {
                game.ShowPlayground();
            }
        }
    }

    public class Computer
    {
        List<SW> SWs;
        public Computer()
        {
            SWs = new List<SW>();
        }

        public SW this[int index]
        {
            get
            {
                if (index < SWs.Count) { return SWs[index]; }
                else { throw new IndexOutOfRangeException(); }
            }
        }
        public void AddSW(SW comp)
        {
            SWs.Add(comp);
        }
        public void RemoveSW(SW comp)
        {
            SWs.Remove(comp);
        }
        public int Size
        {
            get { return SWs.Count; }
        }
        public SW GetElement(int index)
        {
            return SWs[index];
        }

        public void ChangeElement(int index, SW element)
        {
            SWs[index] = element;
        }
        public List<SW> ListofSWs
        {
            get
            {
                return SWs;
            }
            set { SWs    = value; }
        }
        public void PrintSW()
        {
            for(int i = 0; i < SWs.Count; i++)
            {
                Console.WriteLine(SWs[i].ToString());
            }
        }

    }
    
    public class ComputerOperations
    {
        Computer computer;
        public ComputerOperations(Computer computer) { this.computer = computer; }
       
        public bool FindGame(Games games)
        {
            foreach(SW sw in computer.ListofSWs)
            {
                if(sw is Toy toy)
                {
                    if (games == toy.Type) return true;
                }

            }
            return false;
        }
        public bool FindWord(string version)
        {
            foreach (SW sw in computer.ListofSWs)
            {
                if (sw is Word word)
                {
                    if (word.Version == version) return true;
                }
            }
            return false;
        }
        public void printSWS(List<SW> sws)
        {
            foreach (SW sw in sws)
            {
                Console.Write(sw.Version);
                Console.Write("    ");
            }
        }

        public void SortSW()
        {
            for(int i=0; i<computer.ListofSWs.Count; i++)
            {
                for ( int j = 0; j<computer.ListofSWs.Count-1-i; j++)
                {
                    if (computer.ListofSWs[j] > computer.ListofSWs[j + 1]) { var tmp = computer.ListofSWs[j]; computer.ListofSWs[j] = computer.ListofSWs[j + 1]; computer.ListofSWs[j + 1] = tmp; }
                }
                
            }
            printSWS(computer.ListofSWs); 
        }
        

    }
    struct Myself
    {
         public string name;
         public int age;
        public void printName()
        {
            Console.WriteLine(name);
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
           Word fileWord= new Word("Aaw1");
            fileWord.Execute();
            fileWord.addText("рум пурум пурмпум пум");
            Console.WriteLine(fileWord.Text);
            fileWord.Check();
            Console.WriteLine(fileWord.GetWord(3));
            Printer.IAmPrinting(fileWord); 
            Minesweerer game1= new Minesweerer("MSV11");
            game1.Execute();
            game1.ShowPlayground();
            Printer.IAmPrinting(game1);
            Minesweerer game2= new Minesweerer("MSV22");
            Hangman game3 = new Hangman("HH4");
            ISW vir1 = new Conficker("vvv3");
            vir1.Execute();
            Computer comp = new Computer();
            comp.AddSW(game2);
            comp.AddSW(game1 );
            comp.AddSW(fileWord);
            comp.AddSW(game3);
            ComputerOperations operations = new ComputerOperations(comp);
            operations.SortSW();
            if (operations.FindGame(Games.Hangman)) Console.WriteLine("\nИгра Hangman есть");
            if (operations.FindWord("Aaw1")) Console.WriteLine("Tакая верся ворд есть");
            Word testword = new Word("Test");
            testword.Execute();


            Myself myself = new Myself();
            myself.name = "Alina";
            myself.printName();



            try
            {
                Minesweerer geme = new Minesweerer("###Wsa");
            }
            catch (NotValidVersionName ex)
            {
                Exceptions.Handle(ex);
            }

            finally
            {
                Console.WriteLine("Исключения обработаны");
                Console.WriteLine();
            }

            try
            {
                Conficker vir = new Conficker("zzz");
                vir.PumPum();
                 
            }
            catch (NotExecute ex)
            {
                Exceptions.Handle(ex);
            }
            finally
            {
                Console.WriteLine("Исключения обработаны");
                Console.WriteLine();
            }

            try
            {
                Word word = new Word("zzz");
                word.Execute();
                word.addText("uytredsxcfvgbhnjkytrdfghjjhgfdcghjkuyyyyyyyyyyyyyyyyyyyyyyyyyklkjhgfghhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh9kjhgtfdxcvbnmk,juhygtfcvbnmk,juhygfbnmkjuhygtfghjkl;lkj777777777");

            }
            catch (NotValidTextLength ex)
            {
                Exceptions.Handle(ex);
            }
            finally
            {
                Console.WriteLine("Исключения обработаны");
                Console.WriteLine();
            }

            try
            {
                Word word = new Word("345f");
                word.Execute();
                word.addText("yyyyyy eeeee");
                word.GetWord(6);
            }
            catch (IndexOutOfRangeException ex)
            {
                Exceptions.Handle(ex);
            }
            finally
            {
                Console.WriteLine("Исключения обработаны");
                Console.WriteLine();

            }

            try
            {
                Word word = new Word("ytt");
                word.Execute();
                word.GetWord(4);
            }
            catch (NullReferenceException ex)
            {
                Exceptions.Handle(ex);
            }
            finally
            {
                Console.WriteLine("Исключения обработаны");
                Console.WriteLine();
            }

            try
            {
                testword.GetHashCode();
            }
            catch (NullReferenceException ex)
            {
                Exceptions.Handle(ex);
            }
            finally
            {
                Console.WriteLine("Исключения обработаны");
            }
            game3.TryAssert(fileWord.GetHashCode() > 999);


        }
    }

}


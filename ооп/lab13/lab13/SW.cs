using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
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
    [Serializable]
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
            if (name == "") return false;
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
            if (check == true) inf += "Текстовый процессор запущен";
            else inf += "Не запущино ни одно приложения использующее текстовый процессор";
            return inf;
        }

    }

    public partial class Word : Operations
    {

    }
    public class Operations : TextProcessor
    {

        public void addText(string text)
        {
            if (check)
            { if (text.Length > 200) throw new Exception("Недопустимая длина"); else base.text += text; }
            else throw new Exception("Word не запущен");
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
            else throw new Exception("Word не запущен");



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
            else { throw new Exception("Word не запущен"); }

        }
        public string deleteText()
        {
            if (check)
            {
                text = null;
                return text;
            }
            else throw new Exception();
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
        public class Conficker : Virus, ISW
        {
            bool check = false;


            public Conficker(string SWversionname) { if (!checkNameVersion(SWversionname)) throw new Exception("Такое имя версии не допустимо"); base.Version = SWversionname; }
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
                else throw new Exception("Conficker не запущен");
            }

        }
    [Serializable]
        public class Toy : SW
        {
            bool check = false;
            Games type;
            public Games Type { get { return type; } set { type = value; } }
            public string GetTypeGame()
            {
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
        [Serializable]
        public class Minesweerer : Toy
        {


            bool check = false;
            int[,] playground = new int[9, 9];
            int bombs = 0;
            Random random = new Random();
            public Minesweerer(string SWversionName)
            {
                if (!checkNameVersion(SWversionName)) throw new Exception("Такое имя версии не допустимо");
                base.Version = SWversionName;
                base.Type = Games.Minesweeper;
            }
        public Minesweerer()
        {
          
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
                        if (playground[i, j] > 9 && (i != 0) && (i != 8) && (j != 0) && (j != 8))
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
                else { throw new Exception("Minesweeper не запущен."); }
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
        sealed class Hangman : Toy
        {
            bool check;
            public override void Execute()
            {
                base.Execute();
            }
            public Hangman(string SWversionName)
            {
                if (!checkNameVersion(SWversionName)) throw new Exception("Такое имя версии не допустимо");
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
                Debug.Assert(condition, "Условие должно быть правдой");
            }

        }





        abstract class Developer : SW
        {
            const string Name = "Alina Alshevskaya";
            void GetProject()
            {
                Console.WriteLine("Name: " + Name);
                Console.WriteLine("SoftWare version: " + base.Version);
            }
            public override string ToString()
            {
                string inf = Name;
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
                if (game != null)
                {
                    game.ShowPlayground();
                }
            }
        }
 }



using System.Security.Cryptography.X509Certificates;

namespace Lab8
{
    public delegate void ReplaceD(string itemname,string newplace);
    public delegate void CompressD(string itemname, int k);

    public class User
    {
        private string name;

        public User(string name)
        {
            this.name = name;
        }
        public event ReplaceD ReplaceE;
        public event CompressD CompressE;

        public void Replace(string itemname, string newplace)
        {
            ReplaceE?.Invoke( itemname,newplace);
        }
        public void Compress(string itemname, int k)
        {
            CompressE?.Invoke(itemname,k);
        }
    } 

    public class Item
    {
        public string place;
        public int valume;
        public string name;
        public string[] operations;

        public Item(string name,int valume, User user,string place="desktop")
        {
            this.name = name;
            this.valume = valume;
            this.place = place;
            operations = new string[5];
            user.ReplaceE += (string itemname,string newplace) => { if (this.name == itemname) this.place = newplace; };
            user.CompressE += (string itemname,int k) => { if (this.name == itemname) this.valume = valume / k; };
        }
        
    }

    public class Computer
    {
        public Item[] items;
        private int items_size;
        public Computer(int size)
        {
            items = new Item[size];
            items_size = 0;
        }

        public void AddItem(Item item)
        {
            items[items_size] = item;
            items_size++;
        }
        public void PrintItems()
        {
            for (int i = 0; i < items_size; i++)
            {
                Console.Write($"{items[i].name} Storage location :{items[i].place} Valume: {items[i].valume}");
                foreach (string op in items[i].operations)
                {
                    Console.Write(" " + op + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

    internal class StringModifier
    {
        public static string RemoveUpper(string str, Func<string, string> func)
        {
            return func(str);
        }
        public static void AddToString(string str, Action<string> action)
        {
            action(str);
        }

        public static bool isNumber(string str, Predicate<string> check)
        {
            return check(str);
        }
        public static string RemoveSpaces(string str, Func<string, string> test3) //удаление пробелов
        {
            return test3(str);
        }

        public static string Reverse(string str, Func<string, string> func)
        {
            return func(str);
        }
    }


}
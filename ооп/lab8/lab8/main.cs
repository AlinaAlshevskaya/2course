using lab8;
using Lab8;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
User Alina = new User("Alina");
Item folder = new Item("folder1",300, Alina);
Item doc = new Item("worddoc",120, Alina,"disk D");
Computer comp = new Computer(4);
comp.AddItem(folder);
comp.AddItem(doc);

comp.PrintItems();
Alina.Replace("folder1", "disk C");
comp.PrintItems();
Alina.Compress("worddoc",3); 
comp.PrintItems();

Func<string, string> remUp = (string str) =>
{
    foreach (char c in str)
    {
        if ((c >= 'A' && c <= 'Z') || (c >= 'А' && c <= 'Я')) str = str.Remove(str.IndexOf(c), 1);
    }
    Console.WriteLine(str + '\n');
    return str;
};

Action<string> action = (string str) =>
{
    str += " доброй дороги!";
    Console.WriteLine(str + '\n');
};

Predicate<string> isNum = (string str) =>
{
    bool check = true;
    foreach (char c in str)
    {
        if (c < '0' && c > '9') check = false;
    }
    return check;
};

Func<string, string> remSpace = (string str) =>
{
    str = str.Replace(" ", string.Empty);
    Console.WriteLine(str + '\n');
    return str;
};

Func<string, string> reverse = (string str) =>
{
    StringBuilder reversed = new StringBuilder();
    for (int i = str.Length - 1; i >= 0; i--)
    {
        reversed.Append(str[i]);
    }
    Console.WriteLine(reversed.ToString() + '\n');
    return reversed.ToString();
};

string str = "Симулятор Дальнобойщика 2";
Console.WriteLine(str);
Console.WriteLine();
string s1, s2, s3;
s1 = StringModifier.RemoveUpper(str, remUp);
StringModifier.AddToString(s1, action);
s2 = StringModifier.RemoveSpaces(s1, remSpace);
s3 = StringModifier.Reverse(s2, reverse);

Class1 class1 = new Class1();


Class2 class2 = new Class2(class1);
class1.replacenew(3);


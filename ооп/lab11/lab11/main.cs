using lab11;
using lab4;

internal class Program
{


    static void Main(string[] args)
    {
        Minesweerer game1 = new Minesweerer("FFF7");
        Hangman game2 = new Hangman("RRRRR5");
        string assbl = Reflector.AssemblyName(game1);
        Console.WriteLine(assbl);
        bool pub_constr = Reflector.IsPubConstr(game1);
        Console.WriteLine(pub_constr);
        var list = Reflector.GetPublicMeth(game1);
        Console.WriteLine();
        foreach (var item in list)
        {
            Console.WriteLine(item);
        };
        Console.WriteLine();
        list = Reflector.publicPropAndFields(game1);
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
        list = Reflector.publicPropAndFields(game2);
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
        list = Reflector.GetInterfaces(game1);
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
        int a = 2;
        Reflector.PrintMeth(game1, a);

        Reflector.Invoke(game1, "Execute", new object[] { });


        var bro = Reflector.Create(game1, new object[] { "fFF6543223456" });
        Console.WriteLine(bro);

    }
}


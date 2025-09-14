using lab9;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.ConstrainedExecution;

Cars cars=new Cars();
Car Alinas = new Car("Tayota", "red", 2008, 7274);
Car Ilushika = new Car("Renault", "white", 2016, 1333);
Car Dads = new Car("VolkWagen", "darkgreen", 2004, 8375);
Car Dreamcar = new Car("Ferrari", "red", 2023, 7777);
cars.Add(Alinas);
cars.Add(Ilushika);
cars.Add(Dads);
cars.Add(Dreamcar);
cars.PrintAllCars();
cars.FindByColor("red");
Console.WriteLine(cars.Count);


Dictionary<int, string> collection1 = new Dictionary<int, string>();
collection1.Add(1, "first");
collection1.Add(2, "second");
collection1.Add(3, "third");
foreach (var item in collection1)
{
    Console.WriteLine(item);
}
Console.WriteLine();
List<string> collection2 = new List<string>();
foreach (var item in collection1)
{
    collection2.Add(item.Value);
}
string search = "second";
foreach (var item in collection2)
{
    Console.WriteLine(item);

}
for (int i = 0; i < collection2.Count; i++)
{
    if (collection2[i] == search) { Console.WriteLine("ID: " + (i + 1)); }
}

ObservableCollection<Car> collection3 = new ObservableCollection<Car>();

collection3.CollectionChanged += (sender, e) =>
{
    switch (e.Action)
    {
        case NotifyCollectionChangedAction.Add:
            {
                if (e.NewItems?[0] is Car car)
                {
                    Console.Write($"Добавлена новая машина: ");
                    car.PrintCar();
                }
                break;
            }
        case NotifyCollectionChangedAction.Remove:
            {
                if (e.OldItems?[0] is Car car)
                {
                    Console.Write($"Удалена машина: ");
                    car.PrintCar();
                }
                break;
            }

    }
};

collection3.Add(Alinas);
collection3.Add(Ilushika);
collection3.Add(Dads);
collection3.Remove(Ilushika);

using System.Collections;
using System.Runtime.InteropServices;


namespace lab9
{
    public class Car
    {

        public string marka;
        public string color;
        public int year;
        public int id;
        public Car(string marka, string color, int year,int id )
        {
            this.marka = marka;
            this.color = color;
            this.year = year;
            this.id = id;
    }
        public void PrintCar()
        {
            Console.WriteLine($"{this.id}---{this.marka} - {this.color} - {this.year} ");
        }
        public string Inf
        {
            get { return $"{this.id}---{this.marka} - {this.color} - {this.year} "; }
        }
        

    }
    public class Cars : IList<Car>
    {
      private Dictionary<int,Car> cars = new Dictionary<int,Car>();
        public Cars() { cars = new Dictionary<int, Car>(); }
        public void PrintAllCars()
        {
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Value.Inf}");
            }
            Console.WriteLine();
        }
         public void FindByColor(string color)
        {
            foreach (var car in cars)
            {
                if (car.Value.color == color)
                {
                    Console.WriteLine($"{car.Value.Inf}");
                }
            }
            Console.WriteLine();
        }
        public void FindByYear(int year)
        {
            foreach (var car in cars)
            {
                if (car.Value.year == year)
                {
                    Console.WriteLine($"{car.Value.Inf}");
                }
            }
            Console.WriteLine();
        }
        public void FindByMarka(string marka)
        {
            foreach (var car in cars)
            {
                if (car.Value.marka == marka)
                {
                    Console.WriteLine($"{car.Value.Inf} ");
                }
            }
            Console.WriteLine();
        }
        public Car this[int index]
        {
            get => cars[index];
            set => cars[index] = value;
        }
        public int IndexOf(Car car)
        {
            foreach (var id in cars)
            {
                if (car == id.Value)
                {
                    return id.Key;
                }
      
            }
            throw new NotImplementedException();
        }
        public int Count => cars.Count;
        public void Insert(int id, Car car)
        {
            cars.Remove(id);
            cars.Add(id,car);
        }
        public bool Contains(Car car)
        {
            return cars.ContainsValue( car);
        }
        public void RemoveAt(int id)
        {
            cars.Remove(id);
        }
        public void Add(Car car)
        {
            cars.Add(car.id,car);
        }
        public void Clear()
        {
            cars.Clear();
        }
        public void CopyTo(Car[] carsarray,int index)
        {
            foreach(var car in cars)
            {
                carsarray[index] = car.Value;
                index++;
            }
        }
        public bool Remove(Car car)
        {
            return cars.ContainsValue(car);
        }
        public bool IsReadOnly { get { return false; } }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return cars.GetEnumerator();
        }

        public IEnumerator<Car> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
       

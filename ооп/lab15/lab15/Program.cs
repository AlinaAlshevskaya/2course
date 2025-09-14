
using System.Threading.Tasks;
using lab15;

namespace lab15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TPL.TaskMultiply();
            Thread.Sleep(2000);
            TPL.TaskCancalled();
            Thread.Sleep(2000);
            TPL.TaskCombination(10);
            Thread.Sleep(2000);
            TPL.TaskContinuationConseq(10);
            Thread.Sleep(2000);
            TPL.TaskContinuationAwaitResult(10);
            Thread.Sleep(2000);
            TPL.For();
            Thread.Sleep(2000);
            TPL.ParallelFor();
            Thread.Sleep(2000);
            TPL.ParallelForEach();
            Thread.Sleep(2000);
            TPL.ParallelINvoke();
            Thread.Sleep(2000);

            Good utug = new("Утюг Philips", 20);
            Producer philips = new("компания Philips", utug, 2, 15);
            Buyer tom = new("TOM", utug, 3);
            Store element5 = new("5-ый Элемент");
            element5.RunStore(philips, tom);

            TPL.wait();
            Thread.Sleep(10000);
        }
    }
}
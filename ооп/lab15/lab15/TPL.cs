using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace lab15
{
    static class TPL
    {
        static int[] vector = Enumerable.Range(1, 100).ToArray();
        static int multiplier = 2;

        public static void TaskMultiply()
        {
            Task task = Task.Run(() => MultiplyVector(vector, multiplier));
            Console.WriteLine($"ID: {task.Id}");
            task.Wait();
            Console.WriteLine($"Status: {task.Status}");

           
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 10; i++)
            {
                MultiplyVector(vector, multiplier);
            }
            sw.Stop();
            Console.WriteLine($"Time: {sw.ElapsedMilliseconds}");
        }


        public static void TaskCancalled()
        {
            
            CancellationTokenSource cts = new CancellationTokenSource();
            Task cancelableTask = Task.Run(() => MultiplyVectorWithCancellation(vector, multiplier, cts.Token), cts.Token);
            cts.CancelAfter(100); 
            try
            {
                cancelableTask.Wait();
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions.Any(e => e is TaskCanceledException))
                {
                    Console.WriteLine("Canceled.");
                }
            }
        }


        static void MultiplyVector(int[] vector, int multiplier)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] *= multiplier;
            }
        }

        

        static void MultiplyVectorWithCancellation(int[] vector, int multiplier, CancellationToken token)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                token.ThrowIfCancellationRequested();
                vector[i] *= multiplier;
            }
        }
        public static int Combine(int n) => n += n;
        public static int Square(int n) => n * n;

        public static void TaskCombination(int x)
        {
            var length = Task.Run(() => Combine(x));
            var width = Task.Run(() => Square(x));
            var heigth = Task.Run(() => x * 10);
            Task<int> finalTask = Task.WhenAll(length, width, heigth).ContinueWith(t => 
            { int result1 = t.Result[0];
                int result2 = t.Result[1]; 
                int result3 = t.Result[2]; 
                return result1 *result2 *result3;
            }
            );

            Console.WriteLine($"V=: {finalTask.Result}");

        }

        public static void TaskContinuationConseq(int n)
        {

            var task1 = Task.Run(() => Combine(n));
            var task2 = task1.ContinueWith(x => Square(x.Result));
            var task3 = task2.ContinueWith(x => Combine(x.Result));

            Console.WriteLine($"ALLresult: {task3.Result}");
        }

        public static void TaskContinuationAwaitResult(int n)
        {
            Task<int> lengthTask = Task.Run(() => Combine(n));

            Task<int> widthTask = Task.Run(() => Square(lengthTask.GetAwaiter().GetResult()));
            Task<int> heigthTask = Task.Run(() => widthTask.GetAwaiter().GetResult() * 10);
            int result = heigthTask.GetAwaiter().GetResult();
            Console.WriteLine($"ALLresult: {result}");

        }
        public static void For()
        {
            Stopwatch sw = Stopwatch.StartNew();


         
            for (int n = 0; n < vector.Length; n++)
            {
               
                Console.WriteLine(vector[n]);

            }
            sw.Stop();
            Console.WriteLine($"\n\nTime: {sw.Elapsed}\n");
        }
        public static void ParallelFor()
        {
            Stopwatch sw = Stopwatch.StartNew();
            Parallel.For(1, vector.Length, Plus);

          
            void Plus(int n)
            {
                
                Console.WriteLine(vector[n]);

            }
            sw.Stop();
            Console.WriteLine($"\n\nTime: {sw.Elapsed}\n");
        }

        public static void ParallelForEach()
        {
            Stopwatch sw = Stopwatch.StartNew();
            Parallel.ForEach(vector, Plus);
            // вычисляем квадрат числа
            void Plus(int n)
            {
                
                Console.WriteLine(value: n);

            }
            sw.Stop();
            Console.WriteLine($"\n\nTime: {sw.Elapsed}\n");
        }
        public static void ParallelINvoke()
        {
            Stopwatch sw = Stopwatch.StartNew();
            Parallel.Invoke(
              () => Task1(),
              () => Task2(),
              () => Task3()
          );

        }
        public static void Task1()
        {
            Task task = Task.Run(() => MultiplyVector(vector, multiplier+1));
        }
        public static void Task2()
        {
            Task task = Task.Run(() => MultiplyVector(vector, multiplier+2));
        }

        public static void Task3()
        {
            Task task = Task.Run(() => MultiplyVector(vector, multiplier-4));
        }
        public static async Task wait()
        {
            var tomTask = PrintNameAsync("Tom");
            var bobTask = PrintNameAsync("Bob");
            var samTask = PrintNameAsync("Sam");

            await tomTask;
            await bobTask;
            await samTask;
           
            async Task PrintNameAsync(string name)
            {
                await Task.Delay(3000);     
                Console.WriteLine(name);
            }
        }
    }

}


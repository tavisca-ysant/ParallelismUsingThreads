using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelismUsingThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new Stopwatch();
            watch.Start();
            Task.Run(async () =>
            {
                var task1 =  PrintData();
                var task2 =  SaveData();
                await Task.WhenAll(task1, task2);
            }).GetAwaiter().GetResult();
            Console.WriteLine($"Total time taken {watch.ElapsedMilliseconds}");
            Console.ReadKey(true);
        }

        private async static Task PrintData()
        {
            await Task.Delay(3000);
            Console.WriteLine("In method Print Data");
        }

        private async static Task SaveData()
        {
            await Task.Delay(4000);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeNumbersCounter
{
    class Program
    {
        private static int Count = 0;
        static object lockObject = new object();

        static void Main(string[] args)
        {   //new Thread(() =>
            // {
            //     // code
            // });

            //Race Condition
            //List<int> numbers = Enumerable.Range(0, 10000).ToList();
            //for (int i = 0; i < 4; i++)
            //{
            //    new Thread(() =>
            //    {
            //        while (numbers.Count > 0)
            //            numbers.RemoveAt(numbers.Count - 1);
            //    }).Start();
            //}




            Stopwatch sw = Stopwatch.StartNew();

            var tasks = new List<Task>();

            for (int i = 1; i <= 100; i++)
            {
                var task = Task.Run(async () =>
                {
                    DownloadAsync(i);
                });
                tasks.Add(task);

            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine(sw.Elapsed);
            Console.ReadLine();

            return;
            //Thread thread = new Thread(() => PrintPrimeCount(1, 2500000));
            //thread.Start();

            Thread thread2 = new Thread(() => PrintPrimeCount(2500001, 5000000));
            thread2.Start();
            Thread thread3 = new Thread(() => PrintPrimeCount(5000001, 7500000));
            thread3.Start();
            Thread thread4 = new Thread(() => PrintPrimeCount(7500001, 10000000));
            thread4.Start();

            //thread.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();

            Console.WriteLine(Count);
            Console.WriteLine(sw.Elapsed);

            //thread.Join(); //program is up while thread is up
            while (true)
            {
                var input = Console.ReadLine();
                Console.WriteLine(input.ToUpper());
            }
        }


        static async Task DownloadAsync(int i)
        {
            HttpClient httpClient = new HttpClient();
            var url = $"https://vicove.com/vic-{i}";
            var httpsResponse = await httpClient.GetAsync(url);
            var vic = await httpsResponse.Content.ReadAsStringAsync();

            Console.WriteLine(vic);
        }

        static void PrintPrimeCount(int min, int max)
        {

            for (int i = min; i <= max; i++)
            {
                bool isPrime = true;

                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    lock (lockObject)
                    {
                        Count++;
                    }

                }
            }

        }
    }
}

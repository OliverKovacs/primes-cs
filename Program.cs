using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace primes_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            benchmark(5000000);
        }

        static List<int> getPrimes(int n)
        {
            List<int> primes = new List<int> { 1, 2 };
            for (int i = 3; i < n; i += 2)
            {
                if (isPrime(i, primes)) {
                    primes.Add(i);
                };
            }
            return primes;
        }

        static bool isPrime(int x, List<int> primes)
        {
            double sqrt = Math.Sqrt(x);
            for (int i = 2; i <= sqrt; i++)
            {
                if (x % primes[i] == 0) return false;
            }
            return true;
        }

        static void benchmark(int n)
        {
            long ms = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            List<int> primes = getPrimes(n);
            ms = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - ms;
            string json = JsonConvert.SerializeObject(primes.ToArray(), Formatting.Indented);
            System.IO.File.WriteAllText("./primes.json", json);
            Console.WriteLine($"range: {n}\nprimes: {primes.Count}\nms: {ms}/ sec: {ms / 1000}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSomeValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> counter = new Dictionary<double, int>();
            foreach (var num in numbers)
            {
                if (counter.ContainsKey(num))
                {
                    counter[num] += 1;
                }
                else
                {
                    counter.Add(num, 1);
                }
            }
            foreach (var num in counter)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}

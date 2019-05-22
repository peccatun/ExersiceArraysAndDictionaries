using System;
using System.Collections.Generic;

namespace CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> countries = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = info[0];
                string country = info[1];
                string sity = info[2];
                if (!countries.ContainsKey(continent))
                {
                    countries.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!countries[continent].ContainsKey(country))
                {
                    countries[continent].Add(country, new List<string>());
                }
               // if (!countries[continent][country].Contains(sity))
                //{
                    countries[continent][country].Add(sity);
                //}
            }
            foreach (var continen in countries)
            {
                Console.WriteLine(continen.Key+':');
                foreach (var country in continen.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ",country.Value)}");
                }
            }
        }
    }
}

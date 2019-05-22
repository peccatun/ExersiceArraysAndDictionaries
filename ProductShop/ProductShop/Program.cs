using System;
using System.Collections.Generic;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Revision")
            {
                string[] commandArr = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = commandArr[0];
                string product = commandArr[1];
                double price = double.Parse(commandArr[2]);
                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }
                if (!shops[shop].ContainsKey(product))
                {
                    shops[shop].Add(product,0);
                }
                shops[shop][product] = price;
            }
            foreach (var shop in shops)
            {
                Console.WriteLine(shop.Key+"->");
                foreach (var item in shop.Value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }
        }
    }
}

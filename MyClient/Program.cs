using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServiceReference1;

namespace MyClient
{

    internal class Program
    {
        static async Task Main(string[] args)
        {
            var client = new CurrencyServiceClient();

            Console.WriteLine("Fetching exchange table from WCF service...");
            string json = await client.GetTableAsync("C");

            var tables = JsonConvert.DeserializeObject<List<RateTable>>(json);
            var table = tables?[0];

            if (table == null)
            {
                Console.WriteLine("Failed to retrieve currency table.");
                return;
            }

            Console.WriteLine($"\nExchange Table: {table.no} - Effective: {table.effectiveDate}");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("{0,-25} {1,5}   {2,8}   {3,8}", "Currency", "Code", "Buy (bid)", "Sell (ask)");

            foreach (var rate in table.rates)
            {
                Console.WriteLine("{0,-25} {1,5}   {2,8:F4}   {3,8:F4}", rate.currency, rate.code, rate.bid, rate.ask);
            }

            Console.WriteLine("\nWhich currency do you want to exchange? (e.g., USD)");
            string selectedCode = Console.ReadLine()?.ToUpper();

            var selected = table.rates.Find(r => r.code == selectedCode);
            if (selected == null)
            {
                Console.WriteLine("Currency not found.");
                return;
            }

            Console.WriteLine("Do you want to 'buy' or 'sell' the currency?");
            string direction = Console.ReadLine()?.Trim().ToLower();


            Console.WriteLine($"Enter amount in {selectedCode}:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Invalid amount.");
                return;
            }

            decimal result = 0;
            if (direction == "sell")
            {
                result = amount * (decimal)selected.bid;
                Console.WriteLine($"\nSELLING {amount} {selectedCode} → You get {result:F2} PLN (bid = {selected.bid})");
            }
            else if (direction == "buy")
            {
                result = amount * (decimal)selected.ask;
                Console.WriteLine($"\nBUYING {amount} {selectedCode} → You pay {result:F2} PLN (ask = {selected.ask})");
            }
            else
            {
                Console.WriteLine("Invalid direction. Please enter 'buy' or 'sell'.");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

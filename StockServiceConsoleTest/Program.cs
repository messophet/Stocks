using System;
using StockService;
using StockServiceShared.Interfaces;

namespace StockServiceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            StockService.StockService stockService = new StockService.StockService();
            stockService.PriceChanged += HandlePriceChanged;

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void HandlePriceChanged(object sender, PriceChangedEventArgs e)
        {
            Console.WriteLine($"Stock: {e.Stock}, Old Price: {e.OldPrice}, New Price: {e.NewPrice}");
        }
    }
}
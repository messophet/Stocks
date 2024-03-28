using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using StockServiceShared.Interfaces;
using StockServiceShared.Models;

namespace StockService
{
    public class StockService : IStockService
    {
        private readonly IDictionary<string, List<IStockClient>> subscribers = new ConcurrentDictionary<string, List<IStockClient>>();
        private IDictionary<string, StockModel> currentPrices = new ConcurrentDictionary<string, StockModel>();
        private Random random = new Random();

        public event EventHandler<PriceChangedEventArgs> PriceChanged;

        public StockService()
        {
            // Initialize price history for each stock with initial prices
            currentPrices["Stock1"] = new StockModel("Stock1", GetRandomPrice(240, 270));
            currentPrices["Stock2"] = new StockModel("Stock2", GetRandomPrice(180, 210));

            PriceChanged += (sender, e) => { };

            BeginUpdatingPrices();
        }

        private void BeginUpdatingPrices()
        {
            // Start the async price update method on a background thread
            Task.Run(async () => await UpdatePricesAsync());
        }

        private async Task UpdatePricesAsync()
        {
            while (true)
            {
                // Simulate price changes
                foreach (var stock in currentPrices.Keys.ToList()) // ToList to avoid collection modified exception
                {
                    // Should return a promise instead, and await on the client
                    var stockModel = currentPrices[stock];
                    double newPrice = GetNextPrice(stockModel.Price, stock);
                    stockModel.UpdatePrice(newPrice); c

                    // Notify subscribers of the price change
                    NotifySubscribers(stock, stockModel.PreviousPrice, newPrice); // Assuming NotifySubscribers can be async
                }

                await Task.Delay(1000); // Asynchronously wait, freeing up the thread
            }
        }
        
        private double GetNextPrice(double currentPrice, string stock)
        {
            // Simulate price movement
            double change = random.NextDouble() * 2 - 1; // +/-1 change

            double newPrice = currentPrice + change;

            if (stock == "Stock1")
            {
                // If the current price is within the bounds of Stock1
                if (newPrice < 240)
                    newPrice = 240;
                else if (newPrice > 270)
                    newPrice = 270;
            }
            else if (stock == "Stock2")
            {
                // If the current price is within the bounds of Stock2
                if (newPrice < 180)
                    newPrice = 180;
                else if (newPrice > 210)
                    newPrice = 210;
            }

            return Math.Round(newPrice, 2); // Round to 2 decimal places
        }

        private void NotifySubscribers(string stock, double oldPrice, double newPrice)
        {
            if (subscribers.ContainsKey(stock))
            {
                var updatedStock = new StockModel(stock, newPrice);

                updatedStock.PreviousPrice = oldPrice;

                foreach (var client in subscribers[stock])
                {
                    client.UpdatePrice(updatedStock);
                }
            }
        }

        public void SubscribeToStock(string stock, IStockClient client)
        {
            if (!subscribers.ContainsKey(stock))
                subscribers[stock] = new List<IStockClient>();

            if (!subscribers[stock].Contains(client))
                subscribers[stock].Add(client);
        }

        public void UnsubscribeFromStock(string stock, IStockClient client)
        {
            if (subscribers.ContainsKey(stock) && subscribers[stock].Contains(client))
            {
                subscribers[stock].Remove(client);
            }
        }

        private double GetRandomPrice(double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }

        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            PriceChanged?.Invoke(this, e);
        }

    }
}

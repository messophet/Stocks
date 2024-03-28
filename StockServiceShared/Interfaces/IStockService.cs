using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockServiceShared.Interfaces
{
    public interface IStockService
    {
        event EventHandler<PriceChangedEventArgs> PriceChanged;
        void SubscribeToStock(string stock, IStockClient client);
        void UnsubscribeFromStock(string stock, IStockClient client);
    }

    public class PriceChangedEventArgs : EventArgs
    {
        public string Stock { get; }
        public double OldPrice { get; }
        public double NewPrice { get; }

        public PriceChangedEventArgs(string stock, double oldPrice, double newPrice)
        {
            Stock = stock;
            OldPrice = oldPrice;
            NewPrice = newPrice;
        }
    }
}

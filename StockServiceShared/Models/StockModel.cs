using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockServiceShared.Models
{
    public class StockModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double PreviousPrice { get; set; }

        public string PriceDirection => (Price - PreviousPrice) switch
        {
            > 0 => "↑",
            < 0 => "↓",
            _ => "→"
        };

        public DateTime LastUpdated { get; set; } // Timestamp of the last update
        
        public StockModel(string name, double price)
        {
            Name = name;
            Price = price;
            LastUpdated = DateTime.Now; // Initialize with the current time
        }

        public void UpdatePrice(double newPrice)
        {
            PreviousPrice = Price;
            Price = newPrice;
            LastUpdated = DateTime.Now;
        }
    }
}

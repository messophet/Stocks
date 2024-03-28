using System.Collections.ObjectModel;

namespace StocksWPF.ViewModel
{
    public class PriceHistoryWindowViewModel
    {
        public string StockName { get; set; }
        public ObservableCollection<PriceHistoryEntry> PriceHistory { get; set; }
    }
}
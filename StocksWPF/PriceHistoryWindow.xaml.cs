using StocksWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StocksWPF
{
    /// <summary>
    /// Interaction logic for PriceHistoryWindow.xaml
    /// </summary>
    public partial class PriceHistoryWindow : Window
    {
        public PriceHistoryWindow(string stockName, ObservableCollection<PriceHistoryEntry> priceHistory)
        {
            InitializeComponent();
            DataContext = new PriceHistoryWindowViewModel
            {
                StockName = stockName,
            };
            priceHistoryDataGrid.ItemsSource = priceHistory;
        }
    }
}

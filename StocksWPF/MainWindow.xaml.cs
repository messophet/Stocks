using StockServiceShared.Interfaces;
using StockServiceShared.Models;
using StocksWPF.ViewModel;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StocksWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IStockClient
    {
        private IStockService _stockService;
        public ObservableCollection<StockViewModel> SubscribedStocks { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            SubscribedStocks = new ObservableCollection<StockViewModel>();
            _stockService = App.StockService;
            DataContext = this;
        }

        private void SubscribeButton_Click(object sender, RoutedEventArgs e)
        {
            var stockName = stockTickerTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(stockName) && !SubscribedStocks.Any(s => s.Name == stockName))
            {
                _stockService.SubscribeToStock(stockName, this);

                // Example stock subscription
                SubscribedStocks.Add(new StockViewModel
                {
                    Name = stockName,
                    Price = "0",
                    PriceDirectionSymbol = "↑",
                    PriceDirectionColor = Brushes.Green,
                    UnsubscribeCommand = new RelayCommand(() => UnsubscribeStock(stockName))
                });
            }
        }

        private void UnsubscribeStock(string stockName)
        {
            var stockToRemove = SubscribedStocks.FirstOrDefault(s => s.Name == stockName);
            if (stockToRemove != null)
            {
                SubscribedStocks.Remove(stockToRemove);
            }
        }

        public void UpdatePrice(StockModel updatedStock)
        {
            Dispatcher.Invoke(() =>
            {
                var stockToUpdate = SubscribedStocks.FirstOrDefault(s => s.Name == updatedStock.Name);
                if (stockToUpdate != null)
                {
                    // Parse the current price before updating it
                    double currentPrice = double.Parse(stockToUpdate.Price);

                    // Determine the direction of the price update
                    var direction = updatedStock.Price > currentPrice ? "↑" :
                                    updatedStock.Price < currentPrice ? "↓" : "→";

                    // Determine the brush based on the price direction
                    var directionBrush = updatedStock.Price > currentPrice ? Brushes.Green :
                                         updatedStock.Price < currentPrice ? Brushes.Red : Brushes.Black;

                    // Update the stock's price and direction symbol
                    stockToUpdate.Price = updatedStock.Price.ToString("F2");
                    stockToUpdate.PriceDirectionSymbol = direction;
                    stockToUpdate.PriceDirectionColor = directionBrush; // Make sure this property triggers OnPropertyChanged

                    // Add the update to the price history
                    stockToUpdate.PriceHistory.Add(new PriceHistoryEntry(updatedStock.LastUpdated, updatedStock.Price, direction, directionBrush));
                }
            });
        }

        private void ItemsControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Example of determining the clicked item
            var item = (sender as ItemsControl).ContainerFromElement((DependencyObject)e.OriginalSource) as FrameworkElement;
            if (item != null && item.DataContext is StockViewModel stock)
            {
                PriceHistoryWindow priceHistoryWindow = new PriceHistoryWindow(stock.Name, stock.PriceHistory);
                priceHistoryWindow.Show();
            }
        }

        public class RelayCommand : ICommand
        {
            private Action _execute;

            public RelayCommand(Action execute)
            {
                _execute = execute;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                _execute();
            }
        }
    }
}
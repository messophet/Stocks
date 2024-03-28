using StockServiceShared.Interfaces;
using System.Configuration;
using System.Data;
using System.Windows;

namespace StocksWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 
   
    public partial class App : Application
    {
        public static IStockService? StockService { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialize your service here
            StockService = new StockService.StockService(); // Or any other IStockService implementation
        }
    }

}

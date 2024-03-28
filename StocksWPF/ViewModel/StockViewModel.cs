using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace StocksWPF.ViewModel
{
    public class PriceHistoryEntry
    {
        public DateTime Time { get; set; }
        public double Price { get; set; }
        public string PriceDirection { get; set; }
        public Brush DirectionBrush { get; set; }

        public PriceHistoryEntry(DateTime time, double price, string priceDirection, Brush directionBrush)
        {
            Time = time;
            Price = price;
            PriceDirection = priceDirection;
            DirectionBrush = directionBrush;
        }
    }

    public class StockViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _price;
        private string _priceDirectionSymbol;
        private Brush _priceDirectionColor;
        private ICommand _unsubscribeCommand;


        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<PriceHistoryEntry> PriceHistory { get; } = new ObservableCollection<PriceHistoryEntry>();

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }

        public string PriceDirectionSymbol
        {
            get => _priceDirectionSymbol;
            set
            {
                if (_priceDirectionSymbol != value)
                {
                    _priceDirectionSymbol = value;
                    OnPropertyChanged(nameof(PriceDirectionSymbol));
                }
            }
        }

        public Brush PriceDirectionColor
        {
            get => _priceDirectionColor;
            set
            {
                if (_priceDirectionColor != value)
                {
                    _priceDirectionColor = value;
                    OnPropertyChanged(nameof(PriceDirectionColor));
                }
            }
        }

        public ICommand UnsubscribeCommand
        {
            get => _unsubscribeCommand;
            set
            {
                if (_unsubscribeCommand != value)
                {
                    _unsubscribeCommand = value;
                    OnPropertyChanged(nameof(UnsubscribeCommand));
                }
            }
        }
    }
}

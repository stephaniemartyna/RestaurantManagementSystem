using Microsoft.Maui.Controls;
using RestaurantManagementSystem.Models;
using System.Collections.ObjectModel;
using MenuItem = RestaurantManagementSystem.Models.MenuItem;
using System.Linq;
using System.ComponentModel;

namespace RestaurantManagementSystem
{
    /// <summary>
    /// Name : Kihyun Kim, Daniel Barbieri, Stephanie Martyna, James Bryan Bareng
    /// Date : 24 Apr 2023
    /// Description : Initializes Sales page and components
    /// </summary>
    /// 
    public partial class SalesPage : ContentPage, INotifyPropertyChanged
    {
        private ObservableCollection<SalesItem> _salesItems;

        public double _totalSalesPrice;

        public class SalesItem
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public int QuantitySold { get; set; }
            public double TotalSalesAmount => Price * QuantitySold;

            public SalesItem(string name, double price, int quantitySold)
            {
                Name = name;
                Price = price;
                QuantitySold = quantitySold;
            }
        }

        public double TotalSalesPrice
        {
            get { return _totalSalesPrice; }
            set
            {
                _totalSalesPrice = value;
                OnPropertyChanged(nameof(TotalSalesPrice));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SalesPage()
        {
            InitializeComponent();
            _salesItems = new ObservableCollection<SalesItem>();
            BindingContext = this;
            UpdateSalesItems();

            var purchasedSaleItems = PurchasedList.PurchasedItems
                .GroupBy(item => item.Name)
                .Select(group => new SalesItem(group.Key, group.First().Price, group.Count()))
                .ToList();

            _salesItems = new ObservableCollection<SalesItem>(purchasedSaleItems);

            SalesListView.ItemsSource = _salesItems;
        }
        public void UpdateSalesItems()
        {
            var purchasedSaleItems = PurchasedList.PurchasedItems
                .GroupBy(item => item.Name)
                .Select(group => new SalesItem(group.Key, group.First().Price, group.Count()))
                .ToList();

            _salesItems.Clear();
            foreach (var item in purchasedSaleItems)
            {
                _salesItems.Add(item);
            }

            TotalSalesPrice = purchasedSaleItems.Sum(item => item.TotalSalesAmount);
        }
    }
}
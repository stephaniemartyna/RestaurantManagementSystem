using RestaurantManagementSystem;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using MenuItem = RestaurantManagementSystem.Models.MenuItem;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem
{
    /// <summary>
    /// Name : Kihyun Kim, Daniel Barbieri, Stephanie Martyna, James Bryan Bareng
    /// Date : 24 Apr 2023
    /// Description : Initializes Menu page and components
    /// </summary>
    /// 
    public partial class MenuPage : ContentPage
    {
        public ObservableCollection<MenuItem> SelectedItems { get; set; }
        public ObservableCollection<MenuItem> MenuItems { get; set; }
        public double TotalAmount => SelectedItems.Sum(item => item.Price);

        public MenuPage()
        {
            InitializeComponent();
            MenuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem { Name = "Burger and Fries", Price = 10.99},
                new MenuItem { Name = "Pork back-ribs", Price = 15.99},
                new MenuItem { Name = "Chicken Nuggets", Price = 8.99},
                new MenuItem { Name = "Tacos", Price = 12.99},
                new MenuItem { Name = "Pizza", Price = 15.99},
                new MenuItem { Name = "Coca-Cola", Price = 2.99},
                new MenuItem { Name = "Coffee", Price = 3.99},
                new MenuItem { Name = "Water", Price = 2.99},
            };

            SelectedItems = new ObservableCollection<MenuItem>();
            checkoutItemsListView.ItemsSource = SelectedItems;

            PurchasedList.PurchasedItems = new List<MenuItem>();
        }

        /// <summary>
        /// Add menu item to checkout list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                string menuItemName = clickedButton.Text;
                MenuItem menuItem = MenuItems.FirstOrDefault(item => item.Name == menuItemName);
                if (menuItem != null)
                {
                    SelectedItems.Add(menuItem);

                    // Update the TotalAmount whenever an item is added
                    UpdateTotalAmount();
                }
            }
        }

        /// <summary>
        /// Delete item from checkout list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteItemButton_Clicked(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                MenuItem menuItemToDelete = clickedButton.CommandParameter as MenuItem;
                if (menuItemToDelete != null)
                {
                    SelectedItems.Remove(menuItemToDelete);

                    // Update the TotalAmount whenever an item is deleted
                    UpdateTotalAmount();
                }
            }
        }

        /// <summary>
        /// Updates total amoutn everytime item is added
        /// </summary>
        private void UpdateTotalAmount()
        {
            TotalAmountLabel.Text = $"Total Amount: {TotalAmount:C}";
        }

        /// <summary>
        /// Successfull pop up, and updates Sales page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ConfirmOrderButton_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Order Confirmation", "Successfully placed your order!", "OK");

            // Update purchased items list
            foreach (MenuItem menuItem in SelectedItems)
            {
                PurchasedList.PurchasedItems.Add(new MenuItem { Name = menuItem.Name, Price = menuItem.Price });
            }

            // Clear selected items and update total amount
            SelectedItems.Clear();
            UpdateTotalAmount();

            // Navigate to table page
            AppShell.TabBarStatic.CurrentItem = AppShell.TablePageStatic;

            // Update order list view
            await RefreshOrderListView();

            // Refresh the sales list view
            await RefreshSalesListView();
        }

        /// <summary>
        /// Updates order list
        /// </summary>
        /// <returns></returns>
        private async Task RefreshOrderListView()
        {
            // Get order list view from the table page
            var tablePage = AppShell.SalesPageStatic;
            var orderListView = tablePage.FindByName<ListView>("OrderListView");

            if (orderListView != null)
            {
                if (PurchasedList.PurchasedItems == null)
                {
                    PurchasedList.PurchasedItems = new List<MenuItem>();
                }

                // Update order list view
                orderListView.ItemsSource = null;
                orderListView.ItemsSource = PurchasedList.PurchasedItems.ToList();
            }
        }

        /// <summary>
        /// Update Sales list 
        /// </summary>
        /// <returns></returns>
        private async Task RefreshSalesListView()
        {
            // Get the sales page
            var salesPageShellContent = AppShell.SalesPageStatic;
            var salesPage = salesPageShellContent.Content as SalesPage;

            if (salesPage != null)
            {
                // Update the sales list view
                salesPage.UpdateSalesItems();
            }
        }
    }
}

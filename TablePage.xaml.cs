using RestaurantManagementSystem;
using Microsoft.Maui.Controls;

namespace RestaurantManagementSystem;
/// <summary>
/// Name : Kihyun Kim, Daniel Barbieri, Stephanie Martyna, James Bryan Bareng
/// Date : 24 Apr 2023
/// Description : Initializes Table page and components
/// </summary>

public partial class TablePage : ContentPage
{
    public TablePage()
    {
        InitializeComponent();
    }


    //Pop up with amount of customers when table clicked, navigates to Menu page
    private async void TableClicked(Object sender, EventArgs e)
    {
        string guests = await DisplayPromptAsync("Guests", "How many guests are there for this table?");
        if (!string.IsNullOrEmpty(guests))
        {
            //await Navigation.PushAsync(new MenuPage());
            AppShell.TabBarStatic.CurrentItem = AppShell.MenuPageStatic;
        }
    }


    //Navigation to take out page
    private async void TakeOutButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TakeoutPage());
    }
}
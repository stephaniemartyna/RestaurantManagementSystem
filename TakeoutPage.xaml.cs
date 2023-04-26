using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
using System.Threading.Tasks;

namespace RestaurantManagementSystem;
/// <summary>
/// Name : Kihyun Kim, Daniel Barbieri, Stephanie Martyna, James Bryan Bareng
/// Date : 24 Apr 2023
/// Description : Initializes Takeout  page and components
/// </summary>

public partial class TakeoutPage : ContentPage
{
    public string CustomerName { get; set; }
    public string PhoneNumber { get; set; }

    public TakeoutPage()
    {
        InitializeComponent();
    }


    //Takeout number clicked
    private async void Takeout_tableClicked(Object sender, EventArgs e)
    {
        await PrompCustomerInfo();
    }


    //Prompts for customer information to be entered
    private async Task PrompCustomerInfo()
    {
        // get customer name information
        string name = await DisplayPromptAsync("Customer Name : ", "Please enter customer name.");

        if (!string.IsNullOrEmpty(name))
        {
            // get customer phone number information
            string phone = await DisplayPromptAsync("Customer Phone Number: ", "Please enter customer phone number");

            if (!string.IsNullOrEmpty(phone))
            {
                CustomerName = name;
                PhoneNumber = phone;

                AppShell.TabBarStatic.CurrentItem = AppShell.MenuPageStatic;
            }
        }
    }


    //Loads new Takeout page
    private async void TakeOutButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TakeoutPage());
    }


    //Navigates back to Dine In page
    private async void DineIn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}




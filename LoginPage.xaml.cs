using System.Data;
using System.Runtime.CompilerServices;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using Microsoft.Maui.Controls;
using MySqlConnector;
using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.Exceptions;
using System.Security.Authentication;

namespace RestaurantManagementSystem;
/// <summary>
/// Name : Kihyun Kim, Daniel Barbieri, Stephanie Martyna, James Bryan Bareng
/// Date : 24 Apr 2023
/// Description : Initializing login page and components
/// </summary>

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }


    //Authenticate user credentials
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // User input "Employee ID" and "Password"
        string employeeId = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        bool isAuthenticated = await AuthenticateUser(employeeId, password);

        // If the login is successful, go to the table page.
        if (isAuthenticated)
        {
            AppShell.TabBarStatic.CurrentItem = AppShell.TablePageStatic;
        }
        else
        {
            await DisplayAlert("Failed, Login", "Invalid Employee ID or Password", "Check");
        }
    }


    /// <summary>
    /// Add New User to the database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="AuthenticationException"></exception>
    private async void OnAddUserClicked(object sender, System.EventArgs e)
    {
        // User input "Employee ID" and "Password"
        string employeeId = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        bool isAuthenticated = await AuthenticateUser(employeeId, password);

        if (isAuthenticated)
        {
            string newUserID = await DisplayPromptAsync("New User", "Enter new user's userID");
            string newPassword = await DisplayPromptAsync("New User", "Enter new user's password");
            string newfName = await DisplayPromptAsync("New User", "Enter new user's first name");
            string newlName = await DisplayPromptAsync("New User", "Enter new user's last name");

            if (!string.IsNullOrEmpty(newUserID) && !string.IsNullOrEmpty(newPassword))
            {
                // Create a new connection to the database
                using var connection = new MySqlConnection("Server=localhost;User ID=root;Password=password;Database=finalprojectdb");
                try
                {
                    //Open the connection to the database
                    await connection.OpenAsync();
                }
                catch (Exception ex)
                {
                    // If an exception is thrown while connecting to the database, wrap it in an AuthenticationException and re-throw it
                    throw new AuthenticationException("Error connecting to the database", ex);
                }
                // Create a new command to execute against the database
                using var command = new MySqlCommand("INSERT INTO employee (employeeId, password, fName, lName) VALUES (@employeeId, @password, @fName, @lName)", connection);
                command.Parameters.AddWithValue("@employeeId", newUserID);
                command.Parameters.AddWithValue("@password", newPassword);
                command.Parameters.AddWithValue("@fName", newfName);
                command.Parameters.AddWithValue("@lName", newlName);
                await command.ExecuteNonQueryAsync();
                await DisplayAlert("Success", "User " + (newUserID) + " added", "OK");
            }
        }
        else
        {
            await DisplayAlert("Failed, Login", "Invalid Employee ID or Password", "Check");
        }
    }


    /// <summary>
    /// Delete User to the database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="AuthenticationException"></exception>
    private async void OnDeleteUserClicked(object sender, System.EventArgs e)
    {
        // User input "Employee ID" and "Password"
        string employeeId = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        bool isAuthenticated = await AuthenticateUser(employeeId, password);

        if (isAuthenticated)
        {
            string userToDelete = await DisplayPromptAsync("Delete User", "Enter user's userID to delete");

            if (userToDelete != null)
            {
                // Create a new connection to the database
                using var connection = new MySqlConnection("Server=localhost;User ID=root;Password=password;Database=finalprojectdb");
                try
                {
                    //Open the connection to the database
                    await connection.OpenAsync();
                }
                catch (Exception ex)
                {
                    // If an exception is thrown while connecting to the database, wrap it in an AuthenticationException and re-throw it
                    throw new AuthenticationException("Error connecting to the database", ex);
                }
                // Create a new command to execute against the database
                using var command = new MySqlCommand("DELETE FROM employee WHERE employeeId = @employeeId", connection);
                command.Parameters.AddWithValue("@employeeId", userToDelete);
                await command.ExecuteNonQueryAsync();
                await DisplayAlert("Success", "User " + (userToDelete) + " deleted", "OK");
            }
        }
        else
        {
            await DisplayAlert("Failed, Login", "Invalid Employee ID or Password", "Check");
        }
    }


    /// <summary>
    /// Edit User to the database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="AuthenticationException"></exception>
    private async void OnEditUserClicked(object sender, System.EventArgs e)
    {
        // User input "Employee ID" and "Password"
        string employeeId = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        bool isAuthenticated = await AuthenticateUser(employeeId, password);

        if (isAuthenticated)
        {
            string userToEdit = await DisplayPromptAsync("Enter a userID to edit", "Enter userID to edit");
            string newUserID = await DisplayPromptAsync("Editing user" + (userToEdit), "Enter new user's userID");
            string newPassword = await DisplayPromptAsync("Editing user" + (userToEdit), "Enter new user's password");
            string newfName = await DisplayPromptAsync("Editing user" + (userToEdit), "Enter new user's first name");
            string newlName = await DisplayPromptAsync("Editing user" + (userToEdit), "Enter new user's last name");

            if (!string.IsNullOrEmpty(newUserID) && !string.IsNullOrEmpty(newPassword))
            {
                // Create a new connection to the database
                using var connection = new MySqlConnection("Server=localhost;User ID=root;Password=password;Database=finalprojectdb");
                try
                {
                    //Open the connection to the database
                    await connection.OpenAsync();
                }
                catch (Exception ex)
                {
                    // If an exception is thrown while connecting to the database, wrap it in an AuthenticationException and re-throw it
                    throw new AuthenticationException("Error connecting to the database", ex);
                }
                // Create a new command to execute against the database
                using var command = new MySqlCommand("UPDATE employee SET employeeId = @newUserID, password = @newPassword, fName = @newfName, lName = @newlName WHERE employeeId = @userToEdit", connection);
                command.Parameters.AddWithValue("@newUserID", newUserID);
                command.Parameters.AddWithValue("@newPassword", newPassword);
                command.Parameters.AddWithValue("@newfName", newfName);
                command.Parameters.AddWithValue("@newlName", newlName);
                command.Parameters.AddWithValue("@userToEdit", userToEdit);
                await command.ExecuteNonQueryAsync();
                await DisplayAlert("Success", "User " + (userToEdit) + " has been edited", "OK");
            }
        }
        else
        {
            await DisplayAlert("Failed, Login", "Invalid Employee ID or Password", "Check");
        }
    }


    /// <summary>
    /// Authenticates username and password from the database.
    /// </summary>
    /// <param name="employeeId"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    private async Task<bool> AuthenticateUser(string employeeId, string password)
    {
        // Create a new connection to the database
        using var connection = new MySqlConnection("Server=localhost;User ID=root;Password=password;Database=finalprojectdb");

        try
        {
            //Open the connection to the database
            await connection.OpenAsync();
        }
        catch (Exception ex)
        {
            // If an exception is thrown while connecting to the database, wrap it in an AuthenticationException and re-throw it
            throw new AuthenticationException("Error connecting to the database", ex);
        }
        // Create a new command to execute against the database
        using var command = new MySqlCommand("SELECT employeeId, password FROM employee WHERE employeeId = @employeeId AND password = @password", connection);

        command.Parameters.AddWithValue("@employeeId", employeeId);
        command.Parameters.AddWithValue("@password", password);

        using var reader = await command.ExecuteReaderAsync();

        if (reader.Read())
        {
            // Receive data from reader
            var dbEmployeeID = reader["employeeId"].ToString();
            var dbPassword = reader["password"].ToString();

            if (dbEmployeeID == employeeId && dbPassword == password)
            {
                return true;
            }
        }
        return false;
    }
}
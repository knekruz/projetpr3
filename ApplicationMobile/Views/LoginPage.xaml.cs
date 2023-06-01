using ApplicationMobile.Services;
using ApplicationMobile.Models;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace ApplicationMobile.Views
{
    public partial class LoginPage : ContentPage
    {
        private readonly ApiService _apiService;
        private readonly UserService _userService;

        public LoginPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
            _userService = new UserService();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var email = emailEntry.Text;
                var password = passwordEntry.Text;

                var token = await _apiService.Login(email, password);

                if (!string.IsNullOrEmpty(token))
                {
                    // The student logged in successfully, save the token and navigate to HomePage
                    await _userService.SetTokenAsync(token);
                    await _userService.SetEmailAsync(email);
                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    // Show a message to the user that login failed
                    await DisplayAlert("Login Failed", "Invalid email or password, please try again.", "OK");
                }
            }
            catch (Exception ex)
            {
                // An error occurred, show a message to the user
                await DisplayAlert("Login Failed", "An error occurred, please try again. " + ex.Message, "OK");
            }
        }
    }
}

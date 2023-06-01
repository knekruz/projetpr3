using System;
using ApplicationMobile.Services;
using ApplicationMobile.Models;
using Microsoft.Maui.Controls;

namespace ApplicationMobile.Views
{
    public partial class HomePage : ContentPage
    {
        private readonly UserService _userService;
        private readonly ApiService _apiService;

        public HomePage()
        {
            InitializeComponent();
            DependencyService.Register<UserService>();
            _userService = new UserService();
            _apiService = new ApiService();
            LoadStudent();
        }

        private async void LoadStudent()
        {
            try
            {
                var studentEmail = await _userService.GetEmailAsync();

                var student = await _apiService.GetStudentByEmail(studentEmail);

                if (student != null)
                {
                    WelcomeLabel.Text += $"{student.Name} {student.LastName}";
                    await _userService.SetStudentAsync(student);
                }
            }
            catch (Exception ex)
            {
                // Log the error or show a message to the user
            }
        }
    }
}

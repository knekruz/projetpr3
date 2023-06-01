using System;
using System.Windows.Forms;
using ApplicationDesktop.Services;
using ApplicationDesktop.Models;

namespace ApplicationDesktop
{
    public partial class LoginPage : Form
    {
        private readonly ApiService _apiService;

        public LoginPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var email = txtUsername.Text;
            var password = txtPass.Text;

            var adminDTO = new AdminDTO
            {
                Username = email,
                Password = password
            };

            var tokenResponse = await _apiService.LoginAdminAsync(adminDTO);

            if (tokenResponse != null && !string.IsNullOrEmpty(tokenResponse.Token))
            {
                // Successful login. Hide LoginPage and show HomePage
                this.Hide();
                var homePage = new HomePage();
                homePage.Show();
            }
            else
            {
                // Failed login. You might want to show an error message here.
            }
        }

    }
}

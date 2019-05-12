using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Okta.Auth.Sdk;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChuckNorrisFacts2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentView
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private async void LoginClicked(object sender, EventArgs e)
        {
            var success = await OktaApiAccess.Login(EmailEntry.Text, PasswordEntry.Text);
            if (LoginChanged != null) LoginChanged(this, success);
            if (success)
            {
                LoginPanel.IsVisible = false;
                LogoutPanel.IsVisible = true;
                ErrorLabel.Text = "";
            }
            else
            {
                ErrorLabel.Text = "Login failed.";
            }
        }

        private void SignupClicked(object sender, EventArgs e)
        {

        }
        private void LogoutClicked(object sender, EventArgs e)
        {
            LoginPanel.IsVisible = true;
            LogoutPanel.IsVisible = false;
        }

        public event EventHandler<bool> LoginChanged;
    }
}
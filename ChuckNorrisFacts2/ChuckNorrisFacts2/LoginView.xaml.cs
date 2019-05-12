using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private void LoginClicked(object sender, EventArgs e)
        {
            new OktaApiAccess();
        }

        private void SignupClicked(object sender, EventArgs e)
        {

        }
    }
}
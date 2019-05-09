using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChuckNorrisFacts2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var client = new RestClient("https://api.chucknorris.io");
            var request = new RestRequest("/jokes/random?category=explicit", Method.GET);
            IRestResponse response = client.Execute(request);
            var fact = JsonConvert.DeserializeObject<Fact>(response.Content);
            MyLabel.Text = fact.value;
        }
    }
}

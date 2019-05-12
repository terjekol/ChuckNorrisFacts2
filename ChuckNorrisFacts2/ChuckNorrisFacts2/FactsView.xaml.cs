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
    public partial class FactsView : ContentView
    {
        private List<string> _categories;
        private List<string> _favorites;
        private Random _random;
        private FactsApiAccess _access;

        public FactsView()
        {
            InitializeComponent();

            _random = new Random();
            _favorites = new List<string>();
            _categories = new List<string>();
            _categories.Add("Random");
            _access = new FactsApiAccess();
            var categories = _access.GetCategories();
            _categories.AddRange(categories);
            CategoryPicker.ItemsSource = _categories;
            CategoryPicker.SelectedIndex = 0;
        }

        private void GetFavoriteClicked(object sender, EventArgs e)
        {
            FactLabel.Text = _favorites.Count == 0 ? "You have no favorites yet." : GetRandomFavorite();
        }
        private void GetFactClicked(object sender, EventArgs e)
        {
            var isRandom = CategoryPicker.SelectedIndex == 0;
            FactLabel.Text = _access.GetFact(isRandom ? null : CategoryPicker.SelectedItem.ToString());
        }

        private string GetRandomFavorite()
        {
            return _favorites[_random.Next(0, _favorites.Count)];
        }

        private void AddFavoriteClicked(object sender, EventArgs e)
        {
            _favorites.Add(FactLabel.Text);
        }

        public void HandleLoginChanged(bool isLoggedIn)
        {
            AddFavoriteButton.IsEnabled = GetFavoriteButton.IsEnabled = isLoggedIn;
        }
    }
}
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
            _categories.Add("Favorites");
            _access = new FactsApiAccess();
            var categories = _access.GetCategories();
            _categories.AddRange(categories);
            CategoryPicker.ItemsSource = _categories;
            CategoryPicker.SelectedIndex = 0;
        }

        private void GetFactClicked(object sender, EventArgs e)
        {
            var categoryIndex = CategoryPicker.SelectedIndex;
            if (categoryIndex == 1)
                FactLabel.Text = _favorites.Count == 0 ? "You have no favorites yet." : GetRandomFavorite();
            else
                FactLabel.Text = _access.GetFact(categoryIndex == 0 ? null : _favorites[categoryIndex]);
        }

        private string GetRandomFavorite()
        {
            return _favorites[_random.Next(0, _favorites.Count)];
        }

        private void SaveFavoriteClicked(object sender, EventArgs e)
        {

        }

    }
}
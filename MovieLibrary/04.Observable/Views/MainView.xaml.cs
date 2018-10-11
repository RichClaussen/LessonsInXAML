using System.Windows;

using MovieLibrary.ViewModels;

namespace MovieLibrary.Views
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void OnAddButtonClicked(object sender, RoutedEventArgs e)
        {
            (this.DataContext as MainViewModel).AddMovies();
        }

        private void OnChangeButtonClicked(object sender, RoutedEventArgs e)
        {
            (this.DataContext as MainViewModel).ChangeMovies();
        }
    }
}
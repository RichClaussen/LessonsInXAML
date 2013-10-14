using System.Windows;

using MovieLibrary.ViewModels;

namespace MovieLibrary.Views
{
    public partial class MainView : Window
    {
        private MainViewModel ViewModel
        {
            get { return DataContext as MainViewModel; }
        }

        public MainView()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void OnButtonClicked(object sender, RoutedEventArgs e)
        {
            this.ViewModel.AddMovies();
        }
    }
}
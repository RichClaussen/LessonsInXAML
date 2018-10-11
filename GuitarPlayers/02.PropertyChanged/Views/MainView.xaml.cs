using System.Windows;

using GuitarPlayers.ViewModels;

namespace GuitarPlayers.Views
{
    public partial class MainView : Window
    {
        private MainViewModel TypedDataContext
        {
            get { return DataContext as MainViewModel; }
        }

        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void OnSortByNameClicked(object sender, RoutedEventArgs e)
        {
            TypedDataContext.SortByName();
        }

        private void OnSortByAgeClicked(object sender, RoutedEventArgs e)
        {
            TypedDataContext.SortByBirthYear();
        }

        private void OnOriginalGuitarPlayersClicked(object sender, RoutedEventArgs e)
        {
            TypedDataContext.SortByOriginal();
        }
    }
}

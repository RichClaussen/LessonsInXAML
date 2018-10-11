using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

using GuitarPlayers.Models;

namespace GuitarPlayers.Views
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

            GuitarPlayers = new ObservableCollection<GuitarPlayer>(GuitarPlayerCollection.Players);

            DataContext = this;
        }

        public ObservableCollection<GuitarPlayer> GuitarPlayers { get; set; }

        private void OnSortByNameClicked(object sender, RoutedEventArgs e)
        {
            this.UpdateGuitarPlayers(GuitarPlayerCollection.Players.OrderBy(player => player.Name));
        }

        private void OnSortByAgeClicked(object sender, RoutedEventArgs e)
        {
            this.UpdateGuitarPlayers(GuitarPlayerCollection.Players.OrderBy(player => player.YearOfBirth));
        }

        private void OnOriginalGuitarPlayersClicked(object sender, RoutedEventArgs e)
        {
            this.UpdateGuitarPlayers(GuitarPlayerCollection.Players);
        }

        private void UpdateGuitarPlayers(IEnumerable<GuitarPlayer> guitarPlayers)
        {
            GuitarPlayers.Clear();
            guitarPlayers.ToList().ForEach(gp => GuitarPlayers.Add(gp));
        }
    }
}

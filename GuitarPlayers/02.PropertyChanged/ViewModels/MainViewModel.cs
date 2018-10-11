using System.Collections.ObjectModel;
using System.Linq;

using GuitarPlayers.Models;

namespace GuitarPlayers.ViewModels
{
    public class MainViewModel : NotifyPropertyChanged
    {
        private ObservableCollection<GuitarPlayer> guitarPlayers;
        public ObservableCollection<GuitarPlayer> GuitarPlayers
        {
            get { return guitarPlayers; }
            private set
            {
                guitarPlayers = value;
                this.OnPropertyChanged(() => GuitarPlayers);
            }
        }

        public MainViewModel()
        {
            this.SortByOriginal();
        }

        public void SortByName()
        {
            GuitarPlayers = new ObservableCollection<GuitarPlayer>(GuitarPlayerCollection.Players.OrderBy(p => p.Name));
        }

        public void SortByBirthYear()
        {
            GuitarPlayers = new ObservableCollection<GuitarPlayer>(GuitarPlayerCollection.Players.OrderBy(p => p.YearOfBirth));
        }

        public void SortByOriginal()
        {
            GuitarPlayers = new ObservableCollection<GuitarPlayer>(GuitarPlayerCollection.Players);
        }
    }
}

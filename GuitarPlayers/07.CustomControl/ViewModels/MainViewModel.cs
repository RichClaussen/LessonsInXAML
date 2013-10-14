using System.Collections.ObjectModel;
using System.Linq;

using GuitarPlayers.Models;

namespace GuitarPlayers.ViewModels
{
    public class MainViewModel : NotifyPropertyChanged
    {
        private ObservableCollection<GuitarPlayerViewModel> guitarPlayers;
        public ObservableCollection<GuitarPlayerViewModel> GuitarPlayers
        {
            get { return guitarPlayers; }
            private set
            {
                guitarPlayers = value;
                this.OnPropertyChanged(() => GuitarPlayers);
            }
        }

        public string Title { get { return "Guitar Players - Custom Control"; } }

        public SortButtonsViewModel<OrderBy> SortButtons { get; private set; }

        public MainViewModel()
        {
            SortButtons = new SortButtonsViewModel<OrderBy>();
            SortButtons.SortOrderChanged += Sort;

            GuitarPlayers = new ObservableCollection<GuitarPlayerViewModel>(
                GuitarPlayerCollection.Players.Select(p => new GuitarPlayerViewModel(p)));
        }

        private void Sort(object obj, SortOrderChangedEventArgs<OrderBy> e)
        {
            GuitarPlayers = new ObservableCollection<GuitarPlayerViewModel>(GuitarPlayers.OrderBy(p => this.SortValue(p, e.SortOrder)));
        }

        private object SortValue(GuitarPlayerViewModel player, OrderBy orderBy)
        {
            switch (orderBy)
            {
                case OrderBy.Id:
                    return player.Id;
                case OrderBy.Name:
                    return player.LastName;
                case OrderBy.Age:
                    return player.YearOfBirth;
                default:
                    return null;
            }
        }
    }
}

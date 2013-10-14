using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using GuitarPlayers.Models;

namespace GuitarPlayers.ViewModels
{
    public class MainViewModel : CultureAwareViewModelBase
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

        public ICommand CultureChangeCommand { get; private set; }

        public SortButtonsViewModel<OrderBy> SortButtons { get; private set; }

        public MainViewModel()
        {
            CultureChangeCommand = new Command
            {
                CanExecuteDelegate = x => true,
                ExecuteDelegate = x => this.CascadeCultureChange(x.ToString()),
            };

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

        private void CascadeCultureChange(string culture)
        {
            this.ChangeCulture(culture);
            this.SortButtons.ChangeCulture(culture);
            foreach (var player in GuitarPlayers)
            {
                player.ChangeCulture(culture);
            }
        }
    }
}

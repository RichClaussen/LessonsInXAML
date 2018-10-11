using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

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

        private OrderBy OrderBy { get; set; }

        public ICommand SortByNameCommand { get; private set; }
        public ICommand SortByBirthYearCommand { get; private set; }
        public ICommand SortByOriginalCommand { get; private set; }

        public MainViewModel()
        {
            SortByNameCommand = new Command
            {
                CanExecuteDelegate = d => this.OrderBy != OrderBy.Name,
                ExecuteDelegate = d => this.SortByName(),
            };

            SortByBirthYearCommand = new Command
            {
                CanExecuteDelegate = d => this.OrderBy != OrderBy.BirthYear,
                ExecuteDelegate = d => this.SortByBirthYear(),
            };

            SortByOriginalCommand = new Command
            {
                CanExecuteDelegate = d => this.OrderBy != OrderBy.Unordered,
                ExecuteDelegate = d => this.SortByOriginal(),
            };

            this.SortByOriginal();
        }

        private void SortByName()
        {
            GuitarPlayers = new ObservableCollection<GuitarPlayer>(GuitarPlayerCollection.Players.OrderBy(p => p.Name));
            this.OrderBy = OrderBy.Name;
        }

        private void SortByBirthYear()
        {
            GuitarPlayers = new ObservableCollection<GuitarPlayer>(GuitarPlayerCollection.Players.OrderBy(p => p.YearOfBirth));
            this.OrderBy = OrderBy.BirthYear;
        }

        private void SortByOriginal()
        {
            GuitarPlayers = new ObservableCollection<GuitarPlayer>(GuitarPlayerCollection.Players);
            this.OrderBy = OrderBy.Unordered;
        }
    }
}

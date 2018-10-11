using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

using GuitarPlayers.Models;

namespace GuitarPlayers.ViewModels
{
    public class MainViewModel : DependencyObject
    {
        public static readonly DependencyProperty GuitarPlayersProperty = DependencyProperty.Register("GuitarPlayers", typeof(ObservableCollection<GuitarPlayerViewModel>), typeof(MainViewModel));

        public ObservableCollection<GuitarPlayerViewModel> GuitarPlayers
        {
            get { return (ObservableCollection<GuitarPlayerViewModel>)this.GetValue(GuitarPlayersProperty); }
            set { this.SetValue(GuitarPlayersProperty, value); }
        }

        public string Title { get { return "Guitar Players - DependencyProperty"; } }

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

            GuitarPlayers = new ObservableCollection<GuitarPlayerViewModel>(
                GuitarPlayerCollection.Players.Select(p => new GuitarPlayerViewModel(p)));
        }

        private void SortByName()
        {
            GuitarPlayers =
                new ObservableCollection<GuitarPlayerViewModel>(GuitarPlayers.OrderBy(p => p.LastName));
            this.OrderBy = OrderBy.Name;
        }

        private void SortByBirthYear()
        {
            GuitarPlayers =
                new ObservableCollection<GuitarPlayerViewModel>(GuitarPlayers.OrderBy(p => p.YearOfBirth));
            this.OrderBy = OrderBy.BirthYear;
        }

        private void SortByOriginal()
        {
            GuitarPlayers =
                new ObservableCollection<GuitarPlayerViewModel>(GuitarPlayers.OrderBy(p => p.Id));
            this.OrderBy = OrderBy.Unordered;
        }
    }
}

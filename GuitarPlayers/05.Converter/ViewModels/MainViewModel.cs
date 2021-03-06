﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

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

        public string Title { get { return "Guitar Players - Converter"; } }

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
            GuitarPlayers = new ObservableCollection<GuitarPlayerViewModel>(
                GuitarPlayerCollection.Players.OrderBy(p => p.LastName).Select(p => new GuitarPlayerViewModel(p)));
            this.OrderBy = OrderBy.Name;
        }

        private void SortByBirthYear()
        {
            GuitarPlayers = new ObservableCollection<GuitarPlayerViewModel>(
                GuitarPlayerCollection.Players.OrderBy(p => p.YearOfBirth).Select(p => new GuitarPlayerViewModel(p)));
            this.OrderBy = OrderBy.BirthYear;
        }

        private void SortByOriginal()
        {
            GuitarPlayers = new ObservableCollection<GuitarPlayerViewModel>(
                GuitarPlayerCollection.Players.Select(p => new GuitarPlayerViewModel(p)));
            this.OrderBy = OrderBy.Unordered;
        }
    }
}

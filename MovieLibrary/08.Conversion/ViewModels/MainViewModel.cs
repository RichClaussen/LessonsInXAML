using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

using MovieLibrary.Models;

namespace MovieLibrary.ViewModels
{
    public class MainViewModel : ObservableItem
    {
        public ObservableCollection<MovieViewModel> Movies
        {
            get { return movies; }
            private set
            {
                movies = value;
                this.OnPropertyChanged(() => Movies);
            }
        }

        public string Notification
        {
            get { return this.notification; }
            private set
            {
                this.notification = value;
                this.OnPropertyChanged(() => Notification);
            }
        }

        public ICommand AddMoviesCommand { get; private set; }
        public ICommand ChangeMoviesCommand { get; private set; }
        public ICommand ResetMoviesCommand { get; private set; }

        public MainViewModel()
        {
            // http://stackoverflow.com/questions/327984/wpf-databinding-to-interface-and-not-actual-object-casting-possible

            // movies are fun to watch
            this.Movies = this.GetCrazyAwesomeMovies();

            // this command is special to me
            this.AddMoviesCommand = new Command
            {
                CanExecuteDelegate = ced => this.CanAddMovies(),
                ExecuteDelegate = ed => this.AddMovies(),
            };
            this.ChangeMoviesCommand = new Command
            {
                CanExecuteDelegate = ced => this.CanChangeMovies(),
                ExecuteDelegate = ed => this.ChangeMovies(),
            };
            this.ResetMoviesCommand = new Command
            {
                CanExecuteDelegate = ced => this.CanResetMovies(),
                ExecuteDelegate = ed => this.ResetMovies(),
            };

            this.Notification = "HELLO";
        }

        private void AddMovies()
        {
            if (!CanAddMovies()) return;
            this.Movies.AddRange(this.GetOtherMovies());
            this.Notification = "Movies Added!";
            this.moviesAdded = true;
        }

        private void ChangeMovies()
        {
            if (!CanChangeMovies()) return;
            this.Movies = new ObservableCollection<MovieViewModel>(this.GetOtherMovies());
            this.Notification = "Movies Changed!";
            this.moviesChanged = true;
        }

        private void ResetMovies()
        {
            if (!CanResetMovies()) return;
            this.Movies = this.GetCrazyAwesomeMovies();
            this.Notification = "Movies Reset!";
            this.moviesAdded = false;
            this.moviesChanged = false;
        }

        private bool CanAddMovies()
        {
            return !this.moviesAdded && !this.moviesChanged;
        }

        private bool CanChangeMovies()
        {
            return !this.moviesChanged;
        }

        private bool CanResetMovies()
        {
            return this.moviesAdded || this.moviesChanged;
        }

        private ObservableCollection<MovieViewModel> GetCrazyAwesomeMovies()
        {
            return new ObservableCollection<MovieViewModel>
            {
                new MovieViewModel(new Movie("Santa with Muscles", new DateTime(1996, 11, 08), "John Murlowski", 2.1)),
                new MovieViewModel(new Movie("Ed", new DateTime(1996, 03, 15), "Bill Couturié", 2.4)),
                new MovieViewModel(new Movie("Battlefield Earth", new DateTime(2000, 05, 12), "Roger Christian", 2.4)),
                new MovieViewModel(new Movie("Glitter", new DateTime(2001, 09, 21), "Vondie Curtis-Hall", 2.0)),
                new MovieViewModel(new Movie("Manos: The Hands of Fate", new DateTime(1966, 11, 15), "Harold P. Warren", 1.5)),
                new MovieViewModel(new Movie("It's Pat", new DateTime(1994, 08, 26), "Adam Bernstein", 2.5)),
                new MovieViewModel(new Movie("Gigli", new DateTime(2003, 08, 01), "Martin Brest", 2.4)),
            };
        }

        private List<MovieViewModel> GetOtherMovies()
        {
            return new List<MovieViewModel>
            {
                new MovieViewModel(new Movie("Se7en", new DateTime(1995, 09, 22), "David Fincher", 8.7)),
                new MovieViewModel(new Movie("The Godfather", new DateTime(1972, 03, 24), "Francis Ford Coppola", 9.2)),
                new MovieViewModel(new Movie("Vertigo", new DateTime(1958, 07, 21), "Alfred Hitchcock", 8.5)),
                new MovieViewModel(new Movie("Fight Club", new DateTime(1999, 10, 15), "David Fincher", 8.9)),
                new MovieViewModel(new Movie("Pulp Fiction", new DateTime(1994, 10, 14), "Quentin Tarantino", 9.0)),
            };
        }

        private ObservableCollection<MovieViewModel> movies;
        private string notification;
        private bool moviesAdded = false;
        private bool moviesChanged = false;
    }
}

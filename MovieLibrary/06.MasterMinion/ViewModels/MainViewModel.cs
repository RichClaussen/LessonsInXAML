﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

using MovieLibrary.Models;

namespace MovieLibrary.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public ObservableCollection<Movie> Movies
        {
            get { return movies; }
            private set
            {
                movies = value;
                OnPropertyChanged();
            }
        }

        public string Notification
        {
            get { return notification; }
            private set
            {
                notification = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddMoviesCommand { get; private set; }
        public ICommand ChangeMoviesCommand { get; private set; }
        public ICommand ResetMoviesCommand { get; private set; }

        public MainViewModel()
        {
            // http://stackoverflow.com/questions/327984/wpf-databinding-to-interface-and-not-actual-object-casting-possible

            // movies are fun to watch
            Movies = GetCrazyAwesomeMovies();

            // this command is special to me
            AddMoviesCommand = new Command
            {
                CanExecuteDelegate = ced => CanAddMovies(),
                ExecuteDelegate = ed => AddMovies(),
            };
            ChangeMoviesCommand = new Command
            {
                CanExecuteDelegate = ced => CanChangeMovies(),
                ExecuteDelegate = ed => ChangeMovies(),
            };
            ResetMoviesCommand = new Command
            {
                CanExecuteDelegate = ced => CanResetMovies(),
                ExecuteDelegate = ed => ResetMovies(),
            };

            Notification = "HELLO";
        }

        private void AddMovies()
        {
            if (!CanAddMovies()) return;
            Movies.AddRange(GetOtherMovies());
            Notification = "Movies Added!";
            moviesAdded = true;
        }

        private void ChangeMovies()
        {
            if (!CanChangeMovies()) return;
            Movies = new ObservableCollection<Movie>(GetOtherMovies());
            Notification = "Movies Changed!";
            moviesChanged = true;
        }

        private void ResetMovies()
        {
            if (!CanResetMovies()) return;
            Movies = GetCrazyAwesomeMovies();
            Notification = "Movies Reset!";
            moviesAdded = false;
            moviesChanged = false;
        }

        private bool CanAddMovies()
        {
            return !moviesAdded && !moviesChanged;
        }

        private bool CanChangeMovies()
        {
            return !moviesChanged;
        }

        private bool CanResetMovies()
        {
            return moviesAdded || moviesChanged;
        }

        private ObservableCollection<Movie> GetCrazyAwesomeMovies()
        {
            return new ObservableCollection<Movie>
            {
                new Movie("Santa with Muscles", new DateTime(1996, 11, 08), "John Murlowski", 2.1),
                new Movie("Ed", new DateTime(1996, 03, 15), "Bill Couturié", 2.4),
                new Movie("Battlefield Earth", new DateTime(2000, 05, 12), "Roger Christian", 2.4),
                new Movie("Glitter", new DateTime(2001, 09, 21), "Vondie Curtis-Hall", 2.0),
                new Movie("Manos: The Hands of Fate", new DateTime(1966, 11, 15), "Harold P. Warren", 1.5),
                new Movie("It's Pat", new DateTime(1994, 08, 26), "Adam Bernstein", 2.5),
                new Movie("Gigli", new DateTime(2003, 08, 01), "Martin Brest", 2.4),
            };
        }

        private List<Movie> GetOtherMovies()
        {
            return new List<Movie>
            {
                new Movie("Se7en", new DateTime(1995, 09, 22), "David Fincher", 8.7),
                new Movie("The Godfather", new DateTime(1972, 03, 24), "Francis Ford Coppola", 9.2),
                new Movie("Vertigo", new DateTime(1958, 07, 21), "Alfred Hitchcock", 8.5),
                new Movie("Fight Club", new DateTime(1999, 10, 15), "David Fincher", 8.9),
                new Movie("Pulp Fiction", new DateTime(1994, 10, 14), "Quentin Tarantino", 9.0),
            };
        }

        private ObservableCollection<Movie> movies;
        private string notification;
        private bool moviesAdded = false;
        private bool moviesChanged = false;
    }
}

﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MovieLibrary.Models;

namespace MovieLibrary.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private ObservableCollection<Movie> movies;
        public ObservableCollection<Movie> Movies
        {
            get { return movies; }
            private set
            {
                movies = value;
                OnPropertyChanged();
            }
        }

        private string notification;
        public string Notification
        {
            get { return notification; }
            private set
            {
                notification = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Movies = GetCrazyAwesomeMovies();
            Notification = "HELLO";
        }

        private bool alreadyAdded = false;
        public void AddMovies()
        {
            if (!alreadyAdded)
            {
                Movies.AddRange(GetOtherMovies());
                Notification = "Movies Added!";
                alreadyAdded = true;
            }
        }

        private bool alreadyChanged = false;
        public void ChangeMovies()
        {
            if (!alreadyChanged)
            {
                Movies = new ObservableCollection<Movie>(GetOtherMovies());
                Notification = "Movies Changed!";
                alreadyChanged = true;
            }
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
    }
}

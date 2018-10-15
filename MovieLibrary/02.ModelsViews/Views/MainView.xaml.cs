using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using MovieLibrary.Models;

namespace MovieLibrary.Views
{
    public partial class MainView : Window
    {
        public List<Movie> Movies { get; set; }

        public MainView()
        {
            InitializeComponent();

            Movies = GetCrazyAwesomeMovies();
        }

        private bool alreadyDone = false;
        private void OnButtonClicked(object sender, RoutedEventArgs e)
        {
            if (!alreadyDone)
            {
                Movies.AddRange(GetOtherMovies());
                alreadyDone = true;
            }
        }

        private List<Movie> GetCrazyAwesomeMovies()
        {
            return new List<Movie>
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
using System;
using System.Collections.Generic;
using System.Windows;

namespace MovieLibrary
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var movies = new List<Movie>();
            movies.Add(new Movie("Santa with Muscles", new DateTime(1996, 11, 08), "John Murlowski", 2.1));
            movies.Add(new Movie("Ed", new DateTime(1996, 03, 15), "Bill Couturié", 2.4));
            movies.Add(new Movie("Battlefield Earth", new DateTime(2000, 05, 12), "Roger Christian", 2.4));
            movies.Add(new Movie("Glitter", new DateTime(2001, 09, 21), "Vondie Curtis-Hall", 2.0));
            movies.Add(new Movie("Manos: The Hands of Fate", new DateTime(1966, 11, 15), "Harold P. Warren", 1.5));
            movies.Add(new Movie("It's Pat", new DateTime(1994, 08, 26), "Adam Bernstein", 2.5));
            movies.Add(new Movie("Gigli", new DateTime(2003, 08, 01), "Martin Brest", 2.4));

            MovieGrid.ItemsSource = movies;
        }
    }
}

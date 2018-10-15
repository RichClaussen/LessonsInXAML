using System;
using System.Windows.Input;

using MovieLibrary.Models;

namespace MovieLibrary.ViewModels
{
    public class MovieViewModel : ObservableObject
    {
        private readonly Movie movie;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        public DateTime Release
        {
            get { return release; }
            set
            {
                release = value;
                OnPropertyChanged();
            }
        }

        public string DirectorName
        {
            get { return directorName; }
            set
            {
                directorName = value;
                OnPropertyChanged();
            }
        }

        public double Rating
        {
            get { return rating; }
            set
            {
                rating = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        internal MovieViewModel(Movie movie)
        {
            this.movie = movie;
            PopulateViewModel();

            SaveCommand = new Command
            {
                CanExecuteDelegate = ced => true,
                ExecuteDelegate = ed => Save(),
            };

            CancelCommand = new Command
            {
                CanExecuteDelegate = ced => true,
                ExecuteDelegate = ed => Cancel(),
            };
        }

        private void PopulateViewModel()
        {
            Title = movie.Title;
            Release = movie.Release;
            DirectorName = movie.Director.ToString();
            Rating = movie.Rating;
        }

        private void Save()
        {
            movie.Title = Title;
            movie.Release = Release;
            movie.Rating = Rating;
            movie.Director = new Director(DirectorName);
        }

        private void Cancel()
        {
            PopulateViewModel();
        }

        private string title;
        private DateTime release;
        private string directorName;
        private double rating;
    }
}
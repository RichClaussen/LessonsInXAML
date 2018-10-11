using System;
using System.Windows.Input;

using MovieLibrary.Models;

namespace MovieLibrary.ViewModels
{
    public class MovieViewModel : ObservableItem
    {
        private readonly Movie movie;
        public string Title
        {
            get { return this.title; }
            set
            {
                this.title = value;
                this.OnPropertyChanged(() => this.Title);
            }
        }

        public DateTime Release
        {
            get { return this.release; }
            set
            {
                this.release = value;
                this.OnPropertyChanged(() => this.Release);
            }
        }

        public string DirectorName
        {
            get { return this.directorName; }
            set
            {
                this.directorName = value;
                this.OnPropertyChanged(() => this.DirectorName);
            }
        }

        public double Rating
        {
            get { return this.rating; }
            set
            {
                this.rating = value;
                this.OnPropertyChanged(() => this.Rating);
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        internal MovieViewModel(Movie movie)
        {
            this.movie = movie;
            this.PopulateViewModel();

            this.SaveCommand = new Command
            {
                CanExecuteDelegate = ced => true,
                ExecuteDelegate = ed => this.Save(),
            };

            this.CancelCommand = new Command
            {
                CanExecuteDelegate = ced => true,
                ExecuteDelegate = ed => this.Cancel(),
            };
        }

        private void PopulateViewModel()
        {
            this.Title = movie.Title;
            this.Release = movie.Release;
            this.DirectorName = movie.Director.ToString();
            this.Rating = movie.Rating;
        }

        private void Save()
        {
            movie.Title = this.Title;
            movie.Release = this.Release;
            movie.Rating = this.Rating;
            movie.Director = new Director(this.DirectorName);
        }

        private void Cancel()
        {
            this.PopulateViewModel();
        }

        private string title;
        private DateTime release;
        private string directorName;
        private double rating;
    }
}
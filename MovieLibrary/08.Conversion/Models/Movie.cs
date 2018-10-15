using System;

namespace MovieLibrary.Models
{
    public class Movie
    {
        public string Title { get; set; }

        private DateTime release;
        public DateTime Release
        {
            get { return release; }
            set { release = new DateTime(value.Year, value.Month, value.Day); }
        }

        public IDirector Director { get; set; }
        public double Rating { get; set; }

        public Movie() { }

        public Movie(string title, DateTime release, IDirector director, double rating)
            : this()
        {
            Title = title;
            Release = release;
            Director = director;
            Rating = rating;
        }

        public Movie(string title, DateTime release, string director, double rating)
            : this(title, release, new Director(director), rating) { }
    }
}

using System;

namespace MovieLibrary
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

        public string Director { get; set; }

        public double Rating { get; set; }

        public Movie() { }

        public Movie(string title, DateTime release, string director, double rating)
        {
            this.Title = title;
            this.Release = release;
            this.Director = director;
            this.Rating = rating;
        }
    }
}

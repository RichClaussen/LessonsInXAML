using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieLibrary.Models;

namespace MovieLibrary.Test
{
    [TestClass]
    public class MovieTest
    {
        [TestMethod]
        public void TestEmptyMovie()
        {
            var movie = new Movie();

            Assert.IsNotNull(movie);
            Assert.AreEqual(null, movie.Title);
            Assert.AreEqual(DateTime.MinValue, movie.Release);
            Assert.AreEqual(null, movie.Director);
            Assert.AreEqual(0.0, movie.Rating);
        }

        [TestMethod]
        public void TestWholeMovie()
        {
            var director = new Director { Name = "William Heins" };

            var movie = new Movie("Pledge This!", new DateTime(2006, 12, 01), director, 1.6);

            Assert.AreEqual("Pledge This!", movie.Title);
            Assert.AreEqual(new DateTime(2006, 12, 01), movie.Release);
            Assert.AreEqual(director, movie.Director);
            Assert.AreEqual(1.6, movie.Rating);
        }

        [TestMethod]
        public void TestReleaseDateTruncated()
        {
            var movie = new Movie("Pledge This!", new DateTime(2006, 12, 01, 10, 37, 23), "William Heins", 1.6);

            Assert.AreEqual(new DateTime(2006, 12, 01), movie.Release);
        }
    }
}

using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieLibrary.Models;
using MovieLibrary.Test.Fakes;

namespace MovieLibrary.Test.Models
{
    [TestClass]
    public class MovieTest
    {
        private static readonly IDirector director;

        static MovieTest()
        {
            director = new FakeDirector();
        }

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
            var movie = new Movie("Pledge This!", new DateTime(2006, 12, 01), director, 1.6);

            Assert.AreEqual("Pledge This!", movie.Title);
            Assert.AreEqual(new DateTime(2006, 12, 01), movie.Release);
            Assert.AreEqual(director, movie.Director);
            Assert.AreEqual(1.6, movie.Rating);
        }

        [TestMethod]
        public void TestReleaseDateTruncated()
        {
            var movie = new Movie("Pledge This!", new DateTime(2006, 12, 01, 10, 37, 23), director, 1.6);

            Assert.AreEqual(new DateTime(2006, 12, 01), movie.Release);
        }
    }
}

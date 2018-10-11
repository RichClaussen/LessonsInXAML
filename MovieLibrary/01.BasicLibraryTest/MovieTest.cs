using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        }

        [TestMethod]
        public void TestWholeMovie()
        {
            var movie = new Movie("Pledge This!", new DateTime(2006, 12, 01), "William Heins", 1.6);

            Assert.AreEqual("Pledge This!", movie.Title);
            Assert.AreEqual(new DateTime(2006, 12, 01), movie.Release);
            Assert.AreEqual("William Heins", movie.Director);
            Assert.AreEqual(1.6, movie.Rating);
        }

        [TestMethod]
        public void TestReleaseDateTruncated()
        {
            var movie = new Movie("Pledge This!", new DateTime(2006, 12, 01, 10, 37, 23), "William Heins", 1.6);

            Assert.AreEqual(new DateTime(2006, 12, 01), movie.Release);
        }

        //[TestMethod]
        //public void TestWindow()
        //{
        //    var window = new MainWindow();

        //    Assert.IsNotNull(window);
        //}
    }
}

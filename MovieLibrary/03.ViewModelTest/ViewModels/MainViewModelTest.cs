using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieLibrary.ViewModels;

namespace MovieLibrary.Test.ViewModels
{
    [TestClass]
    public class MainViewModelTest
    {
        [TestMethod]
        public void TestViewModel()
        {
            var vm = new MainViewModel();

            Assert.IsNotNull(vm);
            Assert.AreEqual(7, vm.Movies.Count);
        }

        [TestMethod]
        public void TestAddMovies()
        {
            var vm = new MainViewModel();
            Assert.AreEqual(7, vm.Movies.Count);

            vm.AddMovies();
            Assert.AreEqual(12, vm.Movies.Count);
        }
    }
}

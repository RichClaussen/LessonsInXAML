using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieLibrary.ViewModels;

namespace MovieLibrary.Test.ViewModels
{
    [TestClass]
    public class MainViewModelTest
    {
        private MainViewModel viewModel;

        [TestInitialize]
        public void TestInitializer()
        {
            eventCallCount = 0;
            viewModel = new MainViewModel();
            viewModel.PropertyChanged += ViewModelPropertyChanged;
        }

        [TestMethod]
        public void TestViewModel()
        {
            Assert.IsNotNull(viewModel);
            Assert.AreEqual(7, viewModel.Movies.Count);
        }

        [TestMethod]
        public void TestAddMovies()
        {
            Assert.AreEqual(7, viewModel.Movies.Count);

            viewModel.AddMovies();
            Assert.AreEqual(12, viewModel.Movies.Count);
            Assert.AreEqual("Movies Added!", viewModel.Notification);
            Assert.AreEqual(1, eventCallCount);
        }

        [TestMethod]
        public void TestChangeMovies()
        {
            Assert.AreEqual(7, viewModel.Movies.Count);

            viewModel.ChangeMovies();
            Assert.AreEqual(5, viewModel.Movies.Count);
            Assert.AreEqual("Movies Changed!", viewModel.Notification);
            Assert.AreEqual(2, eventCallCount);
        }

        private int eventCallCount;
        private void ViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            eventCallCount++;
        }
    }
}

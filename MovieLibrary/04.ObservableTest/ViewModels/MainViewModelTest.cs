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
            this.eventCallCount = 0;
            this.viewModel = new MainViewModel();
            this.viewModel.PropertyChanged += ViewModelPropertyChanged;
        }

        [TestMethod]
        public void TestViewModel()
        {
            Assert.IsNotNull(this.viewModel);
            Assert.AreEqual(7, this.viewModel.Movies.Count);
        }

        [TestMethod]
        public void TestAddMovies()
        {
            Assert.AreEqual(7, this.viewModel.Movies.Count);

            this.viewModel.AddMovies();
            Assert.AreEqual(12, this.viewModel.Movies.Count);
            Assert.AreEqual("Movies Added!", this.viewModel.Notification);
            Assert.AreEqual(1, this.eventCallCount);
        }

        [TestMethod]
        public void TestChangeMovies()
        {
            Assert.AreEqual(7, this.viewModel.Movies.Count);

            this.viewModel.ChangeMovies();
            Assert.AreEqual(5, this.viewModel.Movies.Count);
            Assert.AreEqual("Movies Changed!", this.viewModel.Notification);
            Assert.AreEqual(2, this.eventCallCount);
        }

        private int eventCallCount;
        private void ViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            eventCallCount++;
        }
    }
}

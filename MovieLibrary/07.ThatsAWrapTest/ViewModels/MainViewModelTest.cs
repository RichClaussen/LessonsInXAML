using System;
using System.Windows.Input;

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

            ICommand command = this.viewModel.AddMoviesCommand;
            Assert.IsTrue(command.CanExecute(null));

            command = this.viewModel.ChangeMoviesCommand;
            Assert.IsTrue(command.CanExecute(null));

            command = this.viewModel.ResetMoviesCommand;
            Assert.IsFalse(command.CanExecute(null));
        }

        [TestMethod]
        public void TestAddMovies()
        {
            Assert.AreEqual(7, this.viewModel.Movies.Count);

            ICommand command = this.viewModel.AddMoviesCommand;
            command.Execute(null);

            Assert.AreEqual(12, this.viewModel.Movies.Count);
            Assert.AreEqual("Movies Added!", this.viewModel.Notification);
            Assert.AreEqual(1, this.eventCallCount);
        }

        [TestMethod]
        public void TestChangeMovies()
        {
            Assert.AreEqual(7, this.viewModel.Movies.Count);

            ICommand command = this.viewModel.ChangeMoviesCommand;
            command.Execute(null);

            Assert.AreEqual(5, this.viewModel.Movies.Count);
            Assert.AreEqual("Movies Changed!", this.viewModel.Notification);
            Assert.AreEqual(2, this.eventCallCount);
        }

        [TestMethod]
        public void TestResetMoviesAfterAdd()
        {
            Assert.AreEqual(7, this.viewModel.Movies.Count);

            ICommand command = this.viewModel.AddMoviesCommand;
            Assert.IsTrue(command.CanExecute(null));
            command.Execute(null);
            Assert.IsFalse(command.CanExecute(null));

            command = this.viewModel.ResetMoviesCommand;
            Assert.IsTrue(command.CanExecute(null));
            command.Execute(null);
            Assert.IsFalse(command.CanExecute(null));

            Assert.AreEqual(7, this.viewModel.Movies.Count);
            Assert.AreEqual("Movies Reset!", this.viewModel.Notification);
            Assert.AreEqual(3, this.eventCallCount);
        }

        [TestMethod]
        public void TestResetMoviesAfterChange()
        {
            Assert.AreEqual(7, this.viewModel.Movies.Count);

            ICommand command = this.viewModel.ChangeMoviesCommand;
            Assert.IsTrue(command.CanExecute(null));
            command.Execute(null);
            Assert.IsFalse(command.CanExecute(null));

            command = this.viewModel.ResetMoviesCommand;
            Assert.IsTrue(command.CanExecute(null));
            command.Execute(null);
            Assert.IsFalse(command.CanExecute(null));

            Assert.AreEqual(7, this.viewModel.Movies.Count);
            Assert.AreEqual("Movies Reset!", this.viewModel.Notification);
            Assert.AreEqual(4, this.eventCallCount);
        }

        [TestMethod]
        public void TestResetMoviesAfterChangeAdd()
        {
            Assert.AreEqual(7, this.viewModel.Movies.Count);

            ICommand command = this.viewModel.AddMoviesCommand;
            Assert.IsTrue(command.CanExecute(null));
            command.Execute(null);
            Assert.IsFalse(command.CanExecute(null));

            command = this.viewModel.ChangeMoviesCommand;
            Assert.IsTrue(command.CanExecute(null));
            command.Execute(null);
            Assert.IsFalse(command.CanExecute(null));

            command = this.viewModel.ResetMoviesCommand;
            Assert.IsTrue(command.CanExecute(null));
            command.Execute(null);
            Assert.IsFalse(command.CanExecute(null));

            Assert.AreEqual(7, this.viewModel.Movies.Count);
            Assert.AreEqual("Movies Reset!", this.viewModel.Notification);
            Assert.AreEqual(5, this.eventCallCount);
        }

        private int eventCallCount;
        private void ViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            eventCallCount++;
        }
    }
}

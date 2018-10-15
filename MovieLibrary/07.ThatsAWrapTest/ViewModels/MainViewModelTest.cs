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
            eventCallCount = 0;
            viewModel = new MainViewModel();
            viewModel.PropertyChanged += ViewModelPropertyChanged;
        }

        [TestMethod]
        public void TestViewModel()
        {
            Assert.IsNotNull(viewModel);
            Assert.AreEqual(7, viewModel.Movies.Count);

            ICommand command = viewModel.AddMoviesCommand;
            Assert.IsTrue(command.CanExecute(null));

            command = viewModel.ChangeMoviesCommand;
            Assert.IsTrue(command.CanExecute(null));

            command = viewModel.ResetMoviesCommand;
            Assert.IsFalse(command.CanExecute(null));
        }

        [TestMethod]
        public void TestAddMovies()
        {
            Assert.AreEqual(7, viewModel.Movies.Count);

            ICommand command = viewModel.AddMoviesCommand;
            command.Execute(null);

            Assert.AreEqual(12, viewModel.Movies.Count);
            Assert.AreEqual("Movies Added!", viewModel.Notification);
            Assert.AreEqual(1, eventCallCount);
        }

        [TestMethod]
        public void TestChangeMovies()
        {
            Assert.AreEqual(7, viewModel.Movies.Count);

            ICommand command = viewModel.ChangeMoviesCommand;
            command.Execute(null);

            Assert.AreEqual(5, viewModel.Movies.Count);
            Assert.AreEqual("Movies Changed!", viewModel.Notification);
            Assert.AreEqual(2, eventCallCount);
        }

        [TestMethod]
        public void TestResetMoviesAfterAdd()
        {
            Assert.AreEqual(7, viewModel.Movies.Count);

            ICommand command = viewModel.AddMoviesCommand;
            Assert.IsTrue(command.CanExecute(null));
            command.Execute(null);
            Assert.IsFalse(command.CanExecute(null));

            command = viewModel.ResetMoviesCommand;
            Assert.IsTrue(command.CanExecute(null));
            command.Execute(null);
            Assert.IsFalse(command.CanExecute(null));

            Assert.AreEqual(7, viewModel.Movies.Count);
            Assert.AreEqual("Movies Reset!", viewModel.Notification);
            Assert.AreEqual(3, eventCallCount);
        }

        [TestMethod]
        public void TestResetMoviesAfterChange()
        {
            Assert.AreEqual(7, viewModel.Movies.Count);

            ICommand command = viewModel.ChangeMoviesCommand;
            Assert.IsTrue(command.CanExecute(null));
            command.Execute(null);
            Assert.IsFalse(command.CanExecute(null));

            command = viewModel.ResetMoviesCommand;
            Assert.IsTrue(command.CanExecute(null));
            command.Execute(null);
            Assert.IsFalse(command.CanExecute(null));

            Assert.AreEqual(7, viewModel.Movies.Count);
            Assert.AreEqual("Movies Reset!", viewModel.Notification);
            Assert.AreEqual(4, eventCallCount);
        }

        [TestMethod]
        public void TestResetMoviesAfterChangeAdd()
        {
            Assert.AreEqual(7, viewModel.Movies.Count);

            ICommand command = viewModel.AddMoviesCommand;
            Assert.IsTrue(command.CanExecute(null));
            command.Execute(null);
            Assert.IsFalse(command.CanExecute(null));

            command = viewModel.ChangeMoviesCommand;
            Assert.IsTrue(command.CanExecute(null));
            command.Execute(null);
            Assert.IsFalse(command.CanExecute(null));

            command = viewModel.ResetMoviesCommand;
            Assert.IsTrue(command.CanExecute(null));
            command.Execute(null);
            Assert.IsFalse(command.CanExecute(null));

            Assert.AreEqual(7, viewModel.Movies.Count);
            Assert.AreEqual("Movies Reset!", viewModel.Notification);
            Assert.AreEqual(5, eventCallCount);
        }

        private int eventCallCount;
        private void ViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            eventCallCount++;
        }
    }
}

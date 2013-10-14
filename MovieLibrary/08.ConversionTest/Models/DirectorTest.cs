using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieLibrary.Models;

namespace MovieLibrary.Test.Models
{
    [TestClass]
    public class DirectorTest
    {
        [TestMethod]
        public void TestDefaultDirector()
        {
            var director = new Director();

            Assert.IsNotNull(director);
            Assert.IsNull(director.Name);
            Assert.AreEqual("**  **", director.ToString());
        }

        [TestMethod]
        public void TestNamedDirector()
        {
            var director = new Director { Name = "William Heins", };

            Assert.IsNotNull(director);
            Assert.AreEqual("William Heins", director.Name);
            Assert.AreEqual("** William Heins **", director.ToString());
        }
    }
}

﻿using MovieLibrary.Models;

namespace MovieLibrary.Test.Fakes
{
    public class FakeDirector : IDirector
    {
        public string Name
        {
            get { return "William Heins"; }
            set { }
        }

        public override string ToString()
        {
            return "** William Heins **";
        }
    }
}

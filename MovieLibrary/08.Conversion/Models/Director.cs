﻿namespace MovieLibrary.Models
{
    public class Director : ObservableItem, IDirector
    {
        private string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                this.OnPropertyChanged(() => Name);
            }
        }

        public override string ToString()
        {
            return "** " + this.Name + " **";
        }

        public Director() { }

        public Director(string name)
        {
            this.Name = name;
        }
    }
}
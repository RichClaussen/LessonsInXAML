namespace MovieLibrary.Models
{
    public class Director : ObservableObject, IDirector
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return "** " + Name + " **";
        }

        public Director() { }

        public Director(string name)
        {
            Name = name;
        }
    }
}

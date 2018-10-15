namespace MovieLibrary.Models
{
    public abstract class IDirector : ObservableObject
    {
        public abstract string Name { get; set; }

        public override abstract string ToString();
    }
}

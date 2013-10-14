namespace MovieLibrary.Models
{
    public abstract class IDirector : ObservableItem
    {
        public abstract string Name { get; set; }

        public override abstract string ToString();
    }
}

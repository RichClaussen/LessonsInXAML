namespace MovieLibrary.Models
{
    public class Director : IDirector
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return "<< " + Name + " >>";
        }
    }
}

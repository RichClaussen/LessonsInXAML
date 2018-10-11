namespace MovieLibrary.Models
{
    public class Director
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return "** " + Name + " **";
        }
    }
}

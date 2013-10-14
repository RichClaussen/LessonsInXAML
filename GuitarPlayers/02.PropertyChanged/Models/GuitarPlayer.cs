namespace GuitarPlayers.Models
{
    public class GuitarPlayer
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int YearOfBirth { get; set; }

        public string Name { get { return string.Format("{0} {1}", FirstName, LastName); } }
    }
}

using GuitarPlayers.Models;

namespace GuitarPlayers.ViewModels
{
    public class GuitarPlayerViewModel : NotifyPropertyChanged
    {
        private GuitarPlayer GuitarPlayer { get; set; }

        public string FirstName
        {
            get { return GuitarPlayer.FirstName; }
            set
            {
                GuitarPlayer.FirstName = value;
                this.OnPropertyChanged(() => FirstName);
                this.OnPropertyChanged(() => Name);
            }
        }

        public string LastName
        {
            get { return GuitarPlayer.LastName; }
            set
            {
                GuitarPlayer.LastName = value;
                this.OnPropertyChanged(() => LastName);
                this.OnPropertyChanged(() => Name);
            }
        }

        public int YearOfBirth
        {
            get { return GuitarPlayer.YearOfBirth; }
            set
            {
                GuitarPlayer.YearOfBirth = value;
                this.OnPropertyChanged(() => YearOfBirth);
            }
        }

        public string Name { get { return string.Format("{0} {1}", FirstName, LastName); } }

        public GuitarPlayerViewModel(GuitarPlayer guitarPlayer)
        {
            GuitarPlayer = guitarPlayer;
        }
    }
}

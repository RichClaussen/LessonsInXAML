using GuitarPlayers.Models;

namespace GuitarPlayers.ViewModels
{
    public class GuitarPlayerViewModel : NotifyPropertyChanged
    {
        private GuitarPlayer GuitarPlayer { get; set; }

        public int Id
        {
            get { return GuitarPlayer.Id; }
        }

        public string FirstName
        {
            get { return GuitarPlayer.FirstName; }
            set
            {
                GuitarPlayer.FirstName = value;
                this.OnPropertyChanged(() => FirstName);
            }
        }

        public string LastName
        {
            get { return GuitarPlayer.LastName; }
            set
            {
                GuitarPlayer.LastName = value;
                this.OnPropertyChanged(() => LastName);
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

        public GuitarPlayerViewModel(GuitarPlayer guitarPlayer)
        {
            GuitarPlayer = guitarPlayer;
        }
    }
}

using System;

using GuitarPlayers.Models;

namespace GuitarPlayers.ViewModels
{
    public class GuitarPlayerViewModel : CultureAwareViewModelBase
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
                if (this.GuitarPlayer.FirstName == value) return;

                this.GuitarPlayer.FirstName = value;
                if (this.Errors != null)
                {
                    if (string.IsNullOrWhiteSpace(this.FirstName))
                    {
                        this.Errors.Add("FirstName", "First name must exist");
                    }
                    else
                    {
                        this.Errors.Clear("FirstName");
                    }

                    this.OnPropertyChanged(() => Errors);
                }

                this.OnPropertyChanged(() => FirstName);
            }
        }

        public string LastName
        {
            get { return GuitarPlayer.LastName; }
            set
            {
                if (this.GuitarPlayer.LastName == value) return;

                this.GuitarPlayer.LastName = value;
                if (this.Errors != null)
                {
                    if (string.IsNullOrWhiteSpace(this.LastName))
                    {
                        this.Errors.Add("LastName", "Last name must exist");
                    }
                    else
                    {
                        this.Errors.Clear("LastName");
                    }

                    this.OnPropertyChanged(() => Errors);
                }

                this.OnPropertyChanged(() => LastName);
            }
        }

        public int YearOfBirth
        {
            get { return GuitarPlayer.YearOfBirth; }
            set
            {
                if (this.GuitarPlayer.YearOfBirth == value) return;

                this.GuitarPlayer.YearOfBirth = value;
                if (this.Errors != null)
                {
                    if (this.GuitarPlayer.YearOfBirth > DateTime.Now.Year)
                    {
                        this.Errors.Add("YearOfBirth", "Birth year must be in the past");
                    }
                    else if (this.GuitarPlayer.YearOfBirth < DateTime.Now.Year - 150)
                    {
                        this.Errors.Add("YearOfBirth", "Birth year must be reasonable");
                    }
                    else
                    {
                        this.Errors.Clear("YearOfBirth");
                    }

                    this.OnPropertyChanged(() => Errors);
                }

                this.OnPropertyChanged(() => YearOfBirth);
            }
        }

        public GuitarPlayerViewModel(GuitarPlayer guitarPlayer)
        {
            GuitarPlayer = guitarPlayer;
        }
    }
}

using System;

using GuitarPlayers.Models;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace GuitarPlayers.ViewModels
{
    public class GuitarPlayerViewModel : CultureAwareViewModelBase
    {
        private GuitarPlayer GuitarPlayer { get; set; }

        public int Id
        {
            get { return GuitarPlayer.Id; }
        }

        [StringLengthValidator(1, 100, MessageTemplate="First name must exist")]
        public string FirstName
        {
            get { return GuitarPlayer.FirstName; }
            set
            {
                if (this.GuitarPlayer.FirstName == value) return;

                this.GuitarPlayer.FirstName = value;
                this.OnPropertyChanged(() => FirstName);
            }
        }

        [StringLengthValidator(1, 100, MessageTemplate="Last name must exist")]
        public string LastName
        {
            get { return GuitarPlayer.LastName; }
            set
            {
                if (this.GuitarPlayer.LastName == value) return;

                this.GuitarPlayer.LastName = value;

                this.OnPropertyChanged(() => LastName);
            }
        }

        [RelativeDateTimeValidator(-120, DateTimeUnit.Year, 0, DateTimeUnit.Year, MessageTemplate = "Birth year must be in the past and reasonable")]
        public DateTime YearOfBirth
        {
            get { return new DateTime(GuitarPlayer.YearOfBirth, 1, 1); }
            set
            {
                if (this.GuitarPlayer.YearOfBirth == value.Year) return;

                this.GuitarPlayer.YearOfBirth = value.Year;

                this.OnPropertyChanged(() => YearOfBirth);
            }
        }

        public GuitarPlayerViewModel(GuitarPlayer guitarPlayer)
        {
            GuitarPlayer = guitarPlayer;
        }
    }
}

using System.Windows;

using GuitarPlayers.Models;

namespace GuitarPlayers.ViewModels
{
    public class GuitarPlayerViewModel : DependencyObject
    {
        public static readonly DependencyProperty FirstNameProperty = DependencyProperty.Register("FirstName", typeof(string), typeof(GuitarPlayerViewModel));
        public static readonly DependencyProperty LastNameProperty = DependencyProperty.Register("LastName", typeof(string), typeof(GuitarPlayerViewModel));
        public static readonly DependencyProperty YearOfBirthProperty = DependencyProperty.Register("YearOfBirth", typeof(int), typeof(GuitarPlayerViewModel));

        public int Id { get; set; }

        public string FirstName
        {
            get { return (string)this.GetValue(FirstNameProperty); }
            set { this.SetValue(FirstNameProperty, value); }
        }

        public string LastName
        {
            get { return (string)this.GetValue(LastNameProperty); }
            set { this.SetValue(LastNameProperty, value); }
        }

        public int YearOfBirth
        {
            get { return (int)this.GetValue(YearOfBirthProperty); }
            set { this.SetValue(YearOfBirthProperty, value); }
        }

        public GuitarPlayerViewModel(GuitarPlayer guitarPlayer)
        {
            Id = guitarPlayer.Id;
            FirstName = guitarPlayer.FirstName;
            LastName = guitarPlayer.LastName;
            YearOfBirth = guitarPlayer.YearOfBirth;
        }
    }
}

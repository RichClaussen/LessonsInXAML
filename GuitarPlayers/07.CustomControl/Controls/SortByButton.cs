using System.Windows;
using System.Windows.Controls;

namespace GuitarPlayers.Controls
{
    public class SortByButton : Button
    {
        public static readonly DependencyProperty SortByProperty = DependencyProperty.Register(
            "SortBy",
            typeof(string),
            typeof(SortByButton),
            new FrameworkPropertyMetadata(string.Empty, SortByChanged));

        public string SortBy
        {
            get { return (string)this.GetValue(SortByProperty); }
            set { this.SetValue(SortByProperty, value); }
        }

        static SortByButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SortByButton), new FrameworkPropertyMetadata(typeof(Button)));
        }

        private static void SortByChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var button = obj as SortByButton;

            if (button != null && args.NewValue != null)
            {
                button.Content = string.Format("Sort By {0}", args.NewValue);
            }
        }
    }
}

using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace GuitarPlayers.Behaviors
{
    public class CloseWindowBehavior : DependencyObject
    {
        public static readonly DependencyProperty CloseWindow =
            DependencyProperty.RegisterAttached("CloseWindow",
                                                typeof(Window),
                                                typeof(CloseWindowBehavior),
                                                new PropertyMetadata(OnCloseWindowChanged));

        public static Window GetCloseWindow(DependencyObject target)
        {
            return target.GetValue(CloseWindow) as Window;
        }

        public static void SetCloseWindow(DependencyObject target, Window value)
        {
            target.SetValue(CloseWindow, value);
        }

        private static void OnCloseWindowChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            var menuItem = target as MenuItem;
            var button = target as ButtonBase;

            if (e.NewValue != null && e.OldValue == null)
            {
                if (menuItem != null) menuItem.Click += OnClick;
                if (button != null) button.Click += OnClick;
            }
            else if ((e.NewValue == null) && (e.OldValue != null))
            {
                if (menuItem != null) menuItem.Click -= OnClick;
                if (button != null) button.Click -= OnClick;
            }
        }

        private static void OnClick(object sender, RoutedEventArgs e)
        {
            var source = e.Source as Control;
            if (source == null) return;

            var window = GetCloseWindow(source);
            if (window == null) return;

            window.Close();
        }
    }
}

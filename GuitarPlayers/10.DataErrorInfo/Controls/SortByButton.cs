using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

using GuitarPlayers.Models;

namespace GuitarPlayers.Controls
{
    public class SortByButton : Button
    {
        public static readonly DependencyProperty SortByProperty = DependencyProperty.Register(
            "SortBy",
            typeof(Enum),
            typeof(SortByButton),
            new FrameworkPropertyMetadata(OrderBy.Id, SortByChanged));

        public OrderBy SortBy
        {
            get { return (OrderBy)this.GetValue(SortByProperty); }
            set { this.SetValue(SortByProperty, value); }
        }

        public static readonly DependencyProperty SortLabelProperty = DependencyProperty.Register(
            "SortLabel",
            typeof(string),
            typeof(SortByButton),
            new FrameworkPropertyMetadata(string.Empty, SortByChanged));

        public string SortLabel
        {
            get { return (string)this.GetValue(SortLabelProperty); }
            set { this.SetValue(SortLabelProperty, value); }
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
                button.Content = string.Format("{0} {1}", button.SortLabel, LocalizeEnum(button.SortBy));
            }
        }

        private static string LocalizeEnum(object value)
        {
            if (value == null) return null;

            FieldInfo fi = value.GetType().GetField(value.ToString());

            if (fi == null) return null;

            var attributes = (LocalizableAttribute[])fi.GetCustomAttributes(typeof(LocalizableAttribute), false);

            return (attributes.Length > 0) && !String.IsNullOrEmpty(attributes[0].Description)
                       ? attributes[0].Description
                       : value.ToString();
        }
    }
}

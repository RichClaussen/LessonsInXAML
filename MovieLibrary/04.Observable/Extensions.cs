using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MovieLibrary
{
    public static class Extensions
    {
        public static void AddRange<T>(this ObservableCollection<T> items, ICollection<T> newItems)
        {
            foreach (T movie in newItems)
            {
                items.Add(movie);
            }
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MovieLibrary
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        private static readonly Dictionary<string, PropertyChangedEventArgs> eventArgCache;

        static ObservableObject()
        {
            eventArgCache = new Dictionary<string, PropertyChangedEventArgs>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (null != handler)
            {
                PropertyChangedEventArgs args = GetPropertyChangedEventArgs(propertyName);
                handler(this, args);
            }
        }

        private static PropertyChangedEventArgs GetPropertyChangedEventArgs(string propertyName)
        {
            PropertyChangedEventArgs args;

            lock (typeof(ObservableObject))
            {
                if (!eventArgCache.TryGetValue(propertyName, out args))
                {
                    eventArgCache.Add(propertyName, new PropertyChangedEventArgs(propertyName));
                }

                args = eventArgCache[propertyName];
            }

            return args;
        }
    }
}

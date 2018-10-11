using System;
using System.Collections.Generic;
using System.Linq;

namespace GuitarPlayers
{
    public class DataErrors
    {
        private readonly Dictionary<string, string> errors = new Dictionary<string, string>();

        public string this[string field]
        {
            get
            {
                string message = null;
                if (errors.ContainsKey(field))
                {
                    message = errors[field];
                }

                return message;
            }
        }

        public EventHandler<DataErrorsChangedEventArgs> DataErrorsChanged;

        public int Count { get { return errors.Count; } }

        public void Add(string field, string error)
        {
            if (!errors.ContainsKey(field))
            {
                errors.Add(field, error);
            }
            else
            {
                errors[field] = error;
            }
            OnDataErrorsChanged();
        }

        public void Clear(string field)
        {
            if (errors.ContainsKey(field))
            {
                errors.Remove(field);
                OnDataErrorsChanged();
            }
        }

        public void Clear(string field, string error)
        {
            if (this[field] == error) Clear(field);
        }

        public void ClearAll()
        {
            errors.Clear();
            OnDataErrorsChanged();
        }

        public override string ToString()
        {
            return string.Join(", ", errors.Values.Distinct().ToArray());
        }

        public bool ContainsField(string field)
        {
            return errors.ContainsKey(field);
        }

        private void OnDataErrorsChanged()
        {
            if (DataErrorsChanged != null)
            {
                DataErrorsChanged(this, new DataErrorsChangedEventArgs());
            }
        }
    }

    public class DataErrorsChangedEventArgs : EventArgs { }
}

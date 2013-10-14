using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GuitarPlayers.ViewModels
{
    public class SortButtonsViewModel<T>
        : CultureAwareViewModelBase
        where T : struct, IComparable, IFormattable, IConvertible
    {
        private T sortOrder;

        public ObservableCollection<T> Buttons { get; private set; }

        public ICommand SortCommand { get; private set; }

        public EventHandler<SortOrderChangedEventArgs<T>> SortOrderChanged;

        public SortButtonsViewModel()
        {
            Buttons = new ObservableCollection<T>();

            foreach (T button in Enum.GetValues(typeof(T)))
            {
                Buttons.Add(button);
            }

            SortCommand = new Command
            {
                CanExecuteDelegate = orderBy => !this.sortOrder.Equals(orderBy),
                ExecuteDelegate = orderBy => this.Sort((T)orderBy),
            };

            this.Sort(sortOrder);
        }

        private void Sort(T sortOrder)
        {
            this.sortOrder = sortOrder;

            var handler = this.SortOrderChanged;
            if (null != handler)
            {
                handler(this, new SortOrderChangedEventArgs<T>(sortOrder));
            }
        }
    }

    public class SortOrderChangedEventArgs<T> : EventArgs
    {
        public T SortOrder { get; private set; }

        public SortOrderChangedEventArgs(T sortOrder)
        {
            this.SortOrder = sortOrder;
        }
    }
}

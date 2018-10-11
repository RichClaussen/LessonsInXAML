using System.ComponentModel;

namespace GuitarPlayers
{
    public abstract class ValidatingObservableItem : ObservableItem, IDataErrorInfo
    {

        protected DataErrors Errors { get; private set; }
        public virtual string Error { get { return Errors.ToString(); } }

        public string this[string field]
        {
            get { return Errors != null ? Errors[field] : null; }
        }

        protected ValidatingObservableItem()
        {
            Errors = new DataErrors();
            Errors.DataErrorsChanged += OnDataErrorsChanged;
        }

        protected virtual void OnDataErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            OnPropertyChanged(() => Error);
        }
    }
}

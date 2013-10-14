using System.ComponentModel;
using System.Dynamic;

using GuitarPlayers.ViewModels;

using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace GuitarPlayers
{
    public abstract class ValidatingObservableItem : ObservableItem, IDataErrorInfo
    {
        private ObjectValidator validator;

        protected DataErrors Errors { get; private set; }
        public virtual string Error { get { return Errors.ToString(); } }

        public string this[string field]
        {
            get
            {
                Validate();
                return Errors != null ? Errors[field] : null;
            }
        }

        protected ValidatingObservableItem()
        {
            validator = new ObjectValidator(this.GetType());

            Errors = new DataErrors();
            Errors.DataErrorsChanged += OnDataErrorsChanged;
        }

        protected virtual void OnDataErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            OnPropertyChanged(() => Error);
        }

        private void Validate()
        {
            var x = validator.Validate(this);
            foreach (var validationResult in x)
            {
                Errors.Add(validationResult.Key, validationResult.Message);
            }
        }
    }
}

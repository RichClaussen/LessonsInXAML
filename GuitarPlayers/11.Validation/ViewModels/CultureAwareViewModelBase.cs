using System.Globalization;
using System.Threading;

using GuitarPlayers.Properties;

namespace GuitarPlayers.ViewModels
{
    public abstract class CultureAwareViewModelBase : ObservableItem
    {
        public Resources Resources { get { return new Resources(); } }

        protected internal virtual void ChangeCulture(string culture)
        {
            if (!Thread.CurrentThread.CurrentUICulture.Name.Equals(culture))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            }

            OnPropertyChanged(() => Resources);
        }
    }
}

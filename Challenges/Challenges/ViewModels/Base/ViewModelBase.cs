using Prism.Mvvm;
using Prism.Navigation;

namespace Challenges.ViewModels.Base
{
    public abstract class ViewModelBase : BindableBase, IInitialize
    {
        protected INavigationService _navigationService;

        public ViewModelBase() { }

        public ViewModelBase(INavigationService navigationService)
		{
            _navigationService = navigationService;
        }

        #region Virtual methods
        public virtual void Initialize(INavigationParameters parameters) { }
        #endregion

        public void Alert (string message)
        {
            Prism.PrismApplicationBase.Current.MainPage.DisplayAlert("Challenges", message, "Ok");
        }

    }
}
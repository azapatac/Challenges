using Prism.Mvvm;
using Prism.Navigation;

namespace Challenges.ViewModels.Base
{
    public abstract class ViewModelBase : BindableBase, INavigationAware
    {
        protected INavigationService _navigationService;

        public ViewModelBase(INavigationService navigationService)
		{
            _navigationService = navigationService;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }

        public virtual void OnNavigatedTo(INavigationParameters parameters) { }

        public void Alert (string message)
        {
            Prism.PrismApplicationBase.Current.MainPage.DisplayAlert("Challenges", message, "Ok");
        }
    }
}
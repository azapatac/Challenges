using Challenges.Components.Loading;
using Prism.Mvvm;
using Prism.Navigation;

namespace Challenges.ViewModels.Base
{
    public abstract class ViewModelBase : BindableBase, INavigationAware
    {
        protected ILoadingComponent _loadingComponent;
        protected INavigationService _navigationService;

        public ViewModelBase() { }

        public ViewModelBase(INavigationService navigationService, ILoadingComponent loadingComponent)
		{
            _navigationService = navigationService;
            _loadingComponent = loadingComponent;
        }

        #region Virtual methods
        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }
        public virtual void OnNavigatedTo(INavigationParameters parameters) { }
        #endregion

        public void Alert (string message, string title = "Challenges")
        {
            Prism.PrismApplicationBase.Current.MainPage.DisplayAlert(title, message, "Ok");
        }        
    }
}
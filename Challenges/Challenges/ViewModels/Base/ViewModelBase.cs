using Prism.Mvvm;
using Prism.Navigation;

namespace Challenges.ViewModels.Base
{
    public abstract class ViewModelBase : BindableBase, INavigationAware
    {
		public ViewModelBase()
		{
		}

        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }

        public virtual void OnNavigatedTo(INavigationParameters parameters) { }
    }
}
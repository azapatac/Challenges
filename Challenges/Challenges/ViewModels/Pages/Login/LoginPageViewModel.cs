using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Challenges.ViewModels.Base;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Challenges.ViewModels.Pages.Login
{
    public class LoginPageViewModel : ViewModelBase
	{
        public ICommand LoginCommand => new AsyncCommand(Login);        
        public ICommand OtherOptionCommand => new DelegateCommand<string>(OtherOption);

        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        private async Task Login()
        {
            await Task.Delay(3000);
        }

        private void OtherOption(string option)
        {
            Alert(option);
        }
    }
}
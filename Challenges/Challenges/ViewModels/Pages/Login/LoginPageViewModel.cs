using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Challenges.Common.Interfaces.Services.Login;
using Challenges.Common.Models.Login;
using Challenges.ViewModels.Base;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Challenges.ViewModels.Pages.Login
{
    public class LoginPageViewModel : ViewModelBase
	{
        readonly ILoginService _loginService;

        public ICommand LoginCommand => new AsyncCommand(Login);        
        public ICommand OtherOptionCommand => new DelegateCommand<string>(OtherOption);

        public LoginPageViewModel(INavigationService navigationService, ILoginService loginService) : base(navigationService)
        {
            _loginService = loginService;
        }

        private async Task Login()
        {
            var login = new LoginRequest
            {
                Email = "user2@mail.com",
                Password = "Password2"
            };


            var response = await _loginService.Login(login);

        }

        private void OtherOption(string option)
        {
            Alert(option);
        }
    }
}
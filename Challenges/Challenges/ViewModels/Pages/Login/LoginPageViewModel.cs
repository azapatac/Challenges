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

        public string Email { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand => new AsyncCommand(Login);        
        public ICommand OtherOptionCommand => new DelegateCommand<string>(OtherOption);

        public LoginPageViewModel(INavigationService navigationService, ILoginService loginService) : base(navigationService)
        {
            _loginService = loginService;

#if DEBUG
            Email = "user2@mail.com";
            Password = "Password2";
#endif
        }

        private async Task Login()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                return;

            try
            {
                var login = new LoginRequest
                {
                    Email = Email,
                    Password = Password
                };

                var response = await _loginService.Login(login);

                var parameters = new NavigationParameters();
                parameters.Add("token", response.AuthorizationToken);

                await _navigationService.NavigateAsync("ChallengesPage", parameters);
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }
        }

        private void OtherOption(string option)
        {
            Alert(option);
        }
    }
}
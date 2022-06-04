namespace Challenges.Settings
{
    using Challenges.ViewModels.Pages.Challenges;
    using Challenges.ViewModels.Pages.Login;
    using Challenges.Views.Pages.Challenges;
    using Challenges.Views.Pages.Login;
    using Prism.Ioc;
    using Xamarin.Forms;

    public static class PagesContainer
    {
        public static void Register(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ChallengesPage, ChallengesPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
        }
    }
}
namespace Challenges.Settings
{
    using Challenges.ViewModels.Pages.Login;
    using Challenges.Views.Pages.Login;
    using Prism.Ioc;

    public static class PagesContainer
    {
        public static void Register(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
        }
    }
}
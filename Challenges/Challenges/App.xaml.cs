using Challenges.Common.Constants.Navigation;
using Challenges.Settings;
using Challenges.Settings.Mapper;
using Prism;
using Prism.Ioc;

namespace Challenges
{
    public partial class App 
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync(NavigationPages.Login);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {            
            DependencyContainer.Register(containerRegistry);
            MapperContainer.Register(containerRegistry);
            PagesContainer.Register(containerRegistry);
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}
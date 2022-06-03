using Challenges.Settings;
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

            await NavigationService.NavigateAsync("LoginPage");            
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {            
            PagesContainer.Register(containerRegistry);
            DependencyContainer.Register(containerRegistry);
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


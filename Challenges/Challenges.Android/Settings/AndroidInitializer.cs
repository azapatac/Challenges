using Challenges.Components.Loading;
using Challenges.Droid.Dependency;
using Prism;
using Prism.Ioc;

namespace Challenges.Droid.Settings
{
    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILoadingComponent, LoadingComponent>();
        }
    }
}
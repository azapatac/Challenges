using Challenges.Components.Loading;
using Challenges.iOS.Dependency;
using Prism;
using Prism.Ioc;

namespace Challenges.iOS.Settings
{
    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILoadingComponent, LoadingComponent>();
        }
    }
}
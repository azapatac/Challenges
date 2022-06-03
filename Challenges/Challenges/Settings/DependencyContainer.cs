using Challenges.Common.Interfaces.Components.Network;
using Challenges.Common.Interfaces.Services.Login;
using Challenges.Common.Interfaces.WebServices.Login;
using Challenges.Components.Network;
using Challenges.Domain.Services.Login;
using Challenges.Infraestructure.WebServices.Login;
using Prism.Ioc;

namespace Challenges.Settings
{
    public static class DependencyContainer
    {
        public static void Register(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILoginService, LoginService>();
            containerRegistry.RegisterSingleton<ILoginWebService, LoginWebService>();

            containerRegistry.RegisterSingleton<INetworkComponent, NetworkComponent>();
        }
    }
}
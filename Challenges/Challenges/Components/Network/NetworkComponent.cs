using Challenges.Common.Interfaces.Components.Network;
using Xamarin.Essentials;

namespace Challenges.Components.Network
{
    public class NetworkComponent : INetworkComponent
    {
        public bool IsConnected()
        {
            return Connectivity.NetworkAccess == NetworkAccess.Internet;
        }
    }
}
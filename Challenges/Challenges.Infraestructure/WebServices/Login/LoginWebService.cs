using System.Net.Http;
using System.Threading.Tasks;
using Challenges.Common.Interfaces.Components.Network;
using Challenges.Common.Interfaces.WebServices.Login;
using Challenges.Common.Models.Login;
using Challenges.Common.Models.Response.Login;
using Challenges.Infraestructure.WebServices.Base;
using Refit;

namespace Challenges.Infraestructure.WebServices.Login
{
    public interface ILoginEndpont
    {
        [Post("/UserSignIn")]
        Task<HttpResponseMessage> Login([Body] LoginRequest login);
    }

	public class LoginWebService : BaseWebService, ILoginWebService
	{
        private ILoginEndpont _endpoint;

        public LoginWebService(INetworkComponent networkComponent) : base(networkComponent)
        {
            _endpoint = GetServiceToExecute<ILoginEndpont>();
        }

        public async Task<object> Login(LoginRequest request)
        {
            return await ExecuteWebService<LoginResponse>(async () => { return await _endpoint.Login(request); });
        }
    }
}
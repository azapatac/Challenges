using System.Threading.Tasks;
using Challenges.Common.Interfaces.Services.Login;
using Challenges.Common.Interfaces.WebServices.Login;
using Challenges.Common.Models.Login;
using Challenges.Common.Models.Response.Login;

namespace Challenges.Domain.Services.Login
{
    public class LoginService : ILoginService
	{

        readonly ILoginWebService _loginWebService;

        public LoginService(ILoginWebService loginWebService)
		{
            _loginWebService = loginWebService;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            return await _loginWebService.Login(request);
        }
    }
}
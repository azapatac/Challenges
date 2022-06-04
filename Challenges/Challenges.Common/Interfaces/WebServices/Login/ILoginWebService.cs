using System.Threading.Tasks;
using Challenges.Common.Models.Login;
using Challenges.Common.Models.Response.Login;

namespace Challenges.Common.Interfaces.WebServices.Login
{
    public interface ILoginWebService
	{
		Task<LoginResponse> Login(LoginRequest request);
	}
}
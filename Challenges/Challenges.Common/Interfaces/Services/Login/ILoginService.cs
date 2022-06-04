using System.Threading.Tasks;
using Challenges.Common.Models.Login;
using Challenges.Common.Models.Response.Login;

namespace Challenges.Common.Interfaces.Services.Login
{
    public interface ILoginService
	{
		Task<LoginResponse> Login(LoginRequest request);
	}
}
using System.Threading.Tasks;
using Challenges.Common.Models.Login;

namespace Challenges.Common.Interfaces.Services.Login
{
    public interface ILoginService
	{
		Task<object> Login(LoginRequest request);
	}
}
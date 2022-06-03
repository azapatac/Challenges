using System.Threading.Tasks;
using Challenges.Common.Models.Login;

namespace Challenges.Common.Interfaces.WebServices.Login
{
    public interface ILoginWebService
	{
		Task<object> Login(LoginRequest request);
	}
}
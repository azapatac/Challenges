using System.Collections.Generic;
using System.Threading.Tasks;
using Challenges.Common.Models.Requests.Challenges;

namespace Challenges.Common.Interfaces.WebServices.Challenges
{
    public interface IChallengesWebService
	{
		Task<List<ChallengeResponse>> GetAll(string token);
	}
}
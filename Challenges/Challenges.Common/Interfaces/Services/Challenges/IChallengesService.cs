using System.Collections.Generic;
using System.Threading.Tasks;
using Challenges.Common.Models.Requests.Challenges;

namespace Challenges.Common.Interfaces.Services.Challenges
{
    public interface IChallengesService
	{
		Task<List<ChallengeResponse>> GetAll(string token);
	}
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Challenges.Common.Interfaces.Services.Challenges;
using Challenges.Common.Interfaces.WebServices.Challenges;
using Challenges.Common.Models.Requests.Challenges;

namespace Challenges.Domain.Services.Challenges
{
    public class ChallengesService : IChallengesService
	{
        readonly IChallengesWebService _challengesWebService;

		public ChallengesService(IChallengesWebService challengesWebService)
		{
            _challengesWebService = challengesWebService;
		}

        public async Task<List<ChallengeResponse>> GetAll(string token)
        {
            return await _challengesWebService.GetAll(token);
        }
    }
}
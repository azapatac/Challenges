using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Challenges.Common.Interfaces.Components.Network;
using Challenges.Common.Interfaces.WebServices.Challenges;
using Challenges.Common.Models.Requests.Challenges;
using Challenges.Infraestructure.WebServices.Base;
using Refit;

namespace Challenges.Infraestructure.WebServices.Challenges
{
    public interface IChallengesEndpoint
    {
        [Get("/Challenges")]
        Task<HttpResponseMessage> GetAll([Header("Authorization")] string authorization);
    }

    public class ChallengesWebService : BaseWebService, IChallengesWebService
	{
        readonly IChallengesEndpoint _endpoint;

        public ChallengesWebService(INetworkComponent networkComponent) : base(networkComponent)
        {
            _endpoint = GetServiceToExecute<IChallengesEndpoint>();
        }

        public async Task<List<ChallengeResponse>> GetAll(string token)
        {
            return await ExecuteWebService<List<ChallengeResponse>>(async () => { return await _endpoint.GetAll(token); });
        }
    }
}
using AutoMapper;
using Challenges.Common.Models.Requests.Challenges;
using Challenges.ViewModels.Domain;

namespace Challenges.Settings.Mapper.Profiles
{
    public class ChallengeProfile : Profile
	{
		public ChallengeProfile()
		{
			CreateMap<ChallengeResponse, ChallengeViewModel>().ReverseMap();
		}
	}
}
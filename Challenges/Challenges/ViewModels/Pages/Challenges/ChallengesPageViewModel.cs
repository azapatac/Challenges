using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Challenges.Common.Interfaces.Services.Challenges;
using Challenges.Common.Models.Requests.Challenges;
using Challenges.Components.Loading;
using Challenges.ViewModels.Base;
using Challenges.ViewModels.Domain;
using Prism.Navigation;

namespace Challenges.ViewModels.Pages.Challenges
{
    public class ChallengesPageViewModel : ViewModelBase
    {
        readonly IChallengesService _challengesService;
        readonly IMapper _mapper;

        public int CompletedChallenges { get; set; }
        public ICollection<ChallengeViewModel> Challenges { get; set; }

        public ChallengesPageViewModel(INavigationService navigationService, ILoadingComponent loadingComponent, IChallengesService challengesService, IMapper mapper) : base(navigationService, loadingComponent)
        {
            _challengesService = challengesService;
            _mapper = mapper;
        }
        
        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            var token  = parameters.GetValue<string>("token");            
            var data = await LoadData(token);
            ConfigureData(data);
        }

        private async Task<List<ChallengeResponse>> LoadData(string token)
        {
            var data = new List<ChallengeResponse>();

            try
            {
                using (_loadingComponent.Show())
                {
                    data = await _challengesService.GetAll(token);
                }
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }

            return data;
        }

        private void ConfigureData(List<ChallengeResponse> data)
        {
            var challenges = _mapper.Map<List<ChallengeViewModel>>(data);

            challenges.ForEach((challenge) =>
            {
                challenge.IsCompleted = challenge.Percentage == 1;
                challenge.Select += Challenge_Select; 
            });

            CompletedChallenges = challenges.Where(x => x.IsCompleted).ToList().Count;

            Challenges = new ObservableCollection<ChallengeViewModel>(challenges);
        }

        private void Challenge_Select(ChallengeViewModel challenge)
        {
            Alert(challenge.Description, challenge.Title);
        }
    }
}
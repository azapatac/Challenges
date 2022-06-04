using System;
using Challenges.ViewModels.Base;

namespace Challenges.ViewModels.Domain
{
    public class ChallengeViewModel : ViewModelBase
	{
		public int CurrentPoints { get; set; }
		public string Description { get; set; }
		public string Title { get; set; }
		public int TotalPoints { get; set; }

        public bool IsCompleted { get; set; }
        public double Percentage { get  { return Convert.ToDouble(CurrentPoints) / Convert.ToDouble(TotalPoints); } }

        public ChallengeViewModel()
		{
		}


	}
}
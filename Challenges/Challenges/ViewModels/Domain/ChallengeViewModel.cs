using System;
using System.Windows.Input;
using Challenges.Delegates;
using Challenges.ViewModels.Base;
using Prism.Commands;

namespace Challenges.ViewModels.Domain
{
    public class ChallengeViewModel : ViewModelBase
	{
		public event ChallengeDelegate Select;

		public int CurrentPoints { get; set; }
		public string Description { get; set; }
		public string Title { get; set; }
		public int TotalPoints { get; set; }

        public bool IsCompleted { get; set; }
        public double Percentage { get  { return Math.Round(Convert.ToDouble(CurrentPoints) / Convert.ToDouble(TotalPoints), 2); } }

		public ICommand SelectCommand { get; set; }

		public ChallengeViewModel()
		{
			SelectCommand = new DelegateCommand(() => { Select?.Invoke(this); });
		}
	}
}
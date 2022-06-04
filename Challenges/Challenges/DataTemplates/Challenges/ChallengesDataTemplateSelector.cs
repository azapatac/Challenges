using Challenges.ViewModels.Domain;
using Xamarin.Forms;

namespace Challenges.DataTemplates.Challenges
{
    public class ChallengesDataTemplateSelector : DataTemplateSelector
	{
        public DataTemplate CompletedTemplate { get; set; }
        public DataTemplate IncompletedTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((ChallengeViewModel)item).IsCompleted ? CompletedTemplate: IncompletedTemplate;
        }
    }
}
namespace Challenges.Common.Models.Requests.Challenges
{
    public class ChallengeResponse
	{
        public int CurrentPoints { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public int TotalPoints { get; set; }
	}
}
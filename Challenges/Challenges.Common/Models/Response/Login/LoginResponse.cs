namespace Challenges.Common.Models.Response.Login
{
    public class LoginResponse
	{
        public string AuthorizationToken { get; set; }
        public string Email { get; set; }       
        public string Firstname { get; set; }
        public string Surname { get; set; }
    }
}
using Application.Functions.User;

namespace Application.Services
{
    public interface IAuthorizationService
    {
        public string CreateUserToken(string userEmail, List<string> roles);

        public RefreshToken CreateRefreshToken();
    }
}

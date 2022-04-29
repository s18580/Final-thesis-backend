using Application.Functions.User;

namespace Application.Services
{
    public interface IAuthorizationService
    {
        public string CreateUserToken(LoggedUserDTO user);
    }
}

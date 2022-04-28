namespace Application.Services
{
    public interface IAuthenticationService
    {
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] salt);
        public bool VerifyPassword(string email, string password, byte[] properPassHash, byte[] properSalt);
    }
}

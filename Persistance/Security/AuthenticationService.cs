using Application.Services;
using System.Security.Cryptography;
using System.Text;

namespace Persistance.Security
{
    public class AuthenticationService : IAuthenticationService
    {
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] salt)
        {
            using (var hmc = new HMACSHA512())
            {
                salt = hmc.Key;
                passwordHash = hmc.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPassword(string password, byte[] properPassHash, byte[] properSalt)
        {
            using (var hmc = new HMACSHA512(properSalt))
            {
                var hashToValidate = hmc.ComputeHash(Encoding.UTF8.GetBytes(password));
                return properPassHash.SequenceEqual(hashToValidate);
            }
        }
    }
}

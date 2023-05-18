using MercuryProject.Application.Common.Interfaces.Services;
using MercuryProject.Infrastructure.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace MercuryProject.Infrastructure.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly HashSettings _settings;

        public PasswordHasher(IOptions<HashSettings> settings)
        {
            _settings = settings.Value;
        }

        public string Hash(string password)
        {
            var sha = new HMACSHA256(Encoding.UTF8.GetBytes(_settings.Key));
            var bytes = Encoding.UTF8.GetBytes(password);
            var hashedPassword = sha.ComputeHash(bytes);

            return Convert.ToBase64String(hashedPassword);
        }
    }
}

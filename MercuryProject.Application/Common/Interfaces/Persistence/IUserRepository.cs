using ErrorOr;
using MercuryProject.Domain.User;
using MercuryProject.Domain.User.ValueObjects;

namespace MercuryProject.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<Domain.User.User?> GetUserById(UserId id);

        Task<Domain.User.User>? GetUserByEmail(string email);
        Task<Domain.User.User>? GetUserByUsername(string username);
        Task<ErrorOr<bool>> AddAdminByUsername(string username);
        Task UpdateUser(Domain.User.User user);
        public UserId GetUserId();
        void Add(Domain.User.User user);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MercuryProject.Domain.User;
using MercuryProject.Domain.User.ValueObjects;

namespace MercuryProject.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<User>?GetUserByEmail(string email);
        Task<User>?GetUserByUsername(string username);
        Task<ErrorOr<bool>> AddAdminByUsername(string username);
        Task UpdateUser(string username);
        public string GetUserId();
        void Add(User user);
    }
}

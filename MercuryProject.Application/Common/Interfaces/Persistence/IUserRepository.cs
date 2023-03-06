using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercuryProject.Domain.User;

namespace MercuryProject.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User?GetUserByEmail(string email);
        User?GetUserByUsername(string username);
        void Add(User user);
    }
}

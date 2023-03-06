using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace MercuryProject.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        //private readonly MercuryProjectDbContext _dbContext;
        private static readonly List<User> _users = new ();

        //public UserRepository(MercuryProjectDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        //public async Task<User> GetUserByEmail(string email)
        //{
        //    var user = _dbContext.Set<User>().Where(x => x.Email == email).ToListAsync();
        //    return;
        //}

        //public Task<User> GetUserByUsername(string username)
        //{
        //    throw new NotImplementedException();
        //}

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }

        public User? GetUserByUsername(string username)
        {
            return _users.SingleOrDefault(u => u.Username == username);
        }

        public void Add(User user)
        {
            _users.Add(user);
        }
    }
}

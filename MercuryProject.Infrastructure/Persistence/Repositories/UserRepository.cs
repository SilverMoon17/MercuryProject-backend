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
        private readonly MercuryProjectDbContext _dbContext;

        public UserRepository(MercuryProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User? GetUserByEmail(string email)
        {
            var user = _dbContext.Set<User>().FirstOrDefault(u => u.Email == email);
            return user;
        }

        public User? GetUserByUsername(string username)
        {
            var user = _dbContext.Set<User>().FirstOrDefault(u => u.Username == username);
            return user;
        }

        public void Add(User user)
        {
            _dbContext.AddAsync(user);
            _dbContext.SaveChangesAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Domain.Common.Errors;
using MercuryProject.Domain.User;
using MercuryProject.Domain.User.ValueObjects;
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

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Username == username);
        }

        public void Add(User user)
        {
            _dbContext.AddAsync(user);
            _dbContext.SaveChangesAsync();
        }
    }
}

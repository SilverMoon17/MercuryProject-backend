using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Domain.Common.Errors;
using MercuryProject.Domain.User;
using MercuryProject.Domain.User.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MercuryProject.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MercuryProjectDbContext _dbContext;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserRepository(MercuryProjectDbContext dbContext, IHttpContextAccessor contextAccessor)
        {
            _dbContext = dbContext;
            _contextAccessor = contextAccessor;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<ErrorOr<bool>> AddAdminByUsername(string username)
        {
            var user = await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Username == username);
            if (user != null)
            {
                user.Role = "Admin";
                _dbContext.Update(user);
                await UpdateUser(username);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return Errors.User.UserNotFoundError;
        }

        public async Task UpdateUser(string username)
        {
            var user = await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Username == username);

            user.UpdatedDateTime = DateTime.UtcNow;
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public string GetUserId()
        {
            return _contextAccessor.HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
        }

        public void Add(User user)
        {
            _dbContext.AddAsync(user);
            _dbContext.SaveChangesAsync();
        }
    }
}

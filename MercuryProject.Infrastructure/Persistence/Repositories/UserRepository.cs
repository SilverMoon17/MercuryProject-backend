using ErrorOr;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Domain.Common.Errors;
using MercuryProject.Domain.User;
using MercuryProject.Domain.User.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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

        public async Task<User?> GetUserById(UserId id)
        {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<ErrorOr<bool>> AddAdminByUsername([FromBody] string username)
        {
            var user = await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Username == username);
            if (user != null)
            {
                user.Role = "Admin";
                await UpdateUser(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return Errors.User.UserNotFoundError;
        }

        public async Task UpdateUser(User user)
        {
            user.UpdatedDateTime = DateTime.UtcNow;
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public UserId GetUserId()
        {
            var userId = _contextAccessor.HttpContext.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
            return UserId.Create(Guid.Parse(userId));
        }

        public void Add(User user)
        {
            _dbContext.AddAsync(user);
            _dbContext.SaveChangesAsync();
        }
    }
}

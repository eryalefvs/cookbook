using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.DataAccess.Repositories
{
    public class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
    {
        private readonly CookBookDbContext _dbContext;

        public UserRepository(CookBookDbContext dbContext) => _dbContext = dbContext;

        public async Task Add(User user) => await _dbContext.Users.AddAsync(user);

        public async Task<bool> ExistActiveUserWithEmail(string email) => 
            await _dbContext.Users.AnyAsync(user => user.Email.Equals(email) && user.Active);
    }
}

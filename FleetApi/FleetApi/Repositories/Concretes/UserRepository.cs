using FleetApi.Models;
using FleetApi.Persistance;
using FleetApi.Repositories.Abstracts;
using System.Threading.Tasks;

namespace FleetApi.Repositories.Concretes
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<User> CreateUser(User user)
        {
            var result = await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}

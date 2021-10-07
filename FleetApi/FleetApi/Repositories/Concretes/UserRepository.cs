using FleetApi.Models;
using FleetApi.Persistance;
using FleetApi.Repositories.Abstracts;
using FleetApi.ViewModels;
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
        public async Task<User> CreateUser(UsersViewModel user)
        {
            User users = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                IdNumber = user.IdNumber,
                Password = user.Password,
                Email = user.Email,
                Account = new Account
                {
                    Balance = user.AccountBalance,

                }
            };
            var result = await dbContext.Users.AddAsync(users);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}

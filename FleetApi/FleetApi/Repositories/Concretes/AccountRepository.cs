using FleetApi.Models;
using FleetApi.Persistance;
using FleetApi.Repositories.Abstracts;
using System.Threading.Tasks;

namespace FleetApi.Repositories.Concretes
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext dbContext;
        public AccountRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Account> AddEmployee(Account account)
        {
            var result = await dbContext.Accounts.AddAsync(account);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}

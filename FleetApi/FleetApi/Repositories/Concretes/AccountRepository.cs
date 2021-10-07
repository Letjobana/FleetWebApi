using FleetApi.Models;
using FleetApi.Persistance;
using FleetApi.Repositories.Abstracts;
using FleetApi.ViewModels;
using System.Linq;
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
        public async Task<Account> Deposit(AccountViewModel account)
        {
            Account acc = dbContext.Accounts.Where(r => r.UserId == account.UserId).FirstOrDefault();
            acc.Balance += account.Amount;
            dbContext.SaveChanges();
            return acc;
        }
    }
}

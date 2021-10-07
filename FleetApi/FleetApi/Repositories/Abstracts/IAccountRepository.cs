using FleetApi.Models;
using System.Threading.Tasks;

namespace FleetApi.Repositories.Abstracts
{
    public interface IAccountRepository
    {
        Task<Account> AddEmployee(Account account);
    }
}

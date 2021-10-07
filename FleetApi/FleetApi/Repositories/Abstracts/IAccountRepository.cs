using FleetApi.Models;
using FleetApi.ViewModels;
using System.Threading.Tasks;

namespace FleetApi.Repositories.Abstracts
{
    public interface IAccountRepository
    {
        Task<Account> Deposit(AccountViewModel account);
    }
}

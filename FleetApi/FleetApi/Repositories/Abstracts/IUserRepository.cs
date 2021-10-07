using FleetApi.Models;
using FleetApi.ViewModels;
using System.Threading.Tasks;

namespace FleetApi.Repositories.Abstracts
{
    public interface IUserRepository
    {
        Task<User> CreateUser(UsersViewModel user);
    }
}

using FleetApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetApi.Repositories.Abstracts
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
    }
}

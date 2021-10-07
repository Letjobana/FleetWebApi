﻿using FleetApi.Persistance;
using FleetApi.Repositories.Abstracts;

namespace FleetApi.Repositories.Concretes
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context;
        public IUserRepository UserRepository { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            UserRepository = new UserRepository(context);
        }

    }
}

﻿using FleetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FleetApi.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}

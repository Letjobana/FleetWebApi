using FleetApi.Models;
using FleetApi.Persistance;
using FleetApi.Repositories.Abstracts;
using FleetApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetApi.Repositories.Concretes
{
    public class VehiclesRepository : IVehiclesRepository
    {
        ApplicationDbContext dbContext;
        public VehiclesRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Vehicle AddVehicle(VehicleViewModel vehicle)
        {
            try
            {
                Vehicle newVehicle = new Vehicle
                {
                    AccountId = vehicle.AccountId,
                    Color = vehicle.Color,
                    LicenseExpiry = vehicle.LicenseExpiry,
                    LicenseNumber = vehicle.LicenseNumber,
                    Model = vehicle.Model,
                    RegistrationPlate = vehicle.RegistrationPlate,
                    VIN = vehicle.VIN

                };
                Vehicle entity = dbContext.Vehicles.Add(newVehicle).Entity;
                dbContext.SaveChanges();
                return entity;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public Vehicle RenewLicense(int vehicleId)
        {
            try
            {
                Vehicle vehicle = dbContext.
                    Vehicles.Include(r => r.Account).
                    Where(r => r.Id == vehicleId).FirstOrDefault();

                if (vehicle.Account.Balance - 500 < 0)
                {
                    //insufficient funds

                }
                vehicle.LicenseExpiry = vehicle.LicenseExpiry.AddYears(1);
                vehicle.Account.Balance -= 500;
                dbContext.SaveChanges();

                return vehicle;

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Vehicle>> Search(string name)
        {
            IQueryable<Vehicle> query = dbContext.Vehicles;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.RegistrationPlate.Contains(name) ||
                e.LicenseNumber.Contains(name) || e.Model.Contains(name) ||
                e.VIN.Contains(name) );
            }
            return await query.ToListAsync();
        }
    }
}

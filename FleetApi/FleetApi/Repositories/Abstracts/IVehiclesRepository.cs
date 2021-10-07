using FleetApi.Models;
using FleetApi.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetApi.Repositories.Abstracts
{
    public interface IVehiclesRepository
    {

        public Vehicle AddVehicle(VehicleViewModel vehicle);

        public Vehicle RenewLicense(int vehicleId);
        Task<IEnumerable<Vehicle>> Search(string name);
    }
}

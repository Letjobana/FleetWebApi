using FleetApi.Models;
using FleetApi.Repositories.Abstracts;
using FleetApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public VehiclesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Route("Add")]
        public ActionResult AddVehicle([FromBody] VehicleViewModel vehicle)
        {
            unitOfWork.VehiclesRepository.AddVehicle(vehicle);
            return Ok();
        }

        [HttpPost]
        [Route("RenewLicense")]
        public ActionResult RenewLicense([FromBody] int vehicleId)
        {
            unitOfWork.VehiclesRepository.RenewLicense(vehicleId);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> Search(string name)
        {
            try
            {
                var result = await unitOfWork.VehiclesRepository.Search(name);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");
            }
        }
    }
}

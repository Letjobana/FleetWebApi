using FleetApi.Models;
using FleetApi.Repositories.Abstracts;
using FleetApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FleetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public AccountsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public ActionResult<Account> Deposit([FromBody] AccountViewModel account)
        {
            unitOfWork.AccountRepository.Deposit(account);
            return Ok();
        }

    }
}

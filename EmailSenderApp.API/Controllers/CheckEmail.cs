using EmailSenderApp.Application.Services.CheckEmailCodeServices;
using EmailSenderApp.Domain.Entites.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace EmailSenderApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CheckEmail : ControllerBase
    {
        private readonly ICheckService _checkService;

        public CheckEmail(ICheckService checkService)
        {
            _checkService = checkService;
        }

        //[HttpPost]
        //public async Task<IActionResult> CheckUserAsync(CheckingModel model)
        //{
        //    var result = await _checkService.CheckUserAsync(model);
        //    return Ok(result);
        //}
    }
}

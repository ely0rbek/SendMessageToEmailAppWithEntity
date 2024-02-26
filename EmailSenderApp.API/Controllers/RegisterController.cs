using EmailSenderApp.Application.Services.RegisterServices;
using EmailSenderApp.Domain.Entites.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync(RegisterModel model)
        {
            var result = await _registerService.AddUserAsync(model);
            return Ok(result);
        }
    }
}

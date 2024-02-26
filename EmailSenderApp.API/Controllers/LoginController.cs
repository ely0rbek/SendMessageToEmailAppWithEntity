using EmailSenderApp.Application.Services.LoginServices;
using EmailSenderApp.Domain.Entites.Models;
using Microsoft.AspNetCore.Mvc;


namespace EmailSenderApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(BaseEmailModel model)
        {
            var result = await _loginService.LoginAsync(model);
            return Ok(result);
        }
    }
}

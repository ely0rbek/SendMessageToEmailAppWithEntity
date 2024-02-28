using EmailSenderApp.Application.Services.AutServices;
using EmailSenderApp.Domain.Entites.AuthModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
                return  Ok(_authService.GenerateToken(user));
        }

        
    }
}

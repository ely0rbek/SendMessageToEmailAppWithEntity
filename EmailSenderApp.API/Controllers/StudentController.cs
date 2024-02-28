using EmailSenderApp.API.Attributes;
using EmailSenderApp.Domain.Entites.AuthModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class StudentController : Controller
    {
        [HttpGet]
        [IdentityFilter(Permission.GetAllStudents)]
        public ActionResult GetAllStudents()
        {
            return Ok("Hammasi olindi");
        }

        [HttpPost]
        public ActionResult CreateStudent()
        {
            return Ok("yaratildi");
        }

        
    }
}

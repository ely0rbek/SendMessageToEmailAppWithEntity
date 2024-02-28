using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class TeacherController : Controller
    {

        [HttpGet]
        [Authorize(Roles ="Teacher")]
        public ActionResult GetAllTeachers()
        {
            return Ok("hamma teacher olindi");
        }
        [HttpPost]
        [Authorize(Roles = "Teacher")]

        public ActionResult CreateTeacher()
        {
            return Ok("Teacher yaratildi");
        }

        
    }
}

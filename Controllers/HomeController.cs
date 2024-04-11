using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeGraphql.API.Controller
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Hello", "World" };
        }
    }
}
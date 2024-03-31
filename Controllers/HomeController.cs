using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
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
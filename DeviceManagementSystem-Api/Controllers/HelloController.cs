using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagementSystem_Api.Controllers
{
    [Route("api/hello")]
    public class HelloController: Controller
    {
        [Route("api/values")]
        public class ValueController : Controller
        {
            [HttpGet]
            public IActionResult Get()
            {
                return Ok("Hello");
            }
        }
    }
}

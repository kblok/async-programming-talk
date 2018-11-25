using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AsyncProgrammingWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            Task.Delay(500).GetAwaiter().GetResult();
            Task.Delay(500).GetAwaiter().GetResult();
            return "Foo";
        }
    }
}

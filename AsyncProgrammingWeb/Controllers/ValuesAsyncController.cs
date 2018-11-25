using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AsyncProgrammingWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesAsyncController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get()
        {
            await Task.Delay(500);
            await Task.Delay(500);
            return "Foo";
        }
    }
}

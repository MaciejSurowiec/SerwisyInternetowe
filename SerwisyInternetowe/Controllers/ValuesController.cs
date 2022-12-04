using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SerwisyInternetowe.Controllers
{
    [Route("api")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet("{a:Guid}")]
        public IEnumerable<string> Get([FromRoute] Guid a)
        {
            return new string[] { "value1", "value2", a.ToString() };
        }

        
    }
}

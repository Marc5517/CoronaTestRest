using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaTestRest.DBUtil;
using CoronaTestRest.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaTestRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoronaTestsController : ControllerBase
    {
        private static readonly List<CoronaTest> coronaTests = new List<CoronaTest>()
        {
            new CoronaTest(1, "Test maskine 1", 37.5, "Hovedindgangen", "24-11-2020", "11:37"),
            new CoronaTest(2, "Test maskine 2", 37.2, "Bagdøren", "21-11-2020", "10:37"),
            new CoronaTest(3, "Test maskine 3", 38.5, "Hovedindgangen", "4-12-2020", "14:43"),
            new CoronaTest(4, "Test maskine 4", 39.1, "BR butikken", "29-11-2020", "17:15")
        };

        // GET: api/<CoronaTestsController>
        [HttpGet]
        public IEnumerable<CoronaTest> Get()
        {
            ManageCoronaTest mgr = new ManageCoronaTest();
            return mgr.Get();
            //return coronaTests;
        }

        // GET api/<CoronaTestsController>/5
        [HttpGet]
        [Route("{id}")]
        public CoronaTest GetByMachineId(int id)
        {
            ManageCoronaTest mgr = new ManageCoronaTest();
            return mgr.GetById(id);
            //return coronaTests.Find(c => c.TestId == id);
        }

        [HttpGet]
        [Route("temperature")]
        public IEnumerable<CoronaTest> GetHighTemperature()
        {
            ManageCoronaTest mgr = new ManageCoronaTest();
            return mgr.HighTemperature();
        }

        // POST api/<CoronaTestsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CoronaTestsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CoronaTestsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeInsider.Tui.Assessment.Data;
using Microsoft.AspNetCore.Mvc;

namespace CodeInsider.Tui.Assessment.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        internal TuiDbContext DbContext { get; private set; }

        public ValuesController(TuiDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<int> Get()
        {
            return this.DbContext.Flights.Select(o => o.Id);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post()
        {
            this.DbContext.Flights.Add(new Flight());
            this.DbContext.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using System.Collections.Generic;
using CodeInsider.Tui.Assessment.Data;
using Microsoft.AspNetCore.Mvc;

namespace CodeInsider.Tui.Assessment.Controllers
{
    [Route("/[controller]")]
    public class FlightController : Controller
    {
        public class FlightCreationInputModel
        {
            public string DepartureIata {get; set;}
            public string ArrivalIata {get; set;}
        }
        public TuiDbContext DbContext { get; }
        public FlightController(TuiDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Post( FlightCreationInputModel input)
        {
            return Ok();
        }
    }
}
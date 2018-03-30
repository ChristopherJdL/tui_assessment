using System.Collections.Generic;
using System.Linq;
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
            var departureAirport = this.DbContext.Airports.Where(a => a.IataCode == input.DepartureIata).FirstOrDefault();
            var arrivalAirport = this.DbContext.Airports.Where(a => a.IataCode == input.ArrivalIata).FirstOrDefault();
            this.DbContext.Flights.Add(new Flight(){
                DepartureAirport = departureAirport,
                ArrivalAirport = arrivalAirport
            });
            this.DbContext.SaveChanges();
            return Ok();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using CodeInsider.Tui.Assessment.Data;
using CodeInsider.Tui.Assessment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeInsider.Tui.Assessment.Controllers
{
    [Route("[controller]")]
    public class FlightController : Controller
    {
        public class FlightCreationInputModel
        {
            public string DepartureIata {get; set;}
            public string ArrivalIata {get; set;}
        }
        public class FlightEditInputModel
        {
            public int Id {get; set;}
            public string DepartureIata {get; set;}
            public string ArrivalIata {get; set;}
        }
        public TuiDbContext DbContext { get; }
        public IAirportDistanceResolver DistanceResolver { get; private set; }
        public IFuelConsumptionService FuelService { get; private set; }

        public FlightController(TuiDbContext dbContext, IAirportDistanceResolver distanceResolver, IFuelConsumptionService fuelService)
        {
            this.DbContext = dbContext;
            this.DistanceResolver = distanceResolver;
            this.FuelService = fuelService;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var flight = this.DbContext.Flights.Where(f=> f.Id == id).Include(f => f.ArrivalAirport).Include(f => f.DepartureAirport);
            return Ok(flight);
        }
        [HttpPost]
        public IActionResult Post(FlightCreationInputModel input)
        {
            var departureAirport = this.DbContext.Airports.Where(a => a.IataCode == input.DepartureIata).FirstOrDefault();
            var arrivalAirport = this.DbContext.Airports.Where(a => a.IataCode == input.ArrivalIata).FirstOrDefault();
            var flight = new Flight() {
                DepartureAirport = departureAirport,
                ArrivalAirport = arrivalAirport
            };
            flight.FlightDistanceKilometers = this.DistanceResolver.ResolveDistance(departureAirport, arrivalAirport);
            flight.FuelConsumptionLiters = this.FuelService.EstimateFuelConsumption(flight);
            this.DbContext.Flights.Add(flight);
            this.DbContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromForm] FlightEditInputModel input)
        {
            var flight = this.DbContext.Flights.Find(input.Id);
            var departureAirport = this.DbContext.Airports.Where(a => a.IataCode == input.DepartureIata).FirstOrDefault();
            var arrivalAirport = this.DbContext.Airports.Where(a => a.IataCode == input.ArrivalIata).FirstOrDefault();
            if (flight == null || departureAirport == null || arrivalAirport == null)
                return BadRequest("No flight or airport found for given Id(s).");
            flight.ArrivalAirport = arrivalAirport;
            flight.DepartureAirport = departureAirport;
            flight.FlightDistanceKilometers = this.DistanceResolver.ResolveDistance(departureAirport, arrivalAirport);
            flight.FuelConsumptionLiters = this.FuelService.EstimateFuelConsumption(flight);
            DbContext.Update(flight);
            DbContext.SaveChanges();
            return Ok();
        }
    }
}
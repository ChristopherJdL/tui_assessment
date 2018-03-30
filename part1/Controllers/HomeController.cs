using CodeInsider.Tui.Assessment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeInsider.Tui.Assessment.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        public TuiDbContext DbContext { get; }
        
        public HomeController(TuiDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            this.ViewBag.Airports = this.DbContext.Airports;
            this.ViewBag.Flights = this.DbContext.Flights.Include(f => f.ArrivalAirport).Include(f => f.DepartureAirport);
            return View();
        }
    }
}
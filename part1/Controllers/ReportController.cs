using System.Linq;
using CodeInsider.Tui.Assessment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeInsider.Tui.Assessment.Controllers
{
    [Route("/[controller]")]
    public class ReportController : Controller
    {
        private TuiDbContext dbContext;

        public ReportController(TuiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            this.ViewBag.Flights = this.dbContext.Flights.Include(f => f.ArrivalAirport).Include(f => f.DepartureAirport);
            return View();
        }
    }
}
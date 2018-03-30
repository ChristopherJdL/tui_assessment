using CodeInsider.Tui.Assessment.Data;

namespace  CodeInsider.Tui.Assessment.Services
{
    class FuelConsumptionService : IFuelConsumptionService
    {
        /// <summary>
        /// The average fuel consumption of a flight in liters per kilometer
        /// <summary>
        private const int AverageFuelConsumption = 12;
        public double EstimateFuelConsumption(Flight f)
        {
            return f.FlightDistanceKilometers * AverageFuelConsumption;
        }
    }
}
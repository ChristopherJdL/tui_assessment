using CodeInsider.Tui.Assessment.Data;

namespace  CodeInsider.Tui.Assessment.Services
{
    public interface IFuelConsumptionService
    {
        /// <summary>
        /// Estimates fuel consumption in liters for a given Flight.
        /// Also assigns the newly calculated FuelConsumption to the Flight.
        /// </summary>
        double EstimateFuelConsumption(Flight f);
    }
}
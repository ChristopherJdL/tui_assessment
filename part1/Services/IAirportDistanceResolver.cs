using CodeInsider.Tui.Assessment.Data;

namespace  CodeInsider.Tui.Assessment.Services
{
    public interface IAirportDistanceResolver
    {
        /// <summary>
        /// Resolves the Distance in Kilometers between 2 Airports.
        /// </summary>
        /// <param name="origin">Origin Airport</param>
        /// <param name="destination">Destination Airport</param>
        /// <returns></returns>
        double ResolveDistance(Airport origin, Airport destination);
        /// <summary>
        /// Resolves the Distance in Kilometers between 2 Airports.
        /// </summary>
        /// <param name="origin">Origin Airport</param>
        /// <param name="destination">Destination Airport</param>
        /// <returns></returns>
        int ResolveDuration(Airport origin, Airport destination);
    }
}
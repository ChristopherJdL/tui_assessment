using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeInsider.Tui.Assessment.Data;

namespace  CodeInsider.Tui.Assessment.Services
{
    /// <summary>
    /// Calculates Distance and flight Duration from two GeoCoordinates using the Haversine formula 
    ///  
    /// (according to Dr. Math) http://mathforum.org/library/drmath/view/51879.html
    ///
    /// </summary>
    public class HaversineAirportDistanceResolver : IAirportDistanceResolver
    {
        /// <summary>
        /// The average speed of a flight in meters/seconds
        /// <summary>
        private const int AverageFlightSpeed = 250;
        public double ResolveDistance(Airport origin, Airport destination)
        {
            double dDistance = Double.MinValue;
            double dLat1InRad = origin.Latitude * (Math.PI / 180.0);
            double dLong1InRad = origin.Longitude * (Math.PI / 180.0);
            double dLat2InRad = destination.Latitude * (Math.PI / 180.0);
            double dLong2InRad = destination.Longitude * (Math.PI / 180.0);

            double dLongitude = dLong2InRad - dLong1InRad;
            double dLatitude = dLat2InRad - dLat1InRad;

            // Intermediate result a.
            double a = Math.Pow(Math.Sin(dLatitude / 2.0), 2.0) +
                Math.Cos(dLat1InRad) * Math.Cos(dLat2InRad) *
                Math.Pow(Math.Sin(dLongitude / 2.0), 2.0);

            // Intermediate result c (great circle distance in Radians).
            double c = 2.0 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a));

            // Distance.
            // const Double kEarthRadiusMiles = 3956.0;
            const Double kEarthRadiusKms = 6376.5;
            dDistance = kEarthRadiusKms * c;

            return dDistance;
        }

        public int ResolveDuration(Airport origin, Airport destination)
        {
            double distanceMeters = this.ResolveDistance(origin, destination) * 1000;
            double duration = distanceMeters / ((double)AverageFlightSpeed);
            return (int)duration;
        }
    }
}

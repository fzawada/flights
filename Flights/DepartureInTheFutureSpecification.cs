using System;
using System.Linq;

namespace Flights
{
    public class DepartureInTheFutureSpecification
    {
        public bool IsSatisfiedBy(Flight flight)
        {
            if (flight == null)
            {
                throw new ArgumentNullException("flight");
            }

            //important to take into account local time vs UTC
            var currentTime = DateTime.Now;

            if (flight.Segments.First().DepartureDate < currentTime)
            {
                return false;
            }

            return true;
        }
    }
}

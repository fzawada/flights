using System;
using System.Linq;
using Flights.Specifications;

namespace Flights
{
    public class DepartureInTheFutureSpecification : ISpecification<Flight>
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

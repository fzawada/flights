using System;

namespace Flights
{
    public class ArrivalAfterDepartureSpecification
    {
        public bool IsSatisfiedBy(Flight flight)
        {
            if (flight == null)
            {
                throw new ArgumentNullException("flight");
            }

            foreach (var segment in flight.Segments)
            {
                if (segment.ArrivalDate < segment.DepartureDate)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

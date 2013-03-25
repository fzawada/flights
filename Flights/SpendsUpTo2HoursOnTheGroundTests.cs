using System;
using Flights;

namespace FlightsTests
{
    public class SpendsUpTo2HoursOnTheGroundSpecification
    {
        public bool IsSatisfiedBy(Flight flight)
        {
            var totalTimeOnTheGround = TimeSpan.Zero;

            if (flight.Segments.Count == 1)
            {
                return true;
            }

            for (int i = 0; i < flight.Segments.Count - 1; i++)
            {
                var previousSegmentArrival = flight.Segments[i].ArrivalDate;
                var nextSegmentDeparture = flight.Segments[i + 1].DepartureDate;
                var flightChangeTime = nextSegmentDeparture - previousSegmentArrival;

                totalTimeOnTheGround += flightChangeTime;
            }

            var isSatisfied = totalTimeOnTheGround <= TimeSpan.FromHours(2);
            return isSatisfied;
        }
    }
}

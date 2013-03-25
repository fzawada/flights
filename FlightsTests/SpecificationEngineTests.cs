using System.Collections.Generic;
using System.Linq;
using Flights;
using Flights.Specifications;
using NUnit.Framework;

namespace FlightsTests
{
    [TestFixture]
    public class SpecificationEngineTests
    {
        [Test]
        public void Test()
        {
            //arrange
            var flights = new FlightBuilder().GetFlights();
            var flightSpecification = new ArrivalAfterDepartureSpecification()
                .And(new DepartureInTheFutureSpecification())
                .And(new SpendsUpTo2HoursOnTheGroundSpecification());
            var filter = new FlightRulesFilter(flightSpecification);

            //act
            var filteredFlights = filter.Filter(flights);

            //assert
            Assert.AreEqual(filteredFlights.Count(), 2);
        }
    }

    public class FlightRulesFilter
    {
        private readonly ISpecification<Flight> flightSpecification;

        //comes in e.g. via IoC container
        public FlightRulesFilter(ISpecification<Flight> flightSpecification)
        {
            this.flightSpecification = flightSpecification;
        }

        public IEnumerable<Flight> Filter(IEnumerable<Flight> flights)
        {
            return flights.Where(flight => flightSpecification.IsSatisfiedBy(flight));
        }
    }
}

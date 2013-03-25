using System;
using System.Collections.Generic;
using Flights;
using NUnit.Framework;

namespace FlightsTests
{
    [TestFixture]
    public class DepartureInTheFutureSpecificationTests
    {
        [Test]
        public void Is_not_satisfied_if_departure_is_in_the_past()
        {
            //arrange
            var sut = new DepartureInTheFutureSpecification();
            var flight = new Flight
                {
                    Segments = new List<Segment>
                            {
                                new Segment
                                    {
                                        DepartureDate = DateTime.Now.AddDays(-1),
                                        ArrivalDate = DateTime.Now.AddHours(1)
                                    },
                                new Segment
                                    {
                                        DepartureDate = DateTime.Now.AddHours(2),
                                        ArrivalDate = DateTime.Now.AddHours(4)
                                    }
                            }
                };

            //act
            var isSatisfied = sut.IsSatisfiedBy(flight);

            //assert
            Assert.False(isSatisfied);
        }


        [Test]
        public void Is_satisfied_if_departure_is_in_the_future()
        {
            //arrange
            var sut = new DepartureInTheFutureSpecification();
            var flight = new Flight
            {
                Segments = new List<Segment>
                            {
                                new Segment
                                    {
                                        DepartureDate = DateTime.Now.AddHours(1),
                                        ArrivalDate = DateTime.Now.AddHours(2)
                                    },
                                new Segment
                                    {
                                        DepartureDate = DateTime.Now.AddHours(3),
                                        ArrivalDate = DateTime.Now.AddHours(4)
                                    }
                            }
            };


            //act
            var isSatisfied = sut.IsSatisfiedBy(flight);

            //assert
            Assert.True(isSatisfied);
        }

    }

}

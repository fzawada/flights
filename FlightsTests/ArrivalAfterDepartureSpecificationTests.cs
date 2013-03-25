using System;
using System.Collections.Generic;
using Flights;
using NUnit.Framework;

namespace FlightsTests
{
    [TestFixture]
    public class ArrivalAfterDepartureSpecificationTests
    {
        [Test]
        public void Is_not_satisfied_if_any_arrival_is_before_its_corresponding_departure()
        {
            //arrange
            var sut = new ArrivalAfterDepartureSpecification();
            var flight = new Flight
            {
                Segments = new List<Segment>
                            {
                                new Segment
                                    {
                                        DepartureDate = DateTime.Now.AddDays(-1),
                                        ArrivalDate = DateTime.Now.AddHours(1)
                                    },
                                new Segment //invalid segment
                                    {
                                        DepartureDate = DateTime.Now.AddHours(4),
                                        ArrivalDate = DateTime.Now.AddHours(2)
                                    }
                            }
            };

            //act
            var isSatisfied = sut.IsSatisfiedBy(flight);

            //assert
            Assert.False(isSatisfied);
        }


        [Test]
        public void Is_satisfied_if_all_arrivals_are_after_corresponding_departures()
        {
            //arrange
            var sut = new ArrivalAfterDepartureSpecification();
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


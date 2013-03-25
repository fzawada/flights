using System;
using System.Collections.Generic;
using Flights;
using NUnit.Framework;

namespace FlightsTests
{
    [TestFixture]
    public class SpendsUpTo2HoursOnTheGroundSpecificationTests
    {
        [Test]
        public void Is_not_satisfied_if_spends_more_than_two_hours_on_the_ground()
        {
            //arrange
            var sut = new SpendsUpTo2HoursOnTheGroundSpecification();
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
                                },
                            new Segment
                                {
                                    DepartureDate = DateTime.Now.AddHours(6),
                                    ArrivalDate = DateTime.Now.AddHours(7)
                                }
                        }
                };

            //act
            var isSatisfied = sut.IsSatisfiedBy(flight);

            //assert
            Assert.False(isSatisfied);
        }

        [Test]
        public void Is_satisfied_if_spends_two_hours_on_the_ground()
        {
            //arrange
            var sut = new SpendsUpTo2HoursOnTheGroundSpecification();
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
                                },
                            new Segment
                                {
                                    DepartureDate = DateTime.Now.AddHours(5),
                                    ArrivalDate = DateTime.Now.AddHours(6)
                                }
                        }
                };

            //act
            var isSatisfied = sut.IsSatisfiedBy(flight);

            //assert
            Assert.True(isSatisfied);
        }

        [Test]
        public void Is_satisfied_if_spends_less_than_two_hours_on_the_ground()
        {
            //arrange
            var sut = new SpendsUpTo2HoursOnTheGroundSpecification();
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
                                },
                            new Segment
                                {
                                    DepartureDate = DateTime.Now.AddHours(4).AddMinutes(30),
                                    ArrivalDate = DateTime.Now.AddHours(6)
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
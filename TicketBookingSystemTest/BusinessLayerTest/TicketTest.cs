using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TicketBookingSystem.Business;

namespace TicketBookingSystemTest.BusinessLayerTest
{
    [TestClass]
    public class TicketTests
    {
        private Fixture fixture;

        [TestInitialize]
        public void TestInitialize()
        {
            fixture = new Fixture();
        }

        [TestMethod]
        public void FillFromStrings_ShouldCreateTicketFromValues()
        {
            // Arrange
            var values = fixture.Create<Person>().ToArrayOfString().
                Concat(fixture.Create<Flight>().ToArrayOfString()).
                Concat(fixture.Create<Seat>().ToArrayOfString()).ToArray();
            var ticket = new Ticket();
            // Act
            var result = ticket.FillFromStrings(values);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(values[21], result.Seat.SeatNumber);
            CollectionAssert.AreEqual(values.Take(3).ToArray(), result.Person.ToArrayOfString());
            CollectionAssert.AreEqual(values.Skip(3).Take(18).ToArray(), result.Flight.ToArrayOfString());
        }
        [TestMethod]
        public void ToArrayOfString_ShouldReturnArrayWithTicketValues()
        {
            // Arrange
            var person = fixture.Create<Person>();
            var flight = fixture.Create<Flight>();
            var seat = fixture.Create<Seat>();
            var ticket = new Ticket { Person = person, Flight = flight, Seat = seat };
            // Act
            var resultArray = ticket.ToArrayOfString();
            // Assert
            Assert.IsNotNull(resultArray);
            Assert.AreEqual(22, resultArray.Length);
            CollectionAssert.AreEqual(person.ToArrayOfString(), resultArray.Take(3).ToArray());
            CollectionAssert.AreEqual(flight.ToArrayOfString(), resultArray.Skip(3).Take(18).ToArray());
            CollectionAssert.AreEqual(seat.ToArrayOfString(), resultArray.Skip(21).ToArray());
        }
    }
}

using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Business;
using TicketBookingSystem.Data;

namespace TicketBookingSystemTest.BusinessLayerTest
{
    [TestClass]
    public class ProxyTest
    {
        private Proxy proxy;
        private const string csvPath = "test.csv";
        private Fixture fixture;

        [TestInitialize]
        public void TestInitialize()
        {
            fixture = new Fixture();
        }
        [TestMethod]
        public void GetFlights_ShouldReturnFlights()
        {
            // Arrange
            var flightData = fixture.CreateMany<Flight>(100).ToList();
            var user =fixture.Create<User>();
            proxy = new Proxy(user, UserRole.Manger);
            proxy.SetCsvPath(csvPath);
            // Act
            proxy.SetFlights(flightData);
            var flights = proxy.GetFlights();
            // Assert
            Assert.IsNotNull(flights);
            Assert.AreEqual(flightData.Count, flights.Count);
            CollectionAssert.AreEqual(flights.Select(f=>f.FlightId.Id).ToList(), flightData.Select(f=>f.FlightId.Id).ToList());
        }
        [TestMethod]
        public void SetFlights_WithManagerRole_ShouldWriteFlights()
        {
            // Arrange
            var user = fixture.Create<User>();
            var existingFlights = fixture.CreateMany<Flight>(100).ToList();
            var newFlights = fixture.CreateMany<Flight>(10).ToList();

            proxy = new Proxy(user, UserRole.Manger);
            proxy.SetCsvPath(csvPath);
            // Act
            var result = proxy.SetFlights(existingFlights);
            result &= proxy.SetFlights(newFlights);
            var flights = proxy.GetFlights();
            // Assert
            Assert.IsTrue(result);
            CollectionAssert.AreEqual(flights.Select(f => f.FlightId.Id).ToList(), existingFlights.Concat(newFlights).Select(f =>f.FlightId.Id).ToList());
        }
        [TestMethod]
        public void GetBookings_ManagerRole_ReturnsBookings()
        {
            // Arrange
            var user = fixture.Create<User>();
            var newBookings = fixture.CreateMany<Booking>(100).ToList();

            proxy = new Proxy(user, UserRole.Manger);
            proxy.SetCsvPath(csvPath);
            //Act
            proxy.SetBookings(newBookings);
            var bookings = proxy.GetBookings();
            // Assert
            CollectionAssert.AreEqual(bookings.Select(b => b.BookingId.Id).ToList(),
                newBookings.Select(b => b.BookingId.Id).
                ToList());
        }
        [TestMethod]
        public void SetBookings_WithManagerRole_ShouldWriteBookings()
        {
            // Arrange
            var user = fixture.Create<User>();
            var existingBookings = fixture.CreateMany<Booking>(100).ToList();
            var newBookings = fixture.CreateMany<Booking>(100).ToList();

            proxy = new Proxy(user, UserRole.Manger);
            proxy.SetCsvPath(csvPath);
            // Act
            var result = proxy.SetBookings(existingBookings);
            result &= proxy.SetBookings(newBookings);
            var bookings = proxy.GetBookings();
            var TestBooking=existingBookings.Concat(newBookings).ToList();
            // Assert
            Assert.IsTrue(result);
            CollectionAssert.AreEqual(bookings.Select(b=>b.BookingId.Id).ToList(),
                TestBooking.Select(b => b.BookingId.Id).
                ToList());
        }
        [TestMethod]
        public void CancelBooking_BookingFound_ReturnsTrue()
        {
            // Arrange
            var user = fixture.Create<User>();
            var cancelBookings = fixture.CreateMany<Booking>(1).ToList();

            proxy = new Proxy(user, UserRole.Manger);
            proxy.SetCsvPath(csvPath);
            // Act
            proxy.SetBookings(cancelBookings);
            var result = proxy.CancelBooking(cancelBookings.First().BookingId); 
            var booking=proxy.GetBookings();
            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, booking.Count);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            if (File.Exists(csvPath))
            {
                File.Delete(csvPath);
            }
        }
    }
}

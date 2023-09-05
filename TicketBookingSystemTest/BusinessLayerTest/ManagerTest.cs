using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketBookingSystem.Business;
using TicketBookingSystem.Data;

namespace TicketBookingSystemTest.BusinessLayerTest
{
    [TestClass]
    public class ManagerTest
    {
        private Fixture fixture;
        private IDataAccessFactory accessFactory;
        private string csvPath = "test.csv";

        [TestInitialize]
        public void TestInitialize()
        {
            fixture = new Fixture();
            accessFactory=new DataAccessFactory(); 
        }
        [TestMethod]
        public void FilterBooking_ValidData_ReturnsListOfBookings()
        {
            // Arrange
            var manager = fixture.Create<Manager>();
            var bookings = fixture.CreateMany<Booking>(100).Select(b => new Booking(b.Tickets,b.BookingStatus)).ToList();
            var booking=bookings.FirstOrDefault();
            // Act
            accessFactory.CreateBookingDataAccess(csvPath).WriteBookings(bookings);
            var result = manager.FilterBooking(booking);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Booking>));
            Assert.AreEqual(booking.BookingId, result.FirstOrDefault().BookingId);
        }
        [TestMethod]
        public void AddFlightFromCsv_ValidData_ReturnsTrue()
        {
            // Arrange
            var manager = fixture.Create<Manager>();
            var flights = fixture.CreateMany<Flight>(100).ToList();
            var csvPath = "test3.csv";
            // Act
            accessFactory.CreateFlightDataAccess(csvPath).WriteFlights(flights);
            var result = manager.AddFlightFromCsv(csvPath);
            var resultFlights = accessFactory.CreateFlightDataAccess(csvPath).ReadFlights();

            File.Delete(csvPath);
            // Assert
            Assert.IsTrue(result);
            CollectionAssert.AreEqual(flights.Select(f => f.FlightId.Id).ToList(), resultFlights.Select(f => f.FlightId.Id).ToList());
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
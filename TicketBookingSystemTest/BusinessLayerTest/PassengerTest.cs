using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketBookingSystem.Business;
using TicketBookingSystem.Data;

namespace TicketBookingSystemTest.BusinessLayerTest
{
    [TestClass]
    public class PassengerTest
    {
        private Fixture fixture;
        private IDataAccessFactory accessFactory;
        private string csvPath = "test.csv";

        [TestInitialize]
        public void TestInitialize()
        {
            fixture = new Fixture();
            accessFactory = new DataAccessFactory();
        }
        [TestMethod]
        public void GetAllPossibleBooking_ValidData_ReturnsListOfBookings()
        {
            // Arrange
            var passenger = fixture.Create<Passenger>();
            var flight = fixture.Create<Flight>();
            var seat = fixture.Create<Seat>();
            var flights = fixture.CreateMany<Flight>(100).ToList();
            // Act
            accessFactory.CreateFlightDataAccess(csvPath).WriteFlights(flights);
            var result = passenger.GetAllPossibleBooking(flight, seat);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Booking>));
            CollectionAssert.Equals(flights.Select(f => f.DepartureCountry.CountryCode), result.Select(r => r.Tickets.FirstOrDefault().Flight.DepartureCountry.CountryCode));
            CollectionAssert.Equals(flights.Select(f => f.DestinationCountry.CountryCode), result.Select(r => r.Tickets.LastOrDefault().Flight.DestinationCountry.CountryCode));
        }
        [TestMethod]
        public void BookAJourney_ValidData_ReturnsTrue()
        {
            // Arrange
            var passenger = fixture.Create<Passenger>();
            var tickets = fixture.Create<List<Ticket>>();
            var bookingStatus = fixture.Create<BookingStatus>();
            // Act
            var result = passenger.BookAJourney(tickets, bookingStatus);
            var bookings = passenger.GetBookings();
            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(bookings.First().BookingId.Id,tickets.First().Person.PersonId);
        }
        [TestMethod]
        public void ModifyBook_ValidData_ReturnsTrue()
        {
            // Arrange
            var passenger = fixture.Create<Passenger>();
            var booking = fixture.Create<Booking>();
            // Act
            accessFactory.CreateBookingDataAccess(csvPath).WriteBookings(new List<Booking> { booking });
            var result = passenger.ModifyBook(booking);
            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CancelBooking_ValidData_ReturnsTrue()
        {
            // Arrange
            var passenger = fixture.Create<Passenger>();
            var booking = fixture.Create<Booking>();
            // Act
            accessFactory.CreateBookingDataAccess(csvPath).WriteBookings(new List<Booking> { booking });
            var result = passenger.CancelBooking(booking.BookingId);
            var bookings = accessFactory.CreateBookingDataAccess(csvPath).ReadBookings();
            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, bookings.Count);
        }
        [TestMethod]
        public void GetBookings_ValidData_ReturnsListOfBookings()
        {
            // Arrange
            var passenger = fixture.Create<Passenger>();
            // Act
            var result = passenger.GetBookings();
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Booking>));
        }
        [TestMethod]
        public void SearchFlights_ValidData_ReturnsListOfFlights()
        {
            // Arrange
            var passenger = fixture.Create<Passenger>();
            var flights = fixture.CreateMany<Flight>(100).ToList();
            var flight = flights.FirstOrDefault();
            // Act
            accessFactory.CreateFlightDataAccess(csvPath).WriteFlights(flights);
            var result = passenger.SearchFlights(flight);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Flight>));
            Assert.IsTrue(flights.Select(f => f.FlightId.Id).ToList().Contains(flight.FlightId.Id));
        }
        [TestMethod]
        public void GetAllFlights_ValidData_ReturnsListOfFlights()
        {
            // Arrange
            var passenger = fixture.Create<Passenger>();
            var flights = fixture.CreateMany<Flight>(100).ToList();
            // Act
            accessFactory.CreateFlightDataAccess(csvPath).WriteFlights(flights);
            var result = passenger.GetAllFlights();
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Flight>));
            Assert.AreEqual(flights.Count, result.Count);
            CollectionAssert.AreEqual(flights.Select(f => f.FlightId.Id).ToList(),result.Select(f => f.FlightId.Id).ToList());
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

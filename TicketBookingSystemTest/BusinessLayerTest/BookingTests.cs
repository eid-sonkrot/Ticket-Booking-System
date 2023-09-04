using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketBookingSystem.Business;

namespace TicketBookingSystemTest.BusinessLayerTest
{
    [TestClass]
    public class BookingTests
    {
        private Fixture fixture = new Fixture();

        [TestInitialize]
        public void TestInitialize()
        {
            fixture = new Fixture();
            fixture.Customize(new RandomRangedNumberCustomization());
        }
        [TestMethod]
        public void Constructor_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var tickets = fixture.Create<List<Ticket>>();
            var bookingStatus=fixture.Create<BookingStatus>();
            // Act
            var booking = new Booking(tickets, bookingStatus);
            var price = new Price()
            {
                price = tickets.Sum(t => t.Flight.Price.price),
                Currency = tickets.FirstOrDefault().Flight.Price.Currency
            };
            // Assert
            Assert.IsNotNull(booking);
            Assert.AreEqual(tickets, booking.Tickets);
            Assert.IsNotNull(booking.BookingId);
            Assert.AreEqual(booking.BookingDate, new Date { Day = DateTime.Now.Day, Year = DateTime.Now.Year, Month = DateTime.Now.Month });
            Assert.AreEqual(bookingStatus, booking.BookingStatus);
            Assert.AreEqual(booking.DepartureCountry, tickets.First().Flight.DepartureCountry);
            Assert.AreEqual(booking.DestinationCountry,tickets.Last().Flight.DestinationCountry);
            Assert.AreEqual(price, booking.Price);
            Assert.AreEqual(booking.DepartureDate, tickets.FirstOrDefault().Flight.DepartureDate);
            Assert.AreEqual(booking.ArrivalDate, tickets.LastOrDefault().Flight.ArrivalDate);
        }
        [TestMethod]
        public void FillFromStrings_ShouldCreateBookingFromValues()
        {
            // Arrange
            var ticketValues = fixture.Create<List<Ticket>>().Select(t=>t.ToArrayOfString());
            var bookingStatus = fixture.Create<BookingStatus>().ToString();
            var values = ticketValues.SelectMany(arr => arr).Concat(new[] { bookingStatus }).ToArray();
            var booking = new Booking();
            // Act
            var result = booking.FillFromStrings(values);
            // Assert
            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(values.Take(values.Length - 1).ToArray(), result.Tickets.SelectMany(ticket => ticket.ToArrayOfString()).ToArray());
            Assert.AreEqual(bookingStatus, result.BookingStatus.ToString());
        }
        [TestMethod]
        public void ToArrayOfString_ShouldReturnArrayWithBookingValues()
        {
            // Arrange
            var tickets = fixture.CreateMany<Ticket>().ToList();
            var bookingStatus = BookingStatus.Confirmed;
            var booking = new Booking(tickets, bookingStatus);
            var expectedValues = tickets.SelectMany(ticket => ticket.ToArrayOfString()).ToArray()
                .Concat(new[] { bookingStatus.ToString() }).ToArray();
            // Act
            var resultArray = booking.ToArrayOfString();

            // Assert
            CollectionAssert.AreEqual(expectedValues, resultArray);
        }
    }
}
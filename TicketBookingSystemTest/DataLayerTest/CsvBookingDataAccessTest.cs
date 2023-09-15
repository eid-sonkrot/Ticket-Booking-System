using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketBookingSystem.Business;
using TicketBookingSystem.Data;

namespace TicketBookingSystemTest.DataLayerTest
{
    [TestClass]
    public class CsvBookingDataAccessTest
    {
        private const string TestCsvFilePath = "test.csv";
        private CsvBookingDataAccess dataAccess;
        private Fixture fixture = new Fixture();
        [TestInitialize]
        public void TestInitialize()
        {
            dataAccess = new CsvBookingDataAccess(TestCsvFilePath);
        }
        [TestMethod]
        public void ReadBookings_WhenCsvFileExists_ShouldReturnBookings()
        {
            // Arrange
            var bookingData = fixture.Create<List<Booking>>();
            // Act
            dataAccess.WriteBookings(bookingData); 
            var bookings = dataAccess.ReadBookings();
            // Assert
            Assert.IsNotNull(bookings);
            Assert.AreEqual(bookingData.Count, bookings.Count);
        }
        [TestMethod]
        public void ReadBookings_WhenCsvFileDoesNotExist_ShouldReturnEmptyList()
        {
            var dataAccess = new CsvBookingDataAccess("non_existing_file.csv");
            // Act
            var bookings = dataAccess.ReadBookings();
            // Assert
            Assert.IsNotNull(bookings);
            Assert.AreEqual(0, bookings.Count);
        }
        [TestMethod]
        public void WriteBookings_WhenDataIsValid_ShouldWriteToFile()
        {
            // Arrange
            var bookingData = fixture.Create<List<Booking>>();
            // Act
            var success = dataAccess.WriteBookings(bookingData);
            var bookings = dataAccess.ReadBookings();
            // Assert
            Assert.IsTrue(success);
            Assert.AreEqual(bookingData.Count, bookings.Count);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            if (File.Exists(TestCsvFilePath))
            {
                File.Delete(TestCsvFilePath);
            }
        }
    }
}
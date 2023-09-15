using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketBookingSystem.Data;
using TicketBookingSystem.Business;

namespace TicketBookingSystemTest.DataLayerTest
{
    [TestClass]
    public class CsvFlightDataAccessTest
    {
        private const string TestCsvFilePath = "test.csv"; 
        private CsvFlightDataAccess dataAccess;
        private Fixture fixture = new Fixture();

        [TestInitialize]
        public void TestInitialize()
        {
            dataAccess = new CsvFlightDataAccess(TestCsvFilePath);
        }
        [TestMethod]
        public void ReadFlights_WhenCsvFileExists_ShouldReturnFlights()
        {
            // Arrange
            var flightData = fixture.Create<List<Flight>>();
            // Act
            dataAccess.WriteFlights(flightData);
            var flights = dataAccess.ReadFlights();
            // Assert
            Assert.IsNotNull(flights);
            Assert.AreEqual(flightData.Count, flights.Count);
            for(var i=0;i<flightData.Count;i++) 
            {
                Assert.AreEqual(flights[i].FlightId, flightData[i].FlightId);
            }
        }
        [TestMethod]
        public void ReadFlights_WhenCsvFileDoesNotExist_ShouldReturnEmptyList()
        {
            // Act
            var flights = dataAccess.ReadFlights();
            // Assert
            Assert.IsNotNull(flights);
            Assert.AreEqual(0, flights.Count);
        }
        [TestMethod]
        public void WriteFlights_WhenDataIsValid_ShouldWriteToFile()
        {
            // Arrange
            var flightData = fixture.Create<List<Flight>>();
            // Act
            var success = dataAccess.WriteFlights(flightData);
            var flights = dataAccess.ReadFlights();
            // Assert
            Assert.IsTrue(success);
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
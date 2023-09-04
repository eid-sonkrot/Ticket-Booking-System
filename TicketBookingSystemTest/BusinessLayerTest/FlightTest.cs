using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Business;

namespace TicketBookingSystemTest.BusinessLayerTest
{
    [TestClass]
    public class FlightTests
    {
        private Fixture fixture;

        [TestInitialize]
        public void TestInitialize()
        {
            fixture = new Fixture();
        }
        [TestMethod]
        public void FillFromStrings_ShouldCreateFlightFromValues()
        {
            // Arrange
            fixture.RepeatCount = 18;
            var values = fixture.Create<int[]>().Select(v=>v.ToString()).ToArray();
            var flight = new Flight();
            // Act
            var result = flight.FillFromStrings(values);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(values[0], result.FlightId.Id);
            Assert.AreEqual(values[1], result.DepartureCountry.CountryCode);
            Assert.AreEqual(values[2], result.DepartureCountry.CountryName);
            Assert.AreEqual(values[3], result.DestinationCountry.CountryCode);
            Assert.AreEqual(values[4], result.DestinationCountry.CountryName);
            Assert.AreEqual(values[5], result.DepartureDate.Year.ToString());
            Assert.AreEqual(values[6], result.DepartureDate.Month.ToString());
            Assert.AreEqual(values[7], result.DepartureDate.Day.ToString());
            Assert.AreEqual(values[8], result.ArrivalDate.Year.ToString());
            Assert.AreEqual(values[9], result.ArrivalDate.Month.ToString());
            Assert.AreEqual(values[10], result.ArrivalDate.Day.ToString());
            Assert.AreEqual(values[11], result.DepartureAirport.AirportCode);
            Assert.AreEqual(values[12], result.DepartureAirport.AirportName);
            Assert.AreEqual(values[13], result.ArrivalAirport.AirportCode);
            Assert.AreEqual(values[14], result.ArrivalAirport.AirportName);
            Assert.AreEqual(values[15], result.Price.price.ToString());
            Assert.AreEqual(values[16], result.Price.Currency.ToString());
            Assert.AreEqual(values[17], result.Class.ToString());
        }
        [TestMethod]
        public void ToArrayOfString_ShouldReturnArrayWithFlightValues()
        {
            // Arrange
            var flightId = new ID { Id = fixture.Create<string>() };
            var departureCountry = new Country
            {
                CountryCode = fixture.Create<string>(),
                CountryName = fixture.Create<string>()
            };
            var destinationCountry = new Country
            {
                CountryCode = fixture.Create<string>(),
                CountryName = fixture.Create<string>()
            };
            var departureDate = new Date
            {
                Year = fixture.Create<int>(),
                Month = fixture.Create<int>(),
                Day = fixture.Create<int>()
            };
            var arrivalDate = new Date
            {
                Year = fixture.Create<int>(),
                Month = fixture.Create<int>(),
                Day = fixture.Create<int>()
            };
            var departureAirport = new Airport
            {
                AirportCode = fixture.Create<string>(),
                AirportName = fixture.Create<string>()
            };
            var arrivalAirport = new Airport
            {
                AirportCode = fixture.Create<string>(),
                AirportName = fixture.Create<string>()
            };
            var price = new Price
            {
                price = fixture.Create<double>(),
                Currency = fixture.Create<CurrencyType>()
            };
            var @class = fixture.Create<Class>();
            var flight = new Flight
            {
                FlightId = flightId,
                DepartureCountry = departureCountry,
                DestinationCountry = destinationCountry,
                DepartureDate = departureDate,
                ArrivalDate = arrivalDate,
                DepartureAirport = departureAirport,
                ArrivalAirport = arrivalAirport,
                Price = price,
                Class = @class
            };
            // Act
            var resultArray = flight.ToArrayOfString();
            // Assert
            Assert.IsNotNull(resultArray);
            Assert.AreEqual(18, resultArray.Length);
            CollectionAssert.AreEqual(flightId.ToArrayOfString(), resultArray.Take(1).ToArray());
            CollectionAssert.AreEqual(departureCountry.ToArrayOfString(), resultArray.Skip(1).Take(2).ToArray());
            CollectionAssert.AreEqual(destinationCountry.ToArrayOfString(), resultArray.Skip(3).Take(2).ToArray());
            CollectionAssert.AreEqual(departureDate.ToArrayOfString(), resultArray.Skip(5).Take(3).ToArray());
            CollectionAssert.AreEqual(arrivalDate.ToArrayOfString(), resultArray.Skip(8).Take(3).ToArray());
            CollectionAssert.AreEqual(departureAirport.ToArrayOfString(), resultArray.Skip(11).Take(2).ToArray());
            CollectionAssert.AreEqual(arrivalAirport.ToArrayOfString(), resultArray.Skip(13).Take(2).ToArray());
            CollectionAssert.AreEqual(price.ToArrayOfString(), resultArray.Skip(15).Take(2).ToArray());
            Assert.AreEqual(@class.ToString(), resultArray[17]);
        }
    }
}

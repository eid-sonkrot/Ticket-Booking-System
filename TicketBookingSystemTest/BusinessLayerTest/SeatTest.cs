using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystemTest.BusinessLayerTest
{
    [TestClass]
    public class SeatTests
    {
        private Fixture fixture;

        [TestInitialize]
        public void TestInitialize()
        {
            fixture = new Fixture();
        }

        [TestMethod]
        public void FillFromStrings_ShouldCreateSeatFromValues()
        {
            // Arrange
            var seatNumber = fixture.Create<string>();
            var values = new string[] { seatNumber };
            var seat = new Seat();
            // Act
            var result = seat.FillFromStrings(values);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(seatNumber, result.SeatNumber);
        }

        [TestMethod]
        public void ToArrayOfString_ShouldReturnArrayWithSeatNumber()
        {
            // Arrange
            var seatNumber = fixture.Create<string>();
            var seat = new Seat
            {
                SeatNumber = seatNumber
            };
            // Act
            var resultArray = seat.ToArrayOfString();
            // Assert
            Assert.IsNotNull(resultArray);
            Assert.AreEqual(1, resultArray.Length);
            Assert.AreEqual(seatNumber, resultArray[0]);
        }
    }
}
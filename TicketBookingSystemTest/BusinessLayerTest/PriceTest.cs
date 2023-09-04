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
    public class PriceTests
    {
        private Fixture fixture;

        [TestInitialize]
        public void TestInitialize()
        {
            fixture = new Fixture();
        }
        [TestMethod]
        public void FillFromStrings_ShouldCreatePriceFromValues()
        {
            // Arrange
            var values = new string[] { fixture.Create<double>().ToString(),fixture.Create<CurrencyType>().ToString() };
            // Act
            var result = new Price().FillFromStrings(values);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(double.Parse(values[0]), result.price);
            Assert.AreEqual(Enum.Parse<CurrencyType>(values[1]), result.Currency);
        }
        [TestMethod]
        public void ToArrayOfString_ShouldReturnArrayWithPriceValues()
        {
            // Arrange
            var values = new string[] { fixture.Create<double>().ToString(), fixture.Create<CurrencyType>().ToString() };
            var price = new Price
            {
                price = double.Parse(values[0]),
                Currency = Enum.Parse<CurrencyType>(values[1])
            };
            // Act
            var resultArray = price.ToArrayOfString();
            // Assert
            CollectionAssert.AreEqual(values, resultArray);
        }
    }
}

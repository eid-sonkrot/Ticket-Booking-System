using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace TicketBookingSystemTest.BusinessLayerTest
{
    [TestClass]
    public class CountryTests
    {
        private Fixture fixture = new Fixture();

        [TestInitialize]
        public void TestInitialize()
        {
            fixture = new Fixture();
            fixture.Customize(new RandomRangedNumberCustomization());
        }
        [TestMethod]
        public void FillFromStrings_ShouldCreateCountryFromValues()
        {
            // Arrange
            fixture.RepeatCount = 2;
            var values = fixture.Create<string[]>(); 
            var country = new Country();
            // Act
            var result = country.FillFromStrings(values);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(values[0], result.CountryCode);
            Assert.AreEqual(values[1], result.CountryName);
        }

        [TestMethod]
        public void ToArrayOfString_ShouldReturnArrayWithCountryValues()
        {
            // Arrange
            var country = fixture.Build<Country>().With(c => c.CountryCode, "12345678").With(c =>c.CountryName,"CountryName").Create();
            var expectedArray = new string[] { "12345678", "CountryName" };
            // Act
            var resultArray = country.ToArrayOfString();
            // Assert
            CollectionAssert.AreEqual(expectedArray, resultArray);
        }
     }
}
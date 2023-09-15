using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace TicketBookingSystemTest.BusinessLayerTest
{
    [TestClass]
    public class AirportTest
    {
        private Fixture fixture = new Fixture();

        [TestInitialize]
        public void TestInitialize()
        {
            fixture = new Fixture();
        }
        [TestMethod]
        public void AirportCode_WhenValid_ShouldNotHaveValidationError()
        {
            // Arrange
            var airport =fixture.Build<Airport>().With(a => a.AirportCode,"12345678").With(a=>a.AirportName,"abcx").Create();
            var context = new ValidationContext(airport);
            var results = new System.Collections.Generic.List<ValidationResult>();
            // Act
            var isValid = Validator.TryValidateObject(airport, context, results, true);
            // Assert
            Assert.IsTrue(isValid);
            Assert.AreEqual(0, results.Count);
        }
        [TestMethod]
        public void AirportCode_WhenInvalid_ShouldHaveValidationError()
        {
            // Arrange
            var airport = new Airport { AirportCode = "12345A78", AirportName = "InvalidAirport" };
            var context = new ValidationContext(airport);
            var results = new System.Collections.Generic.List<ValidationResult>();
            // Act
            var isValid = Validator.TryValidateObject(airport, context, results, true);
            // Assert
            Assert.IsFalse(isValid);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("AirportCode should contain only numeric values.", results[0].ErrorMessage);
        }
        [TestMethod]
        public void ToArrayOfString_ShouldReturnArrayWithValues()
        {
            // Arrange
            fixture.RepeatCount = 2;
            var expectedArray = fixture.Create<string[]>();
            var airport = new Airport().FillFromStrings(expectedArray);
            // Act
            var resultArray = airport.ToArrayOfString();
            // Assert
            CollectionAssert.AreEqual(expectedArray, resultArray);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FillFromStrings_WhenValuesArrayHasWrongLength_ShouldThrowArgumentException()
        {
            // Arrange
            fixture.RepeatCount = 3;
            var values = fixture.Create<string[]>();
            // Act
            var airport = new Airport().FillFromStrings(values);
        }
    }
}

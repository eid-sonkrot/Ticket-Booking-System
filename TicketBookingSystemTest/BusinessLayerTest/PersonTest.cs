using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystemTest.BusinessLayerTest
{
    [TestClass]
    public class PersonTests
    {
        private Fixture fixture = new Fixture();

        [TestInitialize]
        public void TestInitialize()
        {
            fixture = new Fixture();
            fixture.Customize(new RandomRangedNumberCustomization());
        }
        [TestMethod]
        public void FillFromStrings_ShouldCreatePersonFromValues()
        {
            // Arrange
            fixture.RepeatCount = 3;
            var values = fixture.Create<string[]>();
            // Act
            var result = new Person().FillFromStrings(values);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(values[0], result.PersonName);
            Assert.AreEqual(values[1], result.PersonId);
            Assert.AreEqual(values[2], result.PassprotNumber);
        }
        [TestMethod]
        public void FillFromStrings_WhenInsufficientValues_ShouldThrowArgumentException()
        {
            // Arrange
            fixture.RepeatCount = 2;
            var values = fixture.Create<string[]>();
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Person().FillFromStrings(values));
        }
        [TestMethod]
        public void ToArrayOfString_ShouldReturnArrayWithPersonValues()
        {
            // Arrange
            fixture.RepeatCount = 3;
            var values = fixture.Create<string[]>();
            var person = new Person()
            {
                PersonName = values[0],
                PersonId = values[1],
                PassprotNumber = values[2]
            };
            // Act
            var resultArray = person.ToArrayOfString();
            // Assert
            CollectionAssert.AreEqual(values, resultArray);
        }
    }
}
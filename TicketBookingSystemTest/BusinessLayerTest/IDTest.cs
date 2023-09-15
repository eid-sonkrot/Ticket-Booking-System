using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicketBookingSystemTest.BusinessLayerTest
{
    [TestClass]
    public class IDTest
    {
        private Fixture fixture = new Fixture();

        [TestInitialize]
        public void TestInitialize()
        {
            fixture = new Fixture();
            fixture.Customize(new RandomRangedNumberCustomization());
        }
        [TestMethod]
        public void FillFromStrings_ShouldCreateIDFromValue()
        {
            // Arrange
            var value = fixture.Create<string>(); 
            // Act
            var result = new ID().FillFromStrings(new string[] { value });
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(value, result.Id);
        }
        [TestMethod]
        public void ToArrayOfString_ShouldReturnArrayWithIdValue()
        {
            // Arrange
            var value = fixture.Create<string>();
            var id = new ID { Id = value };
            var expectedArray = new string[] { value };
            // Act
            var resultArray = id.ToArrayOfString();
            // Assert
            CollectionAssert.AreEqual(expectedArray, resultArray);
        }
    }
}
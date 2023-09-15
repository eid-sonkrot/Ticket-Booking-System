using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicketBookingSystemTest.BusinessLayerTest
{
    [TestClass]
    public class DateTests
    {
        private Fixture fixture = new Fixture();

        [TestInitialize]
        public void TestInitialize()
        {
            fixture = new Fixture();
            fixture.Customize(new RandomRangedNumberCustomization());
        }
        [TestMethod]
        public void FillFromStrings_ShouldCreateDateFromValues()
        {
            // Arrange
            var values = fixture.Create<List<int>>();
            var array = values.Select(v => v.ToString()).ToArray();
            var date = new Date();
            // Act
            var result = date.FillFromStrings(array);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(values[0], result.Year);
            Assert.AreEqual(values[1], result.Month);
            Assert.AreEqual(values[2], result.Day);
        }
        [TestMethod]
        public void ToArrayOfString_ShouldReturnArrayWithDateValues()
        {
            // Arrange
            var date = fixture.Build<Date>().Create();
            // Act
            var resultArray = date.ToArrayOfString();
            // Assert
            Assert.AreEqual(date.Year.ToString(), resultArray[0]);
            Assert.AreEqual(date.Month.ToString(), resultArray[1]);
            Assert.AreEqual(date.Day.ToString(), resultArray[2]);
        }
    }
}

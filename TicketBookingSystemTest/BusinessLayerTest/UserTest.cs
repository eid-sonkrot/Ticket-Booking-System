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
    public class UserTests
    {
        private Fixture fixture;

        [TestInitialize]
        public void TestInitialize()
        {
            fixture = new Fixture();
        }

        [TestMethod]
        public void FillFromStrings_ShouldCreateUserFromValues()
        {
            // Arrange
            var personValues = fixture.Create<string[]>();
            var email = fixture.Create<string>();
            var hashedPassword = fixture.Create<string>();
            var values = personValues.Concat(new[] { email, hashedPassword }).ToArray();
            var user = new User();
            // Act
            var result = user.FillFromStrings(values);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(email, result.Email);
            Assert.AreEqual(hashedPassword, result.HashedPassword);
        }
        [TestMethod]
        public void ToArrayOfString_ShouldReturnArrayWithUserValues()
        {
            // Arrange
            var person = new Person
            {
                PersonName = fixture.Create<string>(),
                PersonId = fixture.Create<string>(),
                PassprotNumber = fixture.Create<string>()
            };
            var email = fixture.Create<string>();
            var hashedPassword = fixture.Create<string>();
            var user = new User
            {
                Person = person,
                Email = email,
                HashedPassword = hashedPassword
            };
            // Act
            var resultArray = user.ToArrayOfString();
            // Assert
            Assert.IsNotNull(resultArray);
            Assert.AreEqual(5, resultArray.Length);
            CollectionAssert.AreEqual(person.ToArrayOfString(), resultArray.Take(3).ToArray());
            Assert.AreEqual(email, resultArray[3]);
            Assert.AreEqual(hashedPassword, resultArray[4]);
        }
    }
}

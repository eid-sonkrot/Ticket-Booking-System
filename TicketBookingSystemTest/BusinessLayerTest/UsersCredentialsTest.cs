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
    public class UsersCredentialsTests
    {
        private Fixture fixture;

        [TestInitialize]
        public void TestInitialize()
        {
            fixture = new Fixture();
        }
        [TestMethod]
        public void FillFromStrings_ShouldCreateUsersCredentialsFromValues()
        {
            // Arrange
            var userValues = fixture.Create<User>().ToArrayOfString();
            var role = fixture.Create<UserRole>();
            var values = userValues.Concat(new[] { role.ToString() }).ToArray();
            var usersCredentials = new UsersCredentials();
            // Act
            var result = usersCredentials.FillFromStrings(values);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(role, result.Role);
            Assert.AreEqual(userValues[3], result.User.Email); 
            Assert.AreEqual(userValues[4], result.User.HashedPassword); 
        }
        [TestMethod]
        public void ToArrayOfString_ShouldReturnArrayWithUsersCredentialsValues()
        {
            // Arrange
            var user = new User
            {
                Person = new Person
                {
                    PersonName = fixture.Create<string>(),
                    PersonId = fixture.Create<string>(),
                    PassprotNumber = fixture.Create<string>()
                },
                Email = fixture.Create<string>(),
                HashedPassword = fixture.Create<string>()
            };
            var role = fixture.Create<UserRole>();
            var usersCredentials = new UsersCredentials
            {
                User = user,
                Role = role
            };
            // Act
            var resultArray = usersCredentials.ToArrayOfString();
            // Assert
            Assert.IsNotNull(resultArray);
            Assert.AreEqual(6, resultArray.Length);
            CollectionAssert.AreEqual(user.ToArrayOfString(), resultArray.Take(5).ToArray());
            Assert.AreEqual(role.ToString(), resultArray[5]);
        }
    }
}
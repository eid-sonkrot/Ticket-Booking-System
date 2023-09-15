using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Business;

namespace TicketBookingSystemTest.BusinessLayerTest
{
    [TestClass]
    public class LoginTest
    {
        private Fixture fixture;

        [TestInitialize]
        public void TestInitialize()
        {
            fixture = new Fixture();
        }
        [TestMethod]
        public void GetUserControall_ValidUserCredentials_ReturnsIUser()
        {
            // Arrange
            var login = fixture.Create<Login>();
            var userCredentials = fixture.Create<UsersCredentials>();
            // Act
            var result = login.GetUserControall(userCredentials);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IUser));
        }
        [TestMethod]
        public void GetUserControall_InvalidUserCredentials_ReturnsNull()
        {
            // Arrange
            var login = fixture.Create<Login>();
            var userCredentials = fixture.Create<UsersCredentials>();
            var proxyMock = new Mock<IProxy>();
            // Act
            proxyMock.Setup(p => p.UserAuthentication(userCredentials)).Returns(false);
            login.SetProxy(proxyMock.Object);
            var result = login.GetUserControall(userCredentials);
            // Assert
            Assert.IsNull(result);
        }
        [TestMethod]
        public void UserAuthentication_ValidUserCredentials_ReturnsTrue()
        {
            // Arrange
            var login = fixture.Create<Login>();
            var userCredentials = fixture.Create<UsersCredentials>();
            // Act
            var result = login.UserAuthentication(userCredentials);
            // Assert
            Assert.IsTrue(result);
        }
    }
}

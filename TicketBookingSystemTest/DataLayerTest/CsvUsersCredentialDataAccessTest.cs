using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketBookingSystem.Data;

namespace TicketBookingSystemTest.DataLayerTest
{
        [TestClass]
        public class CsvUsersCredentialDataAccessTest
        {
            private const string TestCsvFilePath = "test.csv";
            private CsvUsersCredentialDataAccess dataAccess;
            private Fixture fixture = new Fixture();

            [TestInitialize]
            public void TestInitialize()
            {
                dataAccess = new CsvUsersCredentialDataAccess(TestCsvFilePath);
            }
            [TestMethod]
            public void ReadUsersCredentials_WhenCsvFileExists_ShouldReturnUsersCredentials()
            {
                // Arrange
                var usersCredentialsData = fixture.Create<List<UsersCredentials>>();
                // Act
                dataAccess.WriteUsersCredentials(usersCredentialsData);
                var usersCredentials = dataAccess.ReadUsersCredentials();
                // Assert
                Assert.IsNotNull(usersCredentials);
                Assert.AreEqual(usersCredentialsData.Count, usersCredentials.Count);
            }

            [TestMethod]
            public void ReadUsersCredentials_WhenCsvFileDoesNotExist_ShouldReturnEmptyList()
            {
                // Arrange
                var dataAccess = new CsvUsersCredentialDataAccess("non_existing_file.csv");
                // Act
                var usersCredentials = dataAccess.ReadUsersCredentials();
                // Assert
                Assert.IsNotNull(usersCredentials);
                Assert.AreEqual(0, usersCredentials.Count);
            }
            [TestMethod]
            public void WriteUsersCredentials_WhenDataIsValid_ShouldWriteToFile()
            {
                // Arrange
                var usersCredentialsData = fixture.Create<List<UsersCredentials>>();
                // Act
                var success = dataAccess.WriteUsersCredentials(usersCredentialsData);
                var usersCredentials = dataAccess.ReadUsersCredentials();
                // Assert
                Assert.IsTrue(success);
                Assert.AreEqual(usersCredentialsData.Count, usersCredentials.Count);
            }
            [TestCleanup]
            public void TestCleanup()
            {
                if (File.Exists(TestCsvFilePath))
                {
                    File.Delete(TestCsvFilePath);
                }
            }
        }
}

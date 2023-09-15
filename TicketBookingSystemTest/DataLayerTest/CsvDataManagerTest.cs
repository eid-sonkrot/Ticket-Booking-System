using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketBookingSystem.Business;
using TicketBookingSystem.Data;

namespace TicketBookingSystemTest.DataLayerTest
{
    [TestClass]
    public class CsvDataManagerTest
    {
        private const string TestCsvFilePath = "test.csv"; 
        private Fixture fixture = new Fixture();

        [TestMethod]
        public void ReadCsvData_WhenCsvFileExists_ShouldReturnData()
        {
            // Arrange
            var csvData = fixture.Create<List<string[]>>();
            var dataManager = new CsvDataManager(TestCsvFilePath);
            // Act
            File.WriteAllLines(dataManager.GetCsvFilePath(), csvData.ConvertAll(line => string.Join(",", line)));
            var result = dataManager.ReadCsvData();
            // Assert
            for(var i=0;i<csvData.Count;i++)
            {
                CollectionAssert.AreEqual(csvData[i], result[i]);
            }
        }
        [TestMethod]
        public void ReadCsvData_WhenCsvFileDoesNotExist_ShouldReturnEmptyList()
        {
            // Arrange
            var nonExistentFilePath = "nonexistent.csv";
            var dataManager = new CsvDataManager(nonExistentFilePath);
            // Act
            var result = dataManager.ReadCsvData();
            // Assert
            Assert.AreEqual(0, result.Count);
        }
        [TestMethod]
        public void WriteCsvData_WhenDataIsValid_ShouldWriteToFile()
        {
            // Arrange
            var csvData = fixture.Create<List<string[]>>();
            var dataManager = new CsvDataManager(TestCsvFilePath);
            // Act
            var success = dataManager.WriteCsvData(csvData);
            var linesInFile = File.ReadAllLines(TestCsvFilePath);
            var result = linesInFile.Select(line => line.Split(",")).ToList();
            // Assert
            Assert.IsTrue(success);
            for (var i = 0; i < csvData.Count; i++)
            {
                CollectionAssert.AreEqual(csvData[i], result[i]);
            }
        }
        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(TestCsvFilePath))
            {
                File.Delete(TestCsvFilePath);
            }
        }
    }
}
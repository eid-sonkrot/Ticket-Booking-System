using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Business;

namespace TicketBookingSystem.Data
{
    public class CsvUsersCredentialDataAccess:IUsersCredentialDataAccess
    {
        private CsvDataManager csvDataManager;

        public CsvUsersCredentialDataAccess(string csvFilePath)
        {
            this.csvDataManager = new CsvDataManager(csvFilePath);
        }
        public CsvUsersCredentialDataAccess()
        {
        }
        public List<UsersCredentials> ReadUsersCredentials()
        {
            try
            {
                var csvData = csvDataManager.ReadCsvData();
                var usersCredentials = csvData
                    .Select(fields => new UsersCredentials().FillFromStrings(fields))
                    .ToList();

                return usersCredentials;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading flights: {ex.Message}");
                return new List<UsersCredentials>(); // Return an empty list in case of error
            }
        }
        public bool WriteUsersCredentials(List<UsersCredentials> usersCredentials)
        {
            try
            {
                var csvData = new List<string[]>();

                csvData.AddRange(usersCredentials.Select(usersCredential => usersCredential.ToArrayOfString()));
                csvDataManager.WriteCsvData(csvData);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing flights: {ex.Message}");
                return false;
            }
        }
    }
}

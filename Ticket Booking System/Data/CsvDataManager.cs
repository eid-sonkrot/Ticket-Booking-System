namespace TicketBookingSystem.Data
{
    public class CsvDataManager
    {
        private string csvFilePath;

        public CsvDataManager(string csvFilePath)
        {
            this.csvFilePath = csvFilePath;
        }

        public List<string[]> ReadCsvData()
        {
            List<string[]> csvData = new List<string[]>();

            try
            {
                using (StreamReader reader = new StreamReader(csvFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] fields = line.Split(',');
                        csvData.Add(fields);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                // Handle the case when the CSV file is not found.
                Console.WriteLine($"Error: CSV file '{csvFilePath}' not found.");
            }
            catch (Exception ex)
            {
                // Handle any other exceptions that might occur during the file reading process.
                Console.WriteLine($"Error: Failed to read CSV file. {ex.Message}");
            }

            return csvData;
        }

        public void WriteCsvData(List<string[]> csvData)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(csvFilePath))
                {
                    foreach (string[] fields in csvData)
                    {
                        string line = string.Join(",", fields);
                        writer.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during the file writing process.
                Console.WriteLine($"Error: Failed to write data to CSV file. {ex.Message}");
            }
        }
    }
}

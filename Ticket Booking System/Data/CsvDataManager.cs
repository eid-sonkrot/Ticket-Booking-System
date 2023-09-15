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
            var csvData = new List<string[]>();

            try
            {
                using (var reader = new StreamReader(csvFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var fields = line.Split(',');
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
        public bool WriteCsvData(List<string[]> csvData)
        {
            try
            {
                // Clear the file by writing an empty string
                File.WriteAllText(csvFilePath, string.Empty);
                using (var writer = new StreamWriter(csvFilePath))
                {
                    foreach (var fields in csvData)
                    {
                        var line = string.Join(",", fields);
                        writer.WriteLine(line);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during the file writing process.
                Console.WriteLine($"Error: Failed to write data to CSV file. {ex.Message}");
                return false;
            }
        }
    }
}

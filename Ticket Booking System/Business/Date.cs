using System.ComponentModel.DataAnnotations;

public record Date
{
    [Range(1, 9999, ErrorMessage = "Year must be between 1 and 9999.")]
    public int Year { get; init; }

    [Range(1, 12, ErrorMessage = "Month must be between 1 and 12.")]
    public int Month { get; init; }

    [Range(1, 31, ErrorMessage = "Day must be between 1 and 31.")]
    public int Day { get; init; }

    public Date FillFromStrings(string[] values)
    {
        if (values.Length != 3)
        {
            throw new ArgumentException("Exactly 3 values are required to fill the Date record.");
        }

        return new Date
        {
            Year = Convert.ToInt32(values[0]),
            Month = Convert.ToInt32(values[1]),
            Day = Convert.ToInt32(values[2])
        };
    }
    public string[] ToArrayOfStrign()
    {
        return new string[] {Year.ToString(),Month.ToString(),Day.ToString()};
    }
}



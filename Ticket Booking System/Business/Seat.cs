using System.ComponentModel.DataAnnotations;

public record Seat
{
    [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "The field must contain only alphabets and numbers.")]
    public String SeatNumber { get; set; }

    public Seat FillFromStrings(string[] values)
    {
        if (values.Length != 1)
        {
            throw new ArgumentException("Exactly 1 value is required to fill the Seat record.");
        }

        return new Seat
        {
            SeatNumber = values[0]
        };
    }
    public string[] ToArrayOfString()
    {
        return new string[] {SeatNumber};
    }
}
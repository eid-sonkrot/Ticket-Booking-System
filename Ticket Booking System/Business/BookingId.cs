using System.ComponentModel.DataAnnotations;

public record BookingId
{
    [RegularExpression("^[0-9]*$",ErrorMessage = "The field must contain only numbers.")]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "BookingId must be exactly 8 characters long.")]
    public string Id { get; set; }

    public BookingId FillFromStrings(string[] values)
    {
        if (values.Length != 1)
        {
            throw new ArgumentException("Exactly 1 value is required to fill the BookingId record.");
        }

        return new BookingId
        {
            Id = values[0]
        };
    }
    public string[] ToArrayOfStrign()
    {
        return new string[] { Id };
    }
}
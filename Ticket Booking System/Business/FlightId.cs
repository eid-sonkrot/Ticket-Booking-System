using System.ComponentModel.DataAnnotations;
using TicketBookingSystem.Business;

public record FlightId
{
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "FlightId should contain only numeric values.")]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "FlightId must be exactly 8 characters long.")]
    public string ? Id { get; set; }

    public FlightId FillFromStrings(string[] values)
    {
        if (values.Length != 1)
        {
            throw new ArgumentException("Exactly 1 value is required to fill the Flight record.");
        }

        return new FlightId
        {
            Id = values[0]
        };
    }
    public string[] ToArrayOfStrign()
    {
        return new string[] { Id };
    }
}
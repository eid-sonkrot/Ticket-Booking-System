using System.ComponentModel.DataAnnotations;
public record FlightId
{
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "FlightId should contain only numeric values.")]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "FlightId must be exactly 8 characters long.")]
    public string? Id { get; init; }
}
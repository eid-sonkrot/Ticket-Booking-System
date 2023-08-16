using System.ComponentModel.DataAnnotations;

public record Airport
{
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "AirportCode should contain only numeric values.")]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "AirportCode must be exactly 8 characters long.")]
    public string? AirportCode { get; set; }
    [RegularExpression(@"^[a-Z]*$", ErrorMessage = " AirportName should contain only latin alphabet letters.")]
    [StringLength(30, ErrorMessage = " AirportName must be at most 30 characters long.")]
    public string? AirportName { get; set; }
}
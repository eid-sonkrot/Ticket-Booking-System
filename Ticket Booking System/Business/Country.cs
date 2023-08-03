using System.ComponentModel.DataAnnotations;

public record Country
{
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "CountryCode should contain only numeric values.")]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "CountryCode must be exactly 8 characters long.")]
    public string? CountryCode { get; init; }
    [RegularExpression(@"^[a-Z]*$", ErrorMessage = "CountryName should contain only latin alphabet letters.")]
    [StringLength(30, ErrorMessage = "CountryName must be at most 30 characters long.")]
    public string? CountryName { get; init; }
}
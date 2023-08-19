using System.ComponentModel.DataAnnotations;

public record Country
{
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "CountryCode should contain only numeric values.")]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "CountryCode must be exactly 8 characters long.")]
    public string? CountryCode { get; set; }
    [RegularExpression(@"^[a-Z]*$", ErrorMessage = "CountryName should contain only latin alphabet letters.")]
    [StringLength(30, ErrorMessage = "CountryName must be at most 30 characters long.")]
    public string? CountryName { get; set; }

    public Country FillFromStrings(string[] values)
    {
        if (values.Length >= 2)
        {
            return this with
            {
                CountryCode = values[0],
                CountryName = values[1]
            };
        }
        else
        {
            throw new ArgumentException("Insufficient values provided to fill the Country record.");
        }
    }
    public string[] ToArrayOfStrign()
    {
        return new string[] { CountryCode, CountryName };

    }
}
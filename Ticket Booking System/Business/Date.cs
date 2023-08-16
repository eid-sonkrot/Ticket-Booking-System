using System.ComponentModel.DataAnnotations;

public record Date
{
    [Range(1, 9999, ErrorMessage = "Year must be between 1 and 9999.")]
    public int? Year { get; init; }

    [Range(1, 12, ErrorMessage = "Month must be between 1 and 12.")]
    public int? Month { get; init; }

    [Range(1, 31, ErrorMessage = "Day must be between 1 and 31.")]
    public int? Day { get; init; }
}



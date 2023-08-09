using System.ComponentModel.DataAnnotations;

public record BookingId
{
    [RegularExpression("^[0-9]*$",ErrorMessage = "The field must contain only numbers.")]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "BookingId must be exactly 8 characters long.")]
    public string Id { get; set; }
}
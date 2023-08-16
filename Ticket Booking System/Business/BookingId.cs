using System.ComponentModel.DataAnnotations;

public record BookingId
{
    [RegularExpression("^[0-9]*$",ErrorMessage = "The field must contain only numbers.")]
    public string Id { get; set; }
}
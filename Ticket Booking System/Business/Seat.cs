using System.ComponentModel.DataAnnotations;

public record Seat
{
    [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "The field must contain only alphabets and numbers.")]
    public String SeatNumber { get; set; }
}
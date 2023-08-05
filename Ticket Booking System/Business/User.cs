using System.ComponentModel.DataAnnotations;
using TicketBookingSystem.Business;

public record User
{
    public Person person { get; set; }
    [Email(ErrorMessage = "Invalid email address.")]
    public string email { get; set; }
    [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "The hashedPassword must contain only alphabets and numbers.")]
    public string hashedPassword { get; set; }

}
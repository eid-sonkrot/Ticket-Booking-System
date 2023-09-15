using System.ComponentModel.DataAnnotations;
using TicketBookingSystem.Business;

public record User
{
    public Person Person { get; set; }
    [Email(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }
    [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "The hashedPassword must contain only alphabets and numbers.")]
    public string HashedPassword { get; set; }

    public User FillFromStrings(string[] values)
    {
        if (values.Length != 5)
        {
            throw new ArgumentException("Exactly 3 values are required to fill the User record.");
        }

        return new User
        {
            Person = new Person().FillFromStrings(new string[] { values[0], values[1], values[2] }),
            Email = values[3],
            HashedPassword = values[4]
        };
    }
    public string[] ToArrayOfString()
    {
        return  Person.ToArrayOfString().Append(Email).Append(HashedPassword).ToArray();
    }
}
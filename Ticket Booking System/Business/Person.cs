using System.ComponentModel.DataAnnotations;

public record Person
{
    [RegularExpression(@"^[a-Z]*$", ErrorMessage = "PersonName should contain only latin alphabet letters.")]
    [StringLength(300, MinimumLength = 3, ErrorMessage = "PersonName must be at most 30 characters long and at least 3 characters.")]
    public string PersonName { get; set; }
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "PersonId should contain only numeric values.")]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "PersonId must be exactly 8 characters long.")]
    public string PersonId { get; set; }
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "PassprotNumber should contain only numeric values.")]
    [StringLength(20, MinimumLength = 20, ErrorMessage = "PassprotNumbermust be exactly 20 characters long.")]
    public string PassprotNumber { get; set; }
    public Person FillFromStrings(string[] values)
    {
        if (values.Length != 3)
        {
            throw new ArgumentException("Exactly 3 values are required to fill the Person record.");
        }

        return new Person
        {
            PersonName = values[0],
            PersonId = values[1],
            PassprotNumber = values[2]
        };
    }
    public string[] ToArrayOfStrign()
    {
        return new string[] {PersonName,PersonId,PassprotNumber};
    }
}
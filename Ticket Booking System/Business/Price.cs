using System.ComponentModel.DataAnnotations;
using TicketBookingSystem.Business;

public record Price
{
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
    public double price { get; set; }

    [EnumDataType(typeof(CurrencyType), ErrorMessage = "Invalid currency type.")]
    public CurrencyType Currency { get; set; }

    public Price FillFromStrings(string[] values)
    {
        if (values.Length != 2)
        {
            throw new ArgumentException("Exactly 2 values are required to fill the Price record.");
        }
        return new Price
        {
            price = Convert.ToDouble(values[0]),
            Currency = Enum.Parse<CurrencyType>(values[1])
        };
    }
    public string[] ToArrayOfString()
    {
        return new string[] { price.ToString(), Currency.ToString()};
    }
}

using System.ComponentModel.DataAnnotations;

public record Price
{
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
    public double price { get; init; }

    [EnumDataType(typeof(CurrencyType), ErrorMessage = "Invalid currency type.")]
    public CurrencyType currency { get; init; }
}

public record SearchParameters
{
    public Country departureCountry { get; init; }
    public Country destinationCountry { get; init; }
    public Date? departureDate { get; init; }
    public Date? arrivalDate { get; init; }
}
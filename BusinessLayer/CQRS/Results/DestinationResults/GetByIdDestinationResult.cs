namespace BusinessLayer.CQRS.Results.Destinations
{
    public class GetByIdDestinationQueryResult
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? DayNight { get; set; }
    }
}

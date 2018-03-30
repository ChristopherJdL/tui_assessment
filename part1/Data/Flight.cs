namespace CodeInsider.Tui.Assessment.Data
{
    public class Flight
    {
        public int Id { get; set; }
        public int AirportId { get; set; }
        public Airport Airport { get; set; }
    }
}
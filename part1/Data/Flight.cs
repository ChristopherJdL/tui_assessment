namespace CodeInsider.Tui.Assessment.Data
{
    public class Flight
    {
        public int Id { get; set; }
        public int DepartureAirportId { get; set; }
        public Airport DepartureAirport { get; set; }
        public int ArrivalAirportId {get; set;}
        public Airport ArrivalAirport {get; set;}
    }
}
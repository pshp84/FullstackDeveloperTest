namespace FlightManagementSystem.DTOs
{
    public class FlightPrice
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal Price { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

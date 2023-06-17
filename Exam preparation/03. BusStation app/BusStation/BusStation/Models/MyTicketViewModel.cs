namespace BusStation.Models
{
    public class MyTicketViewModel
    {
        public string DestinationImage { get; set; } = null!;

        public string Destination { get; set; } = null!;

        public string DateAndTime { get; set; } = null!;

        public decimal TicketPrice { get; set; }
    }
}

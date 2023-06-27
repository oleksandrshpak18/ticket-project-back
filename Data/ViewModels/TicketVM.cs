using ticket_project_back.Data.Models;

namespace ticket_project_back.Data.ViewModels
{
    public class TicketVM
    {
        public int? TicketNumber { get; set; }
        public string SeatType { get; set; }
        public int? RowNumber { get; set; }

        public int? SeatNumber { get; set; }
        public int TicketPrice { get; set; }
        public int? EventId { get; set; }
        public int? VenueId { get; set; }
    }
}

using ticket_project_back.Data.Models;

namespace ticket_project_back.Data.ViewModels
{
    public class TicketPriceVM
    {
        public int? EventId { get; set; }
        public string? SeatType { get; set; }
        public int Price { get; set; }
    }
}

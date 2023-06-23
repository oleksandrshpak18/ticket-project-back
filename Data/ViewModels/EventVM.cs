using ticket_project_back.Data.Models;

namespace ticket_project_back.Data.ViewModels
{
    public class EventVM
    {
        public int EventId { get; set; }

        public string EventTitle { get; set; } = null!;

        public DateTime EventDate { get; set; }

        public string? EventDescription { get; set; }

        public TimeSpan BeginTime { get; set; }

        public int? Duration { get; set; }

        public int MinAgeRestriction { get; set; }

        public string? Img { get; set; }

        public string? EventType { get; set; }

        public PerformerVM? Performer { get; set; }

        public VenueVM? Venue { get; set; }
        public ICollection<TicketPriceVM> TicketPrices { get; set; } = new List<TicketPriceVM>();
    }
}

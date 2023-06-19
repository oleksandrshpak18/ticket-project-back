using System;
using System.Collections.Generic;

namespace ticket_project_back.Data.Models;

public partial class Event
{
    public int EventId { get; set; }

    public int? PerformerId { get; set; }

    public int? VenueId { get; set; }

    public int? EventTypeId { get; set; }

    public string EventTitle { get; set; } = null!;

    public DateTime EventDate { get; set; }

    public string? EventDescription { get; set; }

    public TimeSpan BeginTime { get; set; }

    public int? Duration { get; set; }

    public int MinAgeRestriction { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? Img { get; set; }

    public virtual EventType? EventType { get; set; }

    public virtual Performer? Performer { get; set; }

    public virtual ICollection<TicketPrice> TicketPrices { get; set; } = new List<TicketPrice>();

    public virtual Venue? Venue { get; set; }
}

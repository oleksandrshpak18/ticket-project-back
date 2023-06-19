using System;
using System.Collections.Generic;

namespace ticket_project_back.Data.Models;

public partial class TicketPrice
{
    public int TicketPriceId { get; set; }

    public int? EventId { get; set; }

    public int? VenueZoneId { get; set; }

    public int Price { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Event? Event { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual VenueZone? VenueZone { get; set; }
}

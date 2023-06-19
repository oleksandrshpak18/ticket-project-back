using System;
using System.Collections.Generic;

namespace ticket_project_back.Data.Models;

public partial class VenueZone
{
    public int VenueZoneId { get; set; }

    public int? VenueId { get; set; }

    public int? SeatTypeId { get; set; }

    public int RowsCount { get; set; }

    public int SeatsPerRowCount { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual SeatType? SeatType { get; set; }

    public virtual ICollection<TicketPrice> TicketPrices { get; set; } = new List<TicketPrice>();

    public virtual Venue? Venue { get; set; }
}

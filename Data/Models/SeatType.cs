using System;
using System.Collections.Generic;

namespace ticket_project_back.Data.Models;

public partial class SeatType
{
    public int SeatTypeId { get; set; }

    public string SeatType1 { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<VenueZone> VenueZones { get; set; } = new List<VenueZone>();
}

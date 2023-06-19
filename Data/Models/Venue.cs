using System;
using System.Collections.Generic;

namespace ticket_project_back.Data.Models;

public partial class Venue
{
    public int VenueId { get; set; }

    public int? CityId { get; set; }

    public string VenueName { get; set; } = null!;

    public string? Description { get; set; }

    public string? Street { get; set; }

    public int? BuildingNumber { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? Img { get; set; }

    public virtual City? City { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<VenueZone> VenueZones { get; set; } = new List<VenueZone>();
}

using System;
using System.Collections.Generic;

namespace ticket_project_back.Data.Models;

public partial class City
{
    public int CityId { get; set; }

    public int? CountryId { get; set; }

    public string City1 { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<TicketOffice> TicketOffices { get; set; } = new List<TicketOffice>();

    public virtual ICollection<Venue> Venues { get; set; } = new List<Venue>();
}

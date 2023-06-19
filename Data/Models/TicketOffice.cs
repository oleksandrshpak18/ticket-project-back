using System;
using System.Collections.Generic;

namespace ticket_project_back.Data.Models;

public partial class TicketOffice
{
    public int TicketOfficeId { get; set; }

    public int? CityId { get; set; }

    public string Street { get; set; } = null!;

    public int BuildingNumber { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<Cashier> Cashiers { get; set; } = new List<Cashier>();

    public virtual City? City { get; set; }
}

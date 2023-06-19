using System;
using System.Collections.Generic;

namespace ticket_project_back.Data.Models;

public partial class Cashier
{
    public int CashierId { get; set; }

    public int? TicketOfficeId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual TicketOffice? TicketOffice { get; set; }
}

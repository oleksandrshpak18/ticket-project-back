using System;
using System.Collections.Generic;

namespace ticket_project_back.Data.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int? TicketPriceId { get; set; }

    public int TicketNumber { get; set; }

    public int? RowNumber { get; set; }

    public int? SeatNumber { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual TicketPrice? TicketPrice { get; set; }
}

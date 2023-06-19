using System;
using System.Collections.Generic;

namespace ticket_project_back.Data.Models;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int? OrderId { get; set; }

    public int? TicketId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Ticket? Ticket { get; set; }
}

using System;
using System.Collections.Generic;

namespace ticket_project_back.Data.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public int? CashierId { get; set; }

    public int OperationNumber { get; set; }

    public DateTime OperationDatetime { get; set; }

    public int TotalPrice { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Cashier? Cashier { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}

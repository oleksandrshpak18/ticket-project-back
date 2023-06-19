using System;
using System.Collections.Generic;

namespace ticket_project_back.Data.Models;

public partial class EventType
{
    public int EventTypeId { get; set; }

    public string EventType1 { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}

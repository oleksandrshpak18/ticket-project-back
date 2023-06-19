using System;
using System.Collections.Generic;

namespace ticket_project_back.Data.Models;

public partial class PerformerType
{
    public int PerformerTypeId { get; set; }

    public string PerformerType1 { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<Performer> Performers { get; set; } = new List<Performer>();
}

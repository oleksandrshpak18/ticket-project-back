using System;
using System.Collections.Generic;

namespace ticket_project_back.Data.Models;

public partial class PerformerGenre
{
    public int PerformerGenreId { get; set; }

    public int? PerformerId { get; set; }

    public int? GenreId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Genre? Genre { get; set; }

    public virtual Performer? Performer { get; set; }
}

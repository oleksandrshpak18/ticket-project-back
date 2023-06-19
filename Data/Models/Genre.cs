using System;
using System.Collections.Generic;

namespace ticket_project_back.Data.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string Genre1 { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<PerformerGenre> PerformerGenres { get; set; } = new List<PerformerGenre>();
}

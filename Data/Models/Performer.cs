using System;
using System.Collections.Generic;

namespace ticket_project_back.Data.Models;

public partial class Performer
{
    public int PerformerId { get; set; }

    public int? PerformerTypeId { get; set; }

    public int? CountryId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int? CareerBeginYear { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? Img { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<PerformerGenre> PerformerGenres { get; set; } = new List<PerformerGenre>();

    public virtual PerformerType? PerformerType { get; set; }
}

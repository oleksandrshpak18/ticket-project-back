using System;
using System.Collections.Generic;

namespace ticket_project_back.Data.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string Country1 { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual ICollection<Performer> Performers { get; set; } = new List<Performer>();
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ticket_project_back.Data.Models;

public partial class Country
{
    public Country(int countryId, string country1)
    {
        CountryId = countryId;
        Country1 = country1;
    }

    public int CountryId { get; set; }

    public string Country1 { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
    [NotMapped]
    public virtual ICollection<Performer> Performers { get; set; } = new List<Performer>();
}

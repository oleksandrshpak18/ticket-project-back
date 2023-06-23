using ticket_project_back.Data.Models;

namespace ticket_project_back.Data.ViewModels
{
    public class VenueVM
    {
        public int VenueId { get; set; }

        public string? City { get; set; }

        public string VenueName { get; set; } = null!;

        public string? Description { get; set; }

        public string? Street { get; set; }

        public int? BuildingNumber { get; set; }

        public string? Img { get; set; }

        public virtual List<VenueZoneVm> VenueZones { get; set; } = new List<VenueZoneVm>();
    }
}

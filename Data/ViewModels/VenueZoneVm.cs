using ticket_project_back.Data.Models;

namespace ticket_project_back.Data.ViewModels
{
    public class VenueZoneVm
    {
        public string? SeatType { get; set; }
        public int RowsCount { get; set; }
        public int SeatsPerRowCount { get; set; }
    }
}

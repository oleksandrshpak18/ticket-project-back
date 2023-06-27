using ticket_project_back.Data.Models;

namespace ticket_project_back.Data.ViewModels
{
    public class OrderVM
    {
        public CustomerVM? Customer { get; set; }
        public ICollection<TicketVM>? Tickets { get; set; }
    }
}

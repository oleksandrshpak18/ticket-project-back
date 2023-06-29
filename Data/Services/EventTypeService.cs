using ticket_project_back.Data.Interfaces;
using ticket_project_back.Data.ViewModels;

namespace ticket_project_back.Data.Services
{
    public class EventTypeService: IGetClassifiers<EventTypeVM>
    {
        private TicketDbContext _context;
        public EventTypeService(TicketDbContext context)
        {
            _context = context;
        }

        public IEnumerable<EventTypeVM> GetAllClassifiers()
        {
            return _context.EventTypes.Select(e => new EventTypeVM() { EventType = e.EventType1 }).ToList();
        }
    }
}

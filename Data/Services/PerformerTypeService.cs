using ticket_project_back.Data.Interfaces;
using ticket_project_back.Data.ViewModels;

namespace ticket_project_back.Data.Services
{
    public class PerformerTypeService: IGetClassifiers<PerformerTypeVM>
    {
        private TicketDbContext _context;
        public PerformerTypeService(TicketDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PerformerTypeVM> GetAllClassifiers()
        {
            return _context.PerformerTypes.Select(e => new PerformerTypeVM() {PerformerType = e.PerformerType1}).ToList();
        }
    }
}

using ticket_project_back.Data.Interfaces;
using ticket_project_back.Data.ViewModels;

namespace ticket_project_back.Data.Services
{
    public class GenreService : IGetClassifiers<GenreVM>
    {
        private TicketDbContext _context;
        public GenreService(TicketDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GenreVM> GetAllClassifiers()
        {
            return _context.Genres.Select(e => new GenreVM() { Genre = e.Genre1 }).ToList();
        }
    }
}

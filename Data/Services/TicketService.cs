using ticket_project_back.Data.Models;
using ticket_project_back.Data.ViewModels;

namespace ticket_project_back.Data.Services
{
    public class TicketService
    {
        private TicketDbContext _context;
        public TicketService(TicketDbContext context)
        {
            _context = context;
        }

        public TicketVM ConvertToVm(Ticket p)
        {
            TicketVM? res = (p == null) ? null : new TicketVM()
            {
                EventId = p.TicketPrice?.EventId,
                TicketPrice = p.TicketPrice.Price,
                RowNumber = p.RowNumber,
                SeatNumber = p.SeatNumber,
                TicketNumber = p.TicketNumber,
                VenueId = p.TicketPrice.VenueZone.VenueId,
                SeatType = p.TicketPrice.VenueZone.SeatType.SeatType1
            };

            return res;
        }
        public IEnumerable<Ticket> GetWithRelations(int id)
        {
            return _context.Tickets
                .Where(t => t.TicketPrice.EventId == id)
                .Select(p => new Ticket
                {
                    TicketId = p.TicketId,
                    TicketPriceId = p.TicketPriceId,
                    TicketNumber = p.TicketNumber,
                    RowNumber = p.RowNumber,
                    SeatNumber = p.SeatNumber,
                    TicketPrice = new TicketPrice
                    {
                        TicketPriceId = p.TicketPrice.TicketPriceId,
                        EventId = p.TicketPrice.EventId,
                        Price = p.TicketPrice.Price,
                        VenueZone = new VenueZone
                        {
                            VenueZoneId = p.TicketPrice.VenueZone.VenueZoneId,
                            SeatType = new SeatType { SeatType1 = p.TicketPrice.VenueZone.SeatType.SeatType1}, 
                            VenueId = p.TicketPrice.VenueZoneId
                        }
                    }
                }).ToList();
        }

        public IEnumerable<TicketVM> GetSoldByEventId(int id)
        {
            var res = GetWithRelations(id).Where(x => x.TicketPrice?.EventId == id).ToList();
            return res.Select(x => ConvertToVm(x));
        }

        public bool isPresent(TicketVM item)
        {
            return _context.Tickets
                .Any(x => x.TicketPriceId == (_context.TicketPrices
                    .Where(x => x.EventId == item.EventId
                        && x.VenueZoneId == _context.VenueZones
                            .Where(y => y.SeatType.SeatType1 == item.SeatType && y.VenueId == item.VenueId)
                            .First().VenueZoneId).FirstOrDefault().TicketPriceId)
                    && x.RowNumber == item.RowNumber && x.SeatNumber == item.SeatNumber);
        }



        public bool isPriceValid(int? priceId, int price)
        {
            return price == _context.TicketPrices.Where(x => x.TicketPriceId == priceId).First().Price;
        }

        public TicketVM AddNew(TicketVM item)
        {
            if (isPresent(item)) { throw new ArgumentException("The specified ticket has been already sold."); }

            var _ticketPriceId = _context.TicketPrices
                    .Where(x => x.EventId == item.EventId
                        && x.VenueZoneId == _context.VenueZones
                            .Where(y => y.SeatType.SeatType1 == item.SeatType && y.VenueId == item.VenueId)
                            .First().VenueZoneId)?.FirstOrDefault()?.TicketPriceId;

            if(_ticketPriceId == null ) { throw new Exception("Price for specified event in specified venue not found. Suppose it is not valid in a request."); }
            else if (!isPriceValid(_ticketPriceId, item.TicketPrice)) { throw new ArgumentException("The price is invalid."); }

            var lastNumber = _context.Tickets
                .Where(x => x.TicketPriceId == _ticketPriceId)
                .Any() 
                ? _context.Tickets.Where(x => x.TicketPriceId == _ticketPriceId).Max(x => x.TicketNumber) 
                : 0;

            var _ticket = new Ticket()
            {
                CreateDate = DateTime.Now,
                RowNumber = item.RowNumber,
                SeatNumber = item.SeatNumber,
                TicketPriceId = _ticketPriceId,
                TicketNumber = lastNumber + 1
            };

            _context.Tickets.Add(_ticket);
            _context.SaveChanges();
            return item;
        }

    }
}

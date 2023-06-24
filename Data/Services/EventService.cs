using Microsoft.IdentityModel.Tokens;
using ticket_project_back.Data.Interfaces;
using ticket_project_back.Data.Models;
using ticket_project_back.Data.ViewModels;

namespace ticket_project_back.Data.Services
{
    public class EventService : IGet<EventVM, Event>, IEvent<EventVM>, IUpdateDescription<EventVM>, IUpdateImage<EventVM>
    {
        private TicketDbContext _context;
        public EventService(TicketDbContext context)
        {
            _context = context;
        }

        public EventVM ConvertToVm(Event ev)
        {
            EventVM? res = (ev == null) ? null : new EventVM()
            {
                EventId = ev.EventId,
                EventTitle = ev.EventTitle,
                EventDate = ev.EventDate,
                EventDescription = ev.EventDescription,
                BeginTime = ev.BeginTime,
                Duration = ev.Duration,
                MinAgeRestriction = ev.MinAgeRestriction,
                Img = ev.Img,
                EventType = ev.EventType?.EventType1
            };

            if (ev.Performer != null)
            {
                res.Performer = new PerformerVM
                {
                    PerformerId = ev.Performer.PerformerId,
                    Title = ev.Performer.Title,
                    Description = ev.Performer.Description,
                    CareerBeginYear = ev.Performer.CareerBeginYear,
                    Img = ev.Performer.Img,
                    Country = ev.Performer.Country?.Country1,
                    PerformerType = ev.Performer.PerformerType?.PerformerType1,
                    PerformerGenres = ev.Performer.PerformerGenres.Select(n => n.Genre.Genre1).ToList()
                };
            }

            if(ev.TicketPrices != null)
            {
                res.TicketPrices = ev.TicketPrices.Select(n => new TicketPriceVM
                {
                    EventId = n.EventId,
                    SeatType = n.VenueZone?.SeatType?.SeatType1,
                    Price = n.Price
                }).ToList();
            }

            if (ev.Venue != null)
            {
                res.Venue = new VenueVM
                {
                    VenueId = ev.Venue.VenueId,
                    VenueName = ev.Venue.VenueName,
                    Description = ev.Venue.Description,
                    City = ev.Venue.City?.City1,
                    Street = ev.Venue.Street,
                    BuildingNumber = ev.Venue.BuildingNumber,
                    Img = ev.Venue.Img,
                    VenueZones = ev.Venue.VenueZones
                            .Select(n => new VenueZoneVm
                            {
                                SeatType = n.SeatType?.SeatType1,
                                RowsCount = n.RowsCount,
                                SeatsPerRowCount = n.SeatsPerRowCount
                            }
                        ).ToList()
                };
            }

            return res;
        }

        public IEnumerable<EventVM> GetAll()
        {
            return GetWithRelations().Select(x => ConvertToVm(x));
        }

        public EventVM GetById(int id)
        {
            var res = GetWithRelations().FirstOrDefault(x => x.EventId == id);
            return ConvertToVm(res);
        }

        public IEnumerable<EventVM> GetByPerformerId(int performerId)
        {             
            var res = GetWithRelations().Where(x => x.PerformerId == performerId);
            return res.Select(x => ConvertToVm(x));
        }

        public IEnumerable<EventVM> GetByVenueId(int venueId)
        {
            var res = GetWithRelations().Where(x => x.VenueId == venueId);
            return res.Select(x => ConvertToVm(x));
        }

        public IEnumerable<Event> GetWithRelations()
        {
            return _context.Events
               .Select(ev => new Event
               {
                   EventId = ev.EventId,
                   PerformerId = ev.PerformerId,
                   EventTypeId = ev.EventTypeId,
                   VenueId = ev.VenueId,
                   Duration = ev.Duration,
                   BeginTime = ev.BeginTime,
                   EventDate = ev.EventDate,
                   EventDescription = ev.EventDescription,
                   EventTitle = ev.EventTitle,
                   MinAgeRestriction = ev.MinAgeRestriction,
                   EventType = ev.EventType,
                   Performer = new Performer
                       {
                       PerformerId = ev.Performer.PerformerId,
                       Title = ev.Performer.Title,
                       Description = ev.Performer.Description,
                       CareerBeginYear = ev.Performer.CareerBeginYear,
                       Img = ev.Performer.Img,
                       CountryId = ev.Performer.CountryId,
                       CreateDate = ev.Performer.CreateDate,
                       UpdateDate = ev.Performer.UpdateDate,
                       PerformerTypeId = ev.Performer.PerformerTypeId,
                       Country = ev.Performer.Country,
                       PerformerGenres = (ICollection<PerformerGenre>)ev.Performer.PerformerGenres.Select(n => new PerformerGenre { Genre = n.Genre }),
                       PerformerType = ev.Performer.PerformerType
                       },
                   TicketPrices = (ICollection<TicketPrice>)ev.TicketPrices
                       .Select(n => new TicketPrice
                           {
                                EventId = n.EventId,
                                Price = n.Price,
                                VenueZone = new VenueZone
                                {
                                    SeatType = n.VenueZone.SeatType
                                }
                           }),
                   Venue =  new Venue
                       {
                            VenueId = ev.Venue.VenueId,
                            VenueName = ev.Venue.VenueName,
                            Description = ev.Venue.Description,
                            City = ev.Venue.City,
                            Street = ev.Venue.Street,
                            BuildingNumber = ev.Venue.BuildingNumber,
                            Img = ev.Venue.Img,
                            CreateDate = ev.Venue.CreateDate,
                            UpdateDate = ev.Venue.UpdateDate,
                            VenueZones = (ICollection<VenueZone>)ev.Venue.VenueZones
                                .Select(n => new VenueZone
                                    {
                                        SeatType = n.SeatType,
                                        RowsCount = n.RowsCount,
                                        SeatsPerRowCount = n.SeatsPerRowCount
                                    }
                                )
                       },
                   Img = ev.Img
               }).ToList();
        }

        public IEnumerable<EventVM> SearchByKeyword(string keyword)
        {
            if (keyword.IsNullOrEmpty())
            {
                return null;
            }

            string lowercaseKeyWord = keyword.ToLower();
            var res = GetWithRelations()
                .Where(x => x.EventTitle.ToLower().Contains(lowercaseKeyWord) ||
                        (x.EventDescription != null && x.EventDescription.Contains(keyword)));

            return res.Select(x => ConvertToVm(x));
        }

        public EventVM updateDescription(int id, string newDescr)
        {
            var _event = _context.Events.FirstOrDefault(n => n.EventId == id);
            if (_event != null)
            {
                _event.EventDescription = newDescr;
                _context.SaveChanges();
            }
            return ConvertToVm(_event);
        }

        public EventVM updateImage(int id, string imageUrl)
        {
            var _event = _context.Events.FirstOrDefault(n => n.EventId == id);
            if (_event != null)
            {
                _event.Img = imageUrl;
                _context.SaveChanges();
            }
            return ConvertToVm(_event);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ticket_project_back.Data.Interfaces;
using ticket_project_back.Data.Models;
using ticket_project_back.Data.ViewModels;

namespace ticket_project_back.Data.Services
{
    public class VenueService : IGet<VenueVM, Venue>, IUpdateImage<VenueVM>, IUpdateDescription<VenueVM>
    {
        private TicketDbContext _context;
        public VenueService(TicketDbContext context)
        {
            _context = context;
        }
        public VenueVM ConvertToVm(Venue v)
        {
            VenueVM? res = (v == null) ? null : new VenueVM()
            {
                VenueId = v.VenueId,
                VenueName = v.VenueName,
                Description = v.Description,
                City = v.City?.City1,
                Street = v.Street,
                BuildingNumber = v.BuildingNumber,
                Img = v.Img,
                VenueZones = v.VenueZones
                    .Select(n => new VenueZoneVm
                    {
                        SeatType = n.SeatType?.SeatType1,
                        RowsCount = n.RowsCount,
                        SeatsPerRowCount = n.SeatsPerRowCount
                    }
                ).ToList(),
            };

            return res;
        }

        public IEnumerable<VenueVM> GetAll()
        {
            return GetWithRelations().Select(x => ConvertToVm(x));
        }

        public VenueVM GetById(int id)
        {
            var res = GetWithRelations().FirstOrDefault(x => x.VenueId == id);
            return ConvertToVm(res);
        }

        public IEnumerable<Venue> GetWithRelations()
        {
            return _context.Venues
                .Select(v => new Venue
                {
                    VenueId = v.VenueId,
                    VenueName = v.VenueName,
                    Description = v.Description,
                    City = v.City,
                    Street = v.Street,
                    BuildingNumber = v.BuildingNumber,
                    Img = v.Img,
                    CreateDate = v.CreateDate,
                    UpdateDate = v.UpdateDate,
                    VenueZones = (ICollection<VenueZone>)v.VenueZones
                        .Select(n => new VenueZone 
                        { 
                            SeatType = n.SeatType, 
                            RowsCount = n.RowsCount,
                            SeatsPerRowCount = n.SeatsPerRowCount
                        }
                    )
                }).ToList();
        }

        public IEnumerable<VenueVM> SearchByKeyword(string keyword)
        {
            if (keyword.IsNullOrEmpty())
            {
                return null;
            }

            string lowercaseKeyWord = keyword.ToLower();
            var res = GetWithRelations()
                .Where(x => x.VenueName.ToLower().Contains(lowercaseKeyWord) ||
                        (x.Description != null && x.Description.Contains(keyword)));

            return res.Select(x => ConvertToVm(x));
        }

        public VenueVM updateDescription(int id, string newDescr)
        {
            var _venue = _context.Venues.FirstOrDefault(n => n.VenueId == id);
            if (_venue != null)
            {
                _venue.Description = newDescr;
                _context.SaveChanges();
            }
            return ConvertToVm(_venue);
        }

        public VenueVM updateImage(int id, string imageUrl)
        {
            var _venue = _context.Venues.FirstOrDefault(n => n.VenueId == id);
            if (_venue != null)
            {
                _venue.Img = imageUrl;
                _context.SaveChanges();
            }
            return ConvertToVm(_venue);
        }
    }
}

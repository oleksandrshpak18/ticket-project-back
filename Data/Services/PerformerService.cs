using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ticket_project_back.Data.Interfaces;
using ticket_project_back.Data.Models;
using ticket_project_back.Data.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ticket_project_back.Data.Services
{
    public class PerformerService : IGet<PerformerVM>, IUpdateImage<PerformerVM>
    {
        private TicketDbContext _context;
        public PerformerService(TicketDbContext context)
        {
            _context = context;
        }
        
        private PerformerVM ConvertToVm(Performer p)
        {
            PerformerVM? res = (p == null) ? null : new PerformerVM()
            {
                PerformerId = p.PerformerId,
                Title = p.Title,
                Description = p.Description,
                CareerBeginYear = p.CareerBeginYear,
                Img = p.Img,
                Country = p.Country?.Country1,
                PerformerType = p.PerformerType?.PerformerType1,
                PerformerGenres = p.PerformerGenres.Select(n => n.Genre.Genre1).ToList()
            };

           //if(res != null )
           // {
           //     res.Country = _context.Countries.FirstOrDefault(c => c.CountryId == p.CountryId)?.Country1;
           //     res.PerformerGenres = _context.Genres
           //         .Where(g => _context.PerformerGenres
           //             .Where(x => x.PerformerId == p.PerformerId)
           //             .Select(x => x.GenreId)
           //             .Contains(g.GenreId))
           //         .Select(g => g.Genre1)
           //         .ToList();

           //     res.PerformerType = _context.PerformerTypes.FirstOrDefault(c => c.PerformerTypeId == p.PerformerTypeId)?.PerformerType1;
           // }

            return res;
        }
        public IEnumerable<Performer> Get() 
        {
            return _context.Performers
                .Select(p => new Performer
                {
                   PerformerId = p.PerformerId,
                   Title =  p.Title,
                   Description =  p.Description,
                   CareerBeginYear = p.CareerBeginYear,
                   Img = p.Img,
                   CountryId = p.CountryId,
                   CreateDate = p.CreateDate,
                   UpdateDate = p.UpdateDate,
                   PerformerTypeId = p.PerformerTypeId,
                   Country = p.Country,
                   PerformerGenres = (ICollection<PerformerGenre>)p.PerformerGenres.Select(n => new PerformerGenre{Genre = n.Genre }),
                   PerformerType = p.PerformerType
                }).ToList();
               
        }
        public IEnumerable<PerformerVM> GetAll()
        {
            //var res  = _context.Performers.ToList();
            //var res  = _context.Performers
            //    .Select(p => new Performer
            //    {
            //        PerformerId = p.PerformerId,
            //        Title = p.Title,
            //        Description = p.Description,
            //        CareerBeginYear = p.CareerBeginYear,
            //        Img = p.Img,
            //        CountryId = p.CountryId,
            //        CreateDate = p.CreateDate,
            //        UpdateDate = p.UpdateDate,
            //        PerformerTypeId = p.PerformerTypeId,
            //        Country = p.Country,
            //        PerformerGenres = (ICollection<PerformerGenre>)p.PerformerGenres.Select(n => new PerformerGenre { Genre = n.Genre }),
            //        PerformerType = p.PerformerType
            //    }).ToList();
            ////return res.Select(x => ConvertToVm(x));
            return Get().Select(x => ConvertToVm(x));
        }

        public PerformerVM GetById(int id)
        {
            var res = Get().FirstOrDefault(x => x.PerformerId == id);
            return ConvertToVm(res);
        }

        public IEnumerable<PerformerVM> SearchByKeyword(string keyword)
        {
            var res = Get().Where(x => 
            x.Title.Contains(keyword) || x.Description.Contains(keyword));
            return res.Select(x => ConvertToVm(x));
        }

        public PerformerVM updateImage(int id, string imageUrl)
        {
            var _performer = _context.Performers.FirstOrDefault(n => n.PerformerId == id);
            if(_performer != null)
            {
                _performer.Img = imageUrl;
                _context.SaveChanges();
            }
            return ConvertToVm(_performer);
        }
    }
}

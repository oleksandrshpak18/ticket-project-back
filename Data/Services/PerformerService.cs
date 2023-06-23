using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ticket_project_back.Data.Interfaces;
using ticket_project_back.Data.Models;
using ticket_project_back.Data.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ticket_project_back.Data.Services
{
    public class PerformerService : IGet<PerformerVM, Performer>, IUpdateImage<PerformerVM>
    {
        private TicketDbContext _context;
        public PerformerService(TicketDbContext context)
        {
            _context = context;
        }
        
        public PerformerVM ConvertToVm(Performer p)
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

            return res;
        }
        public IEnumerable<Performer> GetWithRelations() 
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
            return GetWithRelations().Select(x => ConvertToVm(x));
        }

        public PerformerVM GetById(int id)
        {
            var res = GetWithRelations().FirstOrDefault(x => x.PerformerId == id);
            return ConvertToVm(res);
        }

        public IEnumerable<PerformerVM> SearchByKeyword(string keyword)
        {
            if(keyword.IsNullOrEmpty())
            {
                return null;
            }

            string lowercaseKeyWord = keyword.ToLower();
            var res = GetWithRelations()
                .Where(x => x.Title.ToLower().Contains(lowercaseKeyWord)||
                        (x.Description != null && x.Description.Contains(keyword)));
            //Console.WriteLine(res);
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

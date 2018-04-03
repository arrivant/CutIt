using CutIt.Repositories.Interfaces;
using CutIt.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CutIt.Repositories
{
    public class SqLiteLinkRepository : ILinkRepository
    {
        private readonly CutItDbContext _context;
        public SqLiteLinkRepository(CutItDbContext context)
        {
            _context = context;
        }

        public Link CreateLink(Link link)
        {
            _context.Links.Add(link);
            _context.SaveChanges();
            return link;
        }

        public Link ReadLink(int id){
            return _context.Links.SingleOrDefault(l => l.Id == id);
        }

        public void DeleteLink(int id)
        {
            Link link = _context.Links.Find(id);
            _context.Links.Remove(link);
            _context.SaveChanges();
        }

        public Link UpdateLink(Link link)
        {
            _context.Attach(link);
            var cos = _context.Entry(link).State;
            _context.Entry(link).State = EntityState.Modified;
            _context.SaveChanges();
            return link;
        }

        public IEnumerable<Link> GetLinks()
        {
            return _context.Links;
        }

        public (IEnumerable<Link>, int) GetLinks(int page, int linksPerPage)
        {
            var links = this.GetLinks();
            
            int linksCount = links.Count();
            var paginatedLinks = links.Skip(page * linksPerPage).Take(linksPerPage);            

            return (paginatedLinks, linksCount);
        }
    }
}
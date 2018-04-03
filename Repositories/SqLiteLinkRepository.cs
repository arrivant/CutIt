using CutIt.Repositories.Interfaces;
using CutIt.Models;
using System.Collections.Generic;

namespace CutIt.Repositories
{
    public class SqLiteLinkRepository : ILinkRepository
    {
        private readonly CutItDbContext _context;
        public SqLiteLinkRepository(CutItDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Link> GetLinks()
        {
            return _context.Links;
        }

        public void CreateLink(Link link)
        {
            _context.Links.Add(link);
            _context.SaveChanges();
        }

        public void DeleteLink(Link link)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateLink(Link link)
        {
            throw new System.NotImplementedException();
        }
    }
}
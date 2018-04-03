using System.Collections.Generic;
using System.Linq;
using CutIt.Models;
using CutIt.Repositories.Interfaces;

namespace CutIt.Repositories
{
    public class StaticLinkRepository : ILinkRepository
    {
        private List<Link> _links;

        public StaticLinkRepository()
        {
            _links = new List<Link>{
                new Link{Id = 0, OriginalLink = "www.wp.pl", ShortLink ="WbRAlpo"},
                new Link{Id = 1, OriginalLink = "www.o2.pl", ShortLink = "60p0mLj"},
            };
        }

        public IEnumerable<Link> GetLinks()
        {
            return _links;
        }

        public void CreateLink(Link link)
        {
            link.Id = _links.Count;
            _links.Add(link);
        }

        public void DeleteLink(Link link)
        {
            var idToDelete = _links.SingleOrDefault(x=>x.Id == link.Id);
            _links.Remove(idToDelete);
        }

        public void UpdateLink(Link link)
        {
            var idToUpdate = _links.FindIndex(x=>x.Id == link.Id);
            _links[idToUpdate] = link;
        }
    }
}
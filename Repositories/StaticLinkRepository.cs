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
                new Link{Id = 0, OriginalLink = "http://www.o2.pl", ShortLink ="g7okDd3"},
                new Link{Id = 1, OriginalLink = "http://www.wpgma.com", ShortLink = "23AREVv"},
            };
        }
       
        public Link CreateLink(Link link)
        {
            link.Id = _links.Count;
            _links.Add(link);
            return link;
        }

        public Link ReadLink(int id){
            return _links.SingleOrDefault(l => l.Id == id);
        }

        public void DeleteLink(int id)
        {
            var idToDelete = _links.SingleOrDefault(x=>x.Id == id);
            _links.Remove(idToDelete);
        }

        public Link UpdateLink(Link link)
        {
            var idToUpdate = _links.FindIndex(x=>x.Id == link.Id);
            _links[idToUpdate] = link;
            return link;
        }

         public IEnumerable<Link> GetLinks()
        {
            return _links;
        }

        public (IEnumerable<Link>, int) GetLinks(int page, int linksPerPage)
        {
            throw new System.NotImplementedException();
        }
    }
}
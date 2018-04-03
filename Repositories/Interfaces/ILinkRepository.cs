using System.Collections.Generic;
using CutIt.Models;

namespace CutIt.Repositories.Interfaces
{
    public interface ILinkRepository
    {
         IEnumerable<Link> GetLinks();
         (IEnumerable<Link>, int) GetLinks(int page, int linksPerPage);
         Link CreateLink(Link link);
         Link ReadLink(int id);
         void DeleteLink(int id);
         Link UpdateLink(Link link);
    }
}
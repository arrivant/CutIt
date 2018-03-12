using System.Collections.Generic;
using CutIt.Models;

namespace CutIt.Repositories.Interfaces
{
    public interface ILinkRepository
    {
         List<Link> GetLinks();
         void CreateLink(Link link);
         void DeleteLink(Link link);
         void UpdateLink(Link link);
    }
}
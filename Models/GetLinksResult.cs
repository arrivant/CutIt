using System.Collections.Generic;

namespace CutIt.Models
{
    public class GetLinksResult
    {
        public IEnumerable<Link> Links { get; set; }
        public PageInfo PageInfo { get; set; }
    }

    public class PageInfo
    {
        public int CurrentPage { get; set; }
        public int MaxPage { get; set; }
    }
}
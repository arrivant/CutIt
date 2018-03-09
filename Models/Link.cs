using System;
using System.ComponentModel.DataAnnotations;

namespace CutIt.Models
{
    public class Link
    {
        public Link(long id, string originalLink, string shortLink)
        {
            this.Id = id;
            this.OriginalLink = originalLink;
            this.ShortLink = shortLink;

        }
        public long Id { get; set; }

        [Display(Name = "Original Link")]
        public string OriginalLink { get; set; }

        [Display(Name = "Short Link")]
        public string ShortLink { get; set; }
    }
}
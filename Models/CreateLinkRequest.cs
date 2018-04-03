using System.ComponentModel.DataAnnotations;

namespace CutIt.Models
{
    public class CreateLinkRequest
    {
        [Url]
        [Required]
        public string OriginalLink { get; set; }

        public Link GetLink() => new Link { OriginalLink = this.OriginalLink};
    }
}
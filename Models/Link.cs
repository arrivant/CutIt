using System;
using System.ComponentModel.DataAnnotations;

namespace CutIt.Models
{
    public class Link
    {
        [Key]
        public int Id { get; set; }

        [Url]
        [Required]
        [Display(Name = "Link")]
        public string OriginalLink { get; set; }

        [Display(Name = "Short Link")]
        public string ShortLink { get; set; }
    }
}
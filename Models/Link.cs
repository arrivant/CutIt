using System;
using System.ComponentModel.DataAnnotations;

namespace CutIt.Models
{
    public class Link
    {
        public int Id { get; set; }

        [Display(Name = "Original Link")]
        public string OriginalLink { get; set; }

        [Display(Name = "Short Link")]
        public string ShortLink { get; set; }
    }
}
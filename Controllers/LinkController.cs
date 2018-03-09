using System.Collections.Generic;
using CutIt.Models;
using Microsoft.AspNetCore.Mvc;

namespace CutIt.Controllers
{
    public class LinkController : Controller
    {
        public static List<Link> Links = new List<Link>{
            new Link(1,"wp.pl","F#$F#A"),
            new Link(2,"onet.pl","F#$FAG#"),
        };

        public IActionResult Index()
        {
            return View(Links);
        }
    }
}

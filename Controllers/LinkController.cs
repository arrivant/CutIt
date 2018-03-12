using System.Collections.Generic;
using CutIt.Models;
using CutIt.Repositories.Interfaces;
using HashidsNet;
using Microsoft.AspNetCore.Mvc;

namespace CutIt.Controllers
{
    [Route("[controller]")]
    [Route("[controller]/[action]")]
    public class LinkController : Controller
    {
        private ILinkRepository _repository;

        public LinkController(ILinkRepository linkRepository)
        {
            _repository = linkRepository;
        }

        [HttpGet("")]
        [HttpGet("~/")]
        [HttpGet("index")]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View(_repository.GetLinks());
        }

        [HttpPost("Create")]
        public IActionResult Create(Link link)
        {
            var hashids = new Hashids(link.OriginalLink, 7);
            string hash = hashids.Encode(link.OriginalLink.Length);

            link.ShortLink = hash;

            _repository.CreateLink(link);
            return Redirect("~/");
        }

        [HttpGet("Delete")]
        public IActionResult Delete(Link link)
        {
            _repository.DeleteLink(link);
            return Redirect("~/");
        }
    }
}


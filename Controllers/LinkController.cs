using System.Collections.Generic;
using System.Linq;
using CutIt.Models;
using CutIt.Repositories.Interfaces;
using HashidsNet;
using Microsoft.AspNetCore.Mvc;

namespace CutIt.Controllers
{
    public class LinkController : Controller
    {
        private ILinkRepository _repository;

        public LinkController(ILinkRepository linkRepository)
        {
            _repository = linkRepository;
        }

        [Route("")]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View(_repository.GetLinks());
        }

        [HttpPost("Create")]
        public IActionResult Create(Link link)
        {
            if(ModelState.IsValid){
                var hashids = new Hashids(link.OriginalLink, 7);
                string hash = hashids.Encode(link.OriginalLink.Length);
                link.ShortLink = hash;

                _repository.CreateLink(link);

                return Redirect("Index");
            }

           var links = _repository.GetLinks();
           return View("Index", links);
        }

        [HttpGet("Edit")]
        public IActionResult Edit(Link link){
            return View("Edit", link);
        }

        [HttpPost("Update")]
        public IActionResult Update(Link link)
        {
            if(ModelState.IsValid){
                var linkOriginal = _repository.GetLinks().First(l => l.ShortLink == link.ShortLink);
                linkOriginal.OriginalLink = link.OriginalLink;
                return Redirect("Index");
            }
            
            return View("Edit", link);
        }

        [HttpGet("Delete")]
        public IActionResult Delete(Link link)
        {
            _repository.DeleteLink(link);
            return Redirect("Index");
        }
    }
}


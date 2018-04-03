using System.Collections.Generic;
using System.Linq;
using CutIt.Models;
using CutIt.Repositories.Interfaces;
using HashidsNet;
using Microsoft.AspNetCore.Mvc;

namespace CutIt.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class LinkController : Controller
    {
        private ILinkRepository _linkRepository;

        public LinkController(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }

        public IActionResult Index()
        {
            return View(_linkRepository.GetLinks().ToList());
        }

        [HttpPost("Create")]
        public IActionResult Create(Link link)
        {
            if(ModelState.IsValid){
                var hashids = new Hashids(link.OriginalLink, 7);
                string hash = hashids.Encode(link.OriginalLink.Length);
                link.ShortLink = hash;

                _linkRepository.CreateLink(link);

                return Redirect("Index");
            }

           var links = _linkRepository.GetLinks().ToList();
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
                var linkOriginal = _linkRepository.UpdateLink(link);
                return Redirect("Index");
            }
            
            return View("Edit", link);
        }

        [HttpGet("Delete")]
        public IActionResult Delete(Link link)
        {
            _linkRepository.DeleteLink(link.Id);
            return Redirect("Index");
        }
    }
}


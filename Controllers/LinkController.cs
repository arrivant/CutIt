using System.Collections.Generic;
using System.Linq;
using CutIt.Models;
using CutIt.Repositories.Interfaces;
using CutIt.Services.Hasher;
using HashidsNet;
using Microsoft.AspNetCore.Mvc;

namespace CutIt.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class LinkController : Controller
    {
        private ILinkRepository _linkRepository;
        private IHasher _hasher;

        public LinkController(ILinkRepository linkRepository, IHasher hasher)
        {
            _linkRepository = linkRepository;
            _hasher = hasher;
        }

        public IActionResult Index()
        {
            return View(_linkRepository.GetLinks().ToList());
        }

        [HttpPost("Create")]
        public IActionResult Create(Link link)
        {
            if(ModelState.IsValid){
                link.ShortLink = _hasher.GetHash(link.OriginalLink);
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


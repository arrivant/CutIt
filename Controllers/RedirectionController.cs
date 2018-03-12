using System.Linq;
using CutIt.Models;
using CutIt.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CutIt.Controllers
{
    public class LinkRedirectionController
    {
        private ILinkRepository _repository;

        public LinkRedirectionController(ILinkRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public HttpResponseMessage RedirectToOrigin(string shortLink)
        {
            Link link = _repository.GetLinks().SingleOrDefault(x => x.ShortLink == shortLink);
        }
    }
}
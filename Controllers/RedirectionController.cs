using System.Linq;
using CutIt.Models;
using CutIt.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CutIt.Controllers
{
    public class LinkRedirectionController : Controller
    {
        private ILinkRepository _repository;

        public LinkRedirectionController(ILinkRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{shortLink}")]
        public ActionResult RedirectPage(string shortLink)
        {
            Link link = _repository.GetLinks().SingleOrDefault(x => x.ShortLink.Equals(shortLink));
            if(link == null)
                return Redirect("/");
            return Redirect(link.OriginalLink);
        }
    }
}
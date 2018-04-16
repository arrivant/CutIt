using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CutIt.Models;
using CutIt.Repositories.Interfaces;
using CutIt.Services.Hasher;
using HashidsNet;
using Microsoft.AspNetCore.Mvc;

namespace CutIt.Controllers
{
    [Route("api/[controller]")]
    public class LinkApiController : Controller
    {

        private ILinkRepository _linkRepository;
        private IHasher _hasher;

        public LinkApiController(ILinkRepository linkRepository, IHasher hasher)
        {
            _linkRepository = linkRepository;
            _hasher = hasher;
        }

        // POST api/links
        [HttpPost]
        public IActionResult CreateLink([FromBody]CreateLinkRequest linkToCreate)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            Link link = linkToCreate.GetLink();
            link.ShortLink = _hasher.GetHash(link.OriginalLink);

            return Ok(_linkRepository.CreateLink(link) != null);
        }

        // GET api/links/{id}
        [HttpGet("{id}")]
        public IActionResult ReadLink(int id)
        {
            Link _link = _linkRepository.ReadLink(id);
            
            if(_link == null)
                return NotFound();
            return Ok(_link);
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update([FromBody]Link link)
        {
            Link _link = _linkRepository.UpdateLink(link);
            
            if(_link == null)
                return NotFound();
            return Ok(_link);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _linkRepository.DeleteLink(id);
            return Ok();
        }

                // GET api/values
        [HttpGet]
        public IActionResult GetLinks([FromQuery]GetLinksRequest request)
        {
            var (links, linksCount) = _linkRepository.GetLinks(request.Page - 1, request.ItemPerPage);

            var result = new GetLinksResult
            {
                Links = links,
                PageInfo = new PageInfo
                {
                    CurrentPage = request.Page,
                    MaxPage = linksCount % request.ItemPerPage == 0 ? linksCount / request.ItemPerPage : linksCount / request.ItemPerPage + 1
                }
            };

            return Ok(result);
        }
    }
}

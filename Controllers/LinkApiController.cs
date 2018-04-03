using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CutIt.Models;
using CutIt.Repositories.Interfaces;
using HashidsNet;
using Microsoft.AspNetCore.Mvc;

namespace CutIt.Controllers
{
    [Route("api/[controller]")]
    public class LinkApiController : Controller
    {

        private ILinkRepository _linkRepository;

        public LinkApiController(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }

        // POST api/links
        [HttpPost]
        public IActionResult CreateLink([FromBody]CreateLinkRequest linkToCreate)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            Link link = linkToCreate.GetLink();
            var hashids = new Hashids(link.OriginalLink, 7);
            string hash = hashids.Encode(link.OriginalLink.Length);
            link.ShortLink = hash;

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

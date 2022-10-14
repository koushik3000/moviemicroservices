using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Teatres.APi.Entities;
using Teatres.APi.Repositories;

namespace Teatres.APi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TeatreController : Controller
    {
        private readonly ITeatreRepository _repository;

        public TeatreController(ITeatreRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeatreDetail>>> GetAllTeatres()
        {
            var List = await _repository.GetAllTeatres();
            return Ok(List);
        }

        [Route("[action]/{movieName}", Name = "GetTeatreByMovieName")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeatreDetail>>> GetTeatreByMovieName(string movieName)
        {
            var movies = await _repository.GetTeatreByMovieName(movieName);
            return Ok(movies);
        }



        [Route("[action]/{city}", Name = "GetTeatreByCity")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeatreDetail>>> GetTeatreByCity(string city)
        {
            var movies = await _repository.GetTeatreByCity(city);
            return Ok(movies);
        }

        [Route("[action]/{teatreName}", Name = "GetTeatreBYName")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeatreDetail>>> GetTeatreBYName(string teatreName)
        {
            var movies = await _repository.GetTeatreBYName(teatreName);
            return Ok(movies);
        }

        [HttpPost]
        [ProducesResponseType(typeof(TeatreDetail), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TeatreDetail>> CreateTeatreDetail([FromBody] TeatreDetail teatreDetail)
        {
            await _repository.CreateTeatreDetail(teatreDetail);

            return CreatedAtRoute("GetTeatreBYName", new { id = teatreDetail.TeatreName }, teatreDetail);
        }

        [HttpPut]
        [ProducesResponseType(typeof(TeatreDetail), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateTeatreDetail([FromBody] TeatreDetail teatreDetail)
        {
            return Ok(await _repository.UpdateTeatreDetail(teatreDetail));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteTeatreDetail")]
        [ProducesResponseType(typeof(TeatreDetail), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteTeatreDetail(string id)
        {
            return Ok(await _repository.DeleteTeatreDetail(id));
        }
    }
}

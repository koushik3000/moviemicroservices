using Microsoft.AspNetCore.Mvc;
using Movies.API.Entities;
using Movies.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Movies.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MovieController : Controller
    {
        private readonly IMovieDetailRepository _repository;

        public MovieController(IMovieDetailRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDetail>>> GetMovies()
        {
            var movies = await _repository.GetMovies();
            return Ok(movies);
        }

        [Route("[action]/{name}", Name = "GetMovieByName")]
        [HttpGet]       
        public async Task<ActionResult<IEnumerable<MovieDetail>>> GetMovieByName(string name)
        {
            var movies = await _repository.GetMovieByName(name);
            return Ok(movies);
        }

        [Route("[action]/{language}", Name = "GetMovieByLanguage")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDetail>>> GetMovieByLanguage(string language)
        {
            var movies = await _repository.GetMovieByLanguage(language);
            return Ok(movies);
        }

        [HttpPost]
        [ProducesResponseType(typeof(MovieDetail), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<MovieDetail>> CreateMovieDetail([FromBody] MovieDetail movieDetail)
        {
           await _repository.CreateMovieDetail(movieDetail);

            return CreatedAtRoute("GetMovieByName", new { id = movieDetail.MovieName }, movieDetail);
        }

        [HttpPut]
        [ProducesResponseType(typeof(MovieDetail), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMovieDetail([FromBody] MovieDetail movieDetail)
        {
            return Ok(await _repository.UpdateMovieDetail(movieDetail));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteMovieDetail")]
        [ProducesResponseType(typeof(MovieDetail), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMovieDetail(string id)
        {
            return Ok(await _repository.DeleteMovieDetail(id));
        }

    }
}

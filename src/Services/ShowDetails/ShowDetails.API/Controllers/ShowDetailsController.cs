using Microsoft.AspNetCore.Mvc;
using ShowDetails.API.Entities;
using ShowDetails.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ShowDetails.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShowDetailsController : ControllerBase
    {
        private readonly IShowDetailsRepository _repository;

        public ShowDetailsController(IShowDetailsRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("{theaterId}", Name = "GetShowDetailsByID")]

        [ProducesResponseType(typeof(Details), (int)HttpStatusCode.OK)]

        public async Task<ActionResult<Details>> GetShowDetailsByID(int theaterId)

        {
            var a = await _repository.GetShowDetailsByID(theaterId);
            return Ok(a);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Details), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Details>> UpdateDetails([FromBody] Details coun)
        {
            return Ok(await _repository.UpdateDetails(coun));
        }

        [HttpDelete("{ShowID}", Name = "DeleteDetails")]
        [ProducesResponseType(typeof(Details), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Details>> DeleteDetails(int ShowID)
        {
            return Ok(await _repository.DeleteDetails(ShowID));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Details), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Details>> CreateDetails([FromBody] Details coun)
        {
           var res= await _repository.CreateDetails(coun);
            return Ok(res);
        }

    }
}

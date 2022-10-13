
using bevaregas.Entities;
using bevaregas.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace bevaregas.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BevarageController : ControllerBase
    {
        private readonly ISnackRepository _snackRepository;

        public BevarageController(ISnackRepository snackRepository)
        {
            _snackRepository = snackRepository ?? throw new ArgumentNullException(nameof(snackRepository));
        }

        [HttpGet("{userName}", Name = "GetBasket")]
        [ProducesResponseType(typeof(Snack), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Snack>> GetSnackList(string userName)
        {
            var basket = await _snackRepository.GetSnackList(userName);
            return Ok(basket ?? new Snack(userName));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Snack), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Snack>> UpdateSnack([FromBody] Snack basket)
        {
            return Ok(await _snackRepository.UpdateSnack(basket));
        }

        [HttpDelete("{userName}", Name = "DeleteSnacklist")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteSnacklist(string userName)
        {
            await _snackRepository.DeleteSnacklist(userName);
            return Ok();
        }


    }
}

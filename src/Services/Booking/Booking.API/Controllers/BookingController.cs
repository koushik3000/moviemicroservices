using AutoMapper;
using Booking.API.Repository;
using Booking.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _repository;

        public BookingController(IBookingRepository repository)
        {
            _repository = repository;
        }

        [HttpPost(Name = "PostBooking")]
        public async Task<ActionResult<TicketBooking>> PostBooking([FromBody] TicketBooking booking)
        {
            var result = await _repository.PostBooking(booking);
            return Ok(result);
        } 

        [HttpGet(Name = "GetAllBookings")]
        public async Task<ActionResult<IEnumerable<TicketBooking>>> GetAllBookings()
        {
            var res = await _repository.GetAllBookings();
            
            return Ok(res);
        }

        [HttpGet("{userName}",Name = "GetTicketBookingsByUsername")]
        public async Task<ActionResult<IEnumerable<TicketBooking>>> GetTicketBookingsByUsername(string userName)
        {
            var res = await _repository.GetTicketBookingsByUsername(userName);
            return Ok(res);

        }
        [HttpGet]
        [Route("GetSeatNumberByDate")]
        public async Task<ActionResult<IEnumerable<TicketBooking>>> GetSeatNumberByDate(string date)
        {
            var res = await _repository.GetSeatNumberByDate(date);
            return Ok(res);

        }

        [HttpPut(Name = "UpdateBooking")]
        public async Task<ActionResult<IEnumerable<TicketBooking>>> UpdateBooking([FromBody] TicketBooking booking)
        {
            var res = await _repository.UpdateBooking(booking);
            return Ok(res);

        }

        [HttpDelete("{id}",Name = "DeleteBooking")]
        public async Task<ActionResult<bool>> DeleteBooking(int id)
        {
            var res = await _repository.DeleteBooking(id);
            return Ok(res);

        }




    }
}

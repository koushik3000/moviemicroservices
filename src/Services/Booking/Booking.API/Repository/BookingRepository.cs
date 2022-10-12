using Booking.Domain.Context;
using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingDbContext _bookingDbContext;
        private readonly ILogger<BookingRepository> _logger;

        public BookingRepository( BookingDbContext bookingDbContext, ILogger<BookingRepository> logger)
        {
            _bookingDbContext = bookingDbContext;
            _logger = logger;
        }

        public async Task<bool> DeleteBooking(int id)
        {
            try
            {
                TicketBooking product = await _bookingDbContext.ticketBookings.FirstOrDefaultAsync(d => d.BookingId == id);

                if (product == null)
                {
                    return false;
                }

                _bookingDbContext.ticketBookings.Remove(product);
                await _bookingDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    

        public async Task<IEnumerable<TicketBooking>> GetAllBookings()
        {
            IEnumerable<TicketBooking> bookings = await _bookingDbContext.ticketBookings.ToListAsync();
            return bookings;
        }

        public async Task<IEnumerable<TicketBooking>> GetSeatNumberByDate(string date)
        {
            //Get seatnumbers on that date


            var seatnumbers = await _bookingDbContext.ticketBookings.FromSqlRaw("Select * from ticketBookings where BookingDate={0}", date).ToListAsync();

            return seatnumbers;
        }

        public async Task<IEnumerable<TicketBooking>> GetTicketBookingsByUsername(string userName)
        {
        
            var result = await _bookingDbContext.ticketBookings.FromSqlRaw("Select * from ticketBookings where UserName={0}",userName).ToListAsync();

            return result;

        }

        public async Task<TicketBooking> PostBooking(TicketBooking booking)
        {
            var result = await _bookingDbContext.ticketBookings.AddAsync(booking);
            await _bookingDbContext.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<IEnumerable<TicketBooking>> UpdateBooking(TicketBooking booking)
        {
            var update = await _bookingDbContext.ticketBookings.Where(x => x.BookingId == booking.BookingId).SingleOrDefaultAsync();
            _bookingDbContext.ticketBookings.Remove(update);
            _bookingDbContext.ticketBookings.Update(booking);
            await _bookingDbContext.SaveChangesAsync();
            return null;
        }
    }
}

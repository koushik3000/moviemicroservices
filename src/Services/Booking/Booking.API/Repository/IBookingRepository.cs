using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API.Repository
{
   public interface IBookingRepository
    {
        //PostBooking
        Task<TicketBooking> PostBooking(TicketBooking booking);
        //GetBookingsbyUsername
        Task<IEnumerable<TicketBooking>> GetTicketBookingsByUsername(string userName);
        //GetAllBookingDetails
        Task<IEnumerable<TicketBooking>> GetAllBookings();
        //GetSeatNumberByDate
        Task<IEnumerable<TicketBooking>> GetSeatNumberByDate(string date);
        //UpdateBooking
        Task<IEnumerable<TicketBooking>> UpdateBooking(TicketBooking booking);
        //DeleteBooking
        Task<bool> DeleteBooking(int id);




    }
}

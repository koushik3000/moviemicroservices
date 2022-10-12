
using Booking.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Context
{
   public class BookingDbContextSeed
    {
        public static async Task SeedAsync(BookingDbContext bookingContext, ILogger<BookingDbContextSeed> logger)
        {
            if (!bookingContext.ticketBookings.Any())
            {
                bookingContext.ticketBookings.AddRange(GetPreconfiguredOrders());
                await bookingContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(BookingDbContext).Name);
            }
        }

        private static IEnumerable<TicketBooking> GetPreconfiguredOrders()
        {
            return new List<TicketBooking>
            {
                new TicketBooking() {UserName = "PhaniKumar",Email="Phaniveludurthi@gmail.com",MobileNumber="9381118256",BookingDate="13-10-2022"
                                    , SeatNumber="A1", ScreenId=1,ShowId=1,MovieName="RRR",TicketPrice=200}
            };
        }
    }
}

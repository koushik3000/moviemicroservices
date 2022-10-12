using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class TicketBooking : EntityBase
    {
        [Key]
        public int BookingId { get; protected set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string BookingDate { get; set; }
        public string SeatNumber { get; set; }
        public int ScreenId { get; set; }
        public  int ShowId { get; set; }
        public string MovieName { get; set; }
        public decimal TicketPrice { get; set; }

    }
}

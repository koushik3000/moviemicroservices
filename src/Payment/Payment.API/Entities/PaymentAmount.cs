using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.API.Entities
{
    public class PaymentAmount
    {
        public decimal TicketPrice { get; set; }
        public decimal BeverageItemPrice { get; set; }
    }
}

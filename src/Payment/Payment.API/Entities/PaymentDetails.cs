using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.API.Entities
{
    public class PaymentDetails
    {
        public string UserName { get; set; }
        public List<PaymentAmount> Amount { get; set; } = new List<PaymentAmount>();


        public PaymentDetails()
        {
            PaymentId = Guid.NewGuid();

        }
        public PaymentDetails(string userName)
        {
            UserName = userName;
        }

        public Guid PaymentId { get; private set; } 
        public string PaymentType { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in Amount)
                {
                    totalPrice += item.BeverageItemPrice + item.TicketPrice;
                }
                return totalPrice;
            }
        }
    }
}

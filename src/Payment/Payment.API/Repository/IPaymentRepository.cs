using Payment.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.API.Repository
{
    public interface IPaymentRepository
    {
        IEnumerable<PaymentDetails> GetPaymentDetails(string userName);
        void CreatePayment(PaymentDetails payment);
        IEnumerable<PaymentDetails> GetAllPaymentDetails();

        IEnumerable<PaymentDetails> UpdatePaymentDetails(PaymentDetails userName);

        bool DeletePayment(string userName);




    }
}

using Microsoft.Extensions.Caching.Distributed;
using Payment.API.Entities;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Payment.API.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public PaymentRepository(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public void CreatePayment(PaymentDetails payment)
        {
            if (payment == null)
            {
                throw new ArgumentOutOfRangeException(nameof(payment));

            }
            var db = _connectionMultiplexer.GetDatabase();
            var serial = JsonSerializer.Serialize(payment);
            db.StringSet(payment.UserName, serial);
            db.SetAdd("PaymentDetails", serial);
        }

        

        public IEnumerable<PaymentDetails> GetAllPaymentDetails()
        {
            var db = _connectionMultiplexer.GetDatabase();

            var set = db.SetMembers("PaymentDetails");
            if (set.Length > 0)
            {
                var arr = Array.ConvertAll(set, val => JsonSerializer.Deserialize<PaymentDetails>(val)).ToList();
                return arr;
                
            }
            return null;
        }


        public IEnumerable<PaymentDetails> GetPaymentDetails(string userName)
        {
            var db = _connectionMultiplexer.GetDatabase();
            var set = db.SetMembers("PaymentDetails");
            
            if (set.Length > 0)
            {
                var arr = Array.ConvertAll(set, val => JsonSerializer.Deserialize<PaymentDetails>(val)).ToList();
                return arr.Where(x => x.UserName == userName).ToList();
            }
            return null;
        }

        
    }
}

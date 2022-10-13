using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.API.Entities;
using Payment.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpGet("{userName}", Name = "GetPaymentsByUsername")]
        public ActionResult<PaymentDetails> GetPaymentsByUsername(string userName)
        {
            var payment = _paymentRepository.GetPaymentDetails(userName);
            if (payment != null)
            {
                return Ok(payment);
            }

            return NotFound();
        }

        

        [HttpPost]
        [ProducesResponseType(typeof(PaymentDetails), (int)HttpStatusCode.OK)]
        public ActionResult<PaymentDetails> CreatePayment(PaymentDetails payment)
        {
             _paymentRepository.CreatePayment(payment);

           return Ok(payment);
        }

        [HttpGet(Name = "GetAllPaymentDetails")]
        [ProducesResponseType(typeof(PaymentDetails), (int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<PaymentDetails>> GetAllPaymentDetails()
        {
            return Ok(_paymentRepository.GetAllPaymentDetails());
        }

    }
}

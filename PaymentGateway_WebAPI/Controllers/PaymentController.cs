using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway_DataAccess;
using PaymentGateway_Service;

namespace PaymentGateway_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;
        private readonly IBankService bankService;

        public PaymentController(IBankService bankService, IPaymentService paymentService)
        {
            this.paymentService = paymentService;
            this.bankService = bankService;
        }

        [HttpGet]
        public List<Payment> Get()
        {
            List<Payment> paymentDetails = new List<Payment>();
            var paymentList = paymentService.GetPayment().ToList();
            foreach (var payments in paymentList)
            {             
                Payment details = new Payment
                {         
                    PaymentId = payments.PaymentId,
                    Name = payments.Name,
                    EmailAddress = payments.EmailAddress,
                    CardNumber = payments.CardNumber.Substring(payments.CardNumber.Length - 4).PadLeft(payments.CardNumber.Length, '*'),
                    ExpiryDate = payments.ExpiryDate,            
                    Amount = payments.Amount,
                    CVV = payments.CVV,
                    PaymentSuccessful = payments.PaymentSuccessful,
                };
               
                paymentDetails.Add(details);
            }
            return paymentDetails;
        }

        // POST api/<PaymentController>
        [HttpPost]
        [Route("")]
        public async Task<string> Create([FromBody] Payment payment)
        {
            
            var bankDetails = bankService.GetBank(payment.CardNumber);
            if (bankDetails.AmountRemaining >= payment.Amount)
            {
                payment.PaymentSuccessful = true;
                
                try {
                    var updatedBank = await bankService.UpdateAsyncBank(bankDetails, payment.Amount);
                    var created = await paymentService.AddAsyncPayment(payment);
                    if (!created)
                    {
                        return "Error in processing payment. Please check the credit card details";
                    }
                    else {                    
                        return "Payment successful";
                    }
                }
                catch (Exception e)
                {
                    return (e.Message);
                }
                            
            }
            else
            {
                payment.PaymentSuccessful = false;
                return "Not enough funds in bank account";
            }
        }

    }
}

using PaymentGateway_DataAccess;
using PaymentGateway_Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentGateway_Service
{
    public class PaymentService : IPaymentService
    {
        private IRepository<Payment> paymentRepository;

        public PaymentService(IRepository<Payment> paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }

        public IEnumerable<Payment> GetPayment()
        {
            return paymentRepository.GetAll();
        }


        public Payment GetPayment(string number)
        {
            return paymentRepository.Get(number);
        }

        public async Task<bool> AddAsyncPayment(Payment payment)
        {
            try
            {
                var obj = new Payment
                {
                    PaymentId = payment.PaymentId,
                    CardNumber = payment.CardNumber,
                    EmailAddress = payment.EmailAddress,
                    Name = payment.Name,
                    ExpiryDate = DateTime.Parse(payment.ExpiryDate.ToString()),
                    CVV = payment.CVV,
                    Amount = payment.Amount,
                    PaymentSuccessful = payment.PaymentSuccessful,
                };
                var result = await paymentRepository.Add(obj);
                return result;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}

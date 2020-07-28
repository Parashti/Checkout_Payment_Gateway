using PaymentGateway_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway_Service
{
    public interface IPaymentService
    {
        IEnumerable<Payment> GetPayment();
        Payment GetPayment(string number);
        Task<bool> AddAsyncPayment(Payment payment);

    }
}

using PaymentGateway_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway_Service
{
    public interface IBankService
    {
        IEnumerable<Bank> GetBank();
        Bank GetBank(string number);
        Task<bool> AddAsyncBank(Bank bank);
        Task<bool> UpdateAsyncBank(Bank bank, decimal amount);
    }
}


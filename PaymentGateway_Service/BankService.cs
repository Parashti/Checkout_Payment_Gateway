using PaymentGateway_DataAccess;
using PaymentGateway_Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway_Service
{
    public class BankService : IBankService
    {
        private IRepository<Bank> bankRepository;
        private IRepository<Payment> paymentRepository;

        public BankService(IRepository<Bank> bankRepository, IRepository<Payment> paymentRepository)
        {
            this.bankRepository = bankRepository;
            this.paymentRepository = paymentRepository;
        }
        public IEnumerable<Bank> GetBank()
        {
            return bankRepository.GetAll();
        }

        public Bank GetBank(string number)
        {
            return bankRepository.Get(number);
        }

        public async Task<bool> AddAsyncBank(Bank bank)
        {
            try
            {
                var obj = new Bank
                {
                    CardNumber = bank.CardNumber,
                    Name = bank.Name,
                    ExpiryDate = DateTime.Parse(bank.ExpiryDate.ToString()),
                    CVV = bank.CVV,
                    AmountRemaining = bank.AmountRemaining
                };
                var result = await bankRepository.Add(obj);
                return result;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> UpdateAsyncBank(Bank bank, decimal amount)
        {
            try
            {
                var obj = new Bank
                {
                    CardNumber = bank.CardNumber,
                    Name = bank.Name,
                    ExpiryDate = DateTime.Parse(bank.ExpiryDate.ToString()),
                    CVV = bank.CVV,
                    AmountRemaining = bank.AmountRemaining - amount
                };

                var result = await bankRepository.Update(obj);              
                return result;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}

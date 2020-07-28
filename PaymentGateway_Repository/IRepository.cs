using PaymentGateway_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway_Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(string id);
        IEnumerable<T> GetAll();
        Task<bool> Add(Payment payment);
        Task<bool> Add(Bank bank);
        Task<bool> Update(Bank bank);

    }
}

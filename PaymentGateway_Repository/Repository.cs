using Microsoft.EntityFrameworkCore;
using PaymentGateway_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway_Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext context;
        private readonly ApplicationContext contextUpdate;
        private readonly DbSet<T> entities;
       
        public Repository(ApplicationContext context, ApplicationContext contextUpdate)
        {
            this.context = context;
            this.contextUpdate = contextUpdate;
            entities = context.Set<T>();
            
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public T Get(string number)
        {
            return entities.SingleOrDefault(p => p.CardNumber == number);
        }
        public async Task<bool> Add(Payment payment)
        {        
            try
            {
                await context.AddAsync(payment);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Add(Bank bank)
        {
            try
            {
                await context.AddAsync(bank);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> Update(Bank bank)
        {
            try
            {
                contextUpdate.Update(bank);
                await contextUpdate.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}

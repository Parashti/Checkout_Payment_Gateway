using Microsoft.EntityFrameworkCore;
using PaymentGateway_DataAccess;
using System;

namespace PaymentGateway_Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new BankMap(modelBuilder.Entity<Bank>());
            new PaymentMap(modelBuilder.Entity<Payment>());
           
        }
    }
}

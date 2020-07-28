using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway_DataAccess
{
    public class BankMap
    {
        public BankMap(EntityTypeBuilder<Bank> entityBuilder)
        {
            entityBuilder.HasKey(p => new { p.Name, p.CardNumber, p.ExpiryDate, p.CVV });     
            entityBuilder.Property(p => p.AmountRemaining).IsRequired();
            entityBuilder.HasMany(p => p.Payments).WithOne(p => p.Bank).HasForeignKey(x => new { x.Name, x.CardNumber, x.ExpiryDate, x.CVV });
        }
    }

}
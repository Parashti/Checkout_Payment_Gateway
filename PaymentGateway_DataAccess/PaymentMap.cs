using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway_DataAccess
{
    public class PaymentMap
    {
        public PaymentMap(EntityTypeBuilder<Payment> entityBuilder)
        {
            entityBuilder.HasKey(p => p.PaymentId);
            entityBuilder.Property(p => p.Name).IsRequired();
            entityBuilder.Property(p => p.EmailAddress).IsRequired();
            entityBuilder.Property(p => p.CardNumber).IsRequired();
            entityBuilder.Property(p => p.Amount).IsRequired();
            entityBuilder.Property(p => p.ExpiryDate).IsRequired();
            entityBuilder.Property(p => p.CVV).IsRequired();
            entityBuilder.Property(p => p.PaymentSuccessful).IsRequired();
           
        }
    }

}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security;

namespace PaymentGateway_DataAccess
{
    public class BaseEntity
    {
        
        [Required]
        [DataType(DataType.CreditCard)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [RegularExpression(@"^(1298|1267|4512|4567|8901|8933)([\-\s]?[0-9]{4}){3}$")]
        [MaxLength(16)]
        public string CardNumber { get; set; }
      
    }
}

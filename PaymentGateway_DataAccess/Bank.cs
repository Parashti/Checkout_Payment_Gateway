using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PaymentGateway_DataAccess
{
    public class Bank : BaseEntity
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Name { get; set; }

        [Required]        
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "yyyy-MM", ApplyFormatInEditMode = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTime ExpiryDate { get; set; }

        [Required]      
        [DatabaseGenerated(DatabaseGeneratedOption.None)]      
        [RegularExpression(@"^\d{3}$")]
        [MaxLength(3)]
        public string CVV { get; set; }

        public decimal AmountRemaining { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}

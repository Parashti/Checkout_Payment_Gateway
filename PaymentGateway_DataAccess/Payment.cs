using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Text;

namespace PaymentGateway_DataAccess
{
    public class Payment : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PaymentId { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{yyyy-MM}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime ExpiryDate { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}$")]
        [MaxLength(3)]
        public string CVV { get; set; }
        
        public decimal Amount { get; set; }
        
        public bool PaymentSuccessful { get; set; }
        
        public virtual Bank Bank { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement_Management.Models
{
    public class Agreement
    {
        [Key]
        public int AgreementId { get; set; }
        public string UserId { get; set; }

   
        [Key]
        public ProductGroup ProductGroupId {get;set;}

         [Key]
        public Product Product { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Product_Price { get; set; }
        public string New_Price { get; set; }
        public bool Active { get; set; }
    }
}

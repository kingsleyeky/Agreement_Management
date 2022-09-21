using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement_Management.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Key]
        public ProductGroup ProductGroupId { get; set; }
        public string Product_Description { get; set; }
        public int Product_Number {get;set;}
        public decimal Price {get;set;}
        public bool Active { get; set; }
    }
}

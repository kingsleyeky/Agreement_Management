using Agreement_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement_Management.DTOs
{
    public class ProductDTO
    {
        public ProductGroup ProductGroupId { get; set; }
        public string Product_Description { get; set; }
        public int Product_Number { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
    }
}

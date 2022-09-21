using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement_Management.Models
{
    public class ProductGroup
    {
        [Key]
        public int productGroupId { get; set; }
        public string Group_Description { get; set; }
        public string Group_Code { get; set; }
        public bool Active { get; set; }
    }
}

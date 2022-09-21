using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement_Management.DTOs
{
    public class ProductGroupDTO
    {
        public int productGroupId { get; set; }
        public string Group_Description { get; set; }
        public string Group_Code { get; set; }
        public bool Active { get; set; }
    }
}

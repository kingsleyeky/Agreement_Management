using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement_Management.DTOs
{
    public class AgreementDTO
    {
        public int AgreementId { get; set; }
        public int UserId { get; set; }
        public int Group { get; set; }
        [Required(ErrorMessage = "Product is required")]
        public int Product { get; set; }
        [Required(ErrorMessage = "EffectiveDate is required")]
        public DateTime EffectiveDate { get; set; }
        [Required(ErrorMessage = "ExpirationDate is required")]
        public DateTime ExpirationDate { get; set; }
        [Required(ErrorMessage = "Product_Price is required")]
        public string Product_Price { get; set; }
        [Required(ErrorMessage = "New_Price is required")]
        public string New_Price { get; set; }
        [Required(ErrorMessage = "Active is required")]
        public bool Active { get; set; }
    }
}

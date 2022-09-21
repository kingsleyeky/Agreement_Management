using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement_Management.Models
{
    public class ServiceResponse
    {
       public bool Success { get; set; }
       public string Message { get; set; }
       public Object Data { get; set; }
        
    }
}

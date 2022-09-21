using Agreement_Management.Data;
using Agreement_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement_Management.Interface
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(User users);
    }
}

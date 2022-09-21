using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement_Management.Security
{
    public class EnumManager
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }


}

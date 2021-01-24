using System;
using System.Collections.Generic;
using System.Text;

namespace identity_server.web.BL.Common
{
    public class Hashing : IHashing
    {
        public string GetHashFromPassword(string userPassword)
        {
            string hash = BCrypt.Net.BCrypt.HashPassword(userPassword);
            return hash;
        }

        public bool isValidPassword(string userPassword, string hashUserPassword)
        {
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(userPassword, hashUserPassword);
            return isValidPassword;
        }
    }
}

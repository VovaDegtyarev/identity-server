using System;
using System.Collections.Generic;
using System.Text;

namespace identity_server.web.BL.Common
{
    public interface IHashing
    {
        string GetHashFromPassword(string userPassword);
        bool isValidPassword(string userPassword, string hashUserPassword);
    }
}

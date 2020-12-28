using identity_server.web.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace identity_server.web.BL.Services
{
    public interface IAuthService
    {
        void AddUser(UserBL user);
        UserView GetUser(Guid id);
        UserView GetUsers();
        UserView DeleteUser(Guid id);
        UserView UpdateUser(UserBL user);
    }
}

using identity_server.web.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace identity_server.web.DAL.Repository
{
    public interface IRepository
    {
        void AddUser();
        IEnumerable<User> GetUsers();
        User GetUser();

        User UpdateUser();
        void DeleteUser();
    }
}

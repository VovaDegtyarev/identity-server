﻿using identity_server.web.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace identity_server.web.DAL.Repository
{
    public interface IRepository
    {
        void AddUser(User user);
        IEnumerable<User> GetUsers();
        User GetUser(Guid userId);

        User UpdateUser(User user);
        void DeleteUser(Guid userId);
    }
}

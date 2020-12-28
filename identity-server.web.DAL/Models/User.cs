using System;
using System.Collections.Generic;
using System.Text;

namespace identity_server.web.DAL.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Hash { get; set; }
        public Role[] Roles { get; set; }
    }

    public enum Role
    {
        User,
        Admin
    }
}

using identity_server.web.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace identity_server.web.BL.Models
{
    public class UserBL
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Hash { get; set; }
        public Role[] Roles { get; set; }
    }
}

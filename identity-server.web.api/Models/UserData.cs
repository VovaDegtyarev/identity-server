using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identity_server.web.api.Models
{
    public class UserData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

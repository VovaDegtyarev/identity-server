using identity_server.web.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace identity_server.web.DAL.Context
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            Database.EnsureCreated();
            
            //if(exist)
            //{
            //    //var dbContext = new UserDbContext();

            //}
        }

        


    }
}

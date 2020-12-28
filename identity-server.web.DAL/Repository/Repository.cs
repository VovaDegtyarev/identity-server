using identity_server.web.DAL.Context;
using identity_server.web.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace identity_server.web.DAL.Repository
{
    public class Repository : IRepository
    {
        private readonly UserDbContext userDbContext;

        public Repository(UserDbContext userDbContext)
        {
            this.userDbContext = userDbContext;
        }

        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            userDbContext.Users.Add(user);
            userDbContext.SaveChanges();
        }

        public void DeleteUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentException("Incorrect User Id");
            }

            userDbContext.Remove(userId);
            userDbContext.SaveChanges();
        }

        public User GetUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentException("Incorrect User Id");
            }

            var user = userDbContext.Users.FirstOrDefault(user => user.Id == userId);
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            var users = userDbContext.Users.ToList();
            return users;
        }

        public User UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            } 
            else
            {
                if (!userDbContext.Users.Any(user => user.Id == user.Id))
                {
                    throw new ArgumentException("User didnt find");
                }
                userDbContext.Users.Update(user);
                userDbContext.SaveChanges();
            }
            return user;
        }
    }
}

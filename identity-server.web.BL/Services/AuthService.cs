using AutoMapper;
using identity_server.web.BL.Models;
using identity_server.web.DAL.Models;
using identity_server.web.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace identity_server.web.BL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public AuthService(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void AddUser(UserBL user)
        {
            var _user = mapper.Map<User>(user);
            repository.AddUser(_user);
        }

        public void DeleteUser(Guid id)
        {
            repository.DeleteUser(id);
        }

        public UserView GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public UserView GetUsers()
        {
            throw new NotImplementedException();
        }

        public UserView UpdateUser(UserBL user)
        {
            throw new NotImplementedException();
        }
    }
}

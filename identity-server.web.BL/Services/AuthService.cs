using AutoMapper;
using identity_server.web.BL.Common;
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
        private readonly IHashing hashing;

        public AuthService(IRepository repository, IMapper mapper, IHashing hashing)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.hashing = hashing;
        }

        public void AddUser(UserBL user)
        {
            var _user = mapper.Map<User>(user);

            _user.Id = Guid.NewGuid();

            _user.Hash = hashing.GetHashFromPassword(_user.Password);
            _user.Password = "emptyPassword";


            repository.AddUser(_user);
        }

        public void DeleteUser(Guid id)
        {
            repository.DeleteUser(id);
        }

        public UserView GetUser(Guid id)
        {
            var user = repository.GetUser(id);
            var _user = mapper.Map<UserView>(user);
            return _user;
        }

        public UserView GetUsers()
        {
            throw new NotImplementedException();
        }

        public void Login(UserBL user)
        {
            var _user = mapper.Map<User>(user);
            var u = repository.GetUser(_user.Id);

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(_user.Password, u.Password);

            if (isValidPassword)
            {
                // TODO: token!
            } 
            else
            {
                // TODO: что-то другое
            }
        }

        public UserView UpdateUser(UserBL user)
        {
            throw new NotImplementedException();
        }
    }
}
